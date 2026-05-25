using UnityEngine;

public class Arrow_Generator : MonoBehaviour
{
    public GameObject Arrow_prefab;
    public Transform spawnPoint;
    float speed = 0;
    Vector3 startPos, endPos;
    int arrowNum = 0;
    GameObject BSound;
    
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BSound = GameObject.Find("HumanMale_Character_FREE");
        arrowNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            this.startPos = Input.mousePosition;
            BSound.GetComponent<BowLoader>().BowSound();
        }
        if (Input.GetMouseButtonUp(0))
        {
            BSound.GetComponent<BowLoader>().BowSoundEnd();
            GetComponent<AudioSource>().Play();
            GameObject arrow = Instantiate(Arrow_prefab,spawnPoint.position,spawnPoint.rotation) as GameObject;
            this.endPos = Input.mousePosition;
            this.speed = Mathf.Clamp(startPos.y - endPos.y,0,300)*8;

            Ray startRay = Camera.main.ScreenPointToRay(startPos); //시작점과 끝점의 중간지점 구하기
            Ray endRay = Camera.main.ScreenPointToRay(endPos);
            Vector3 startWorldPoint = startRay.origin + startRay.direction * 10f;
            Vector3 endWorldPoint = endRay.origin + endRay.direction * 10f;
            Vector3 midPoint = (startWorldPoint + endWorldPoint) / 2f;

            Debug.Log(this.speed);
           
            Vector3 worldDir = (midPoint - spawnPoint.position).normalized;
            arrow.GetComponent<Rigidbody>().AddForce(worldDir.normalized * this.speed);
            print("worldDir정규화 값:" + worldDir);
            arrowNum++;
            PlayerPrefs.SetInt("ArrowNum", arrowNum);
        }

    }
}
