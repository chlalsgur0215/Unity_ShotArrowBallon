using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Arrow_shoot : MonoBehaviour
{
    GameObject director, ballonDir;

    private Rigidbody rb;
    public float destroyTime = 6f;
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.ballonDir = GameObject.Find("MoveTargetGen");
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        
        if (!(other.gameObject.name == "FPSController") && !(other.gameObject.tag == "Arrow") && !(other.gameObject.tag == "Light"))
        {
            
            if (other.gameObject.name == "Target")
            {
                GetComponent<AudioSource>().Play();
            }
            GetComponent<Rigidbody>().isKinematic = true;
            print(other.gameObject.tag);
        }
        
        
        Destroy(gameObject, destroyTime);
        if (other.gameObject.tag == "MoveTarget")
        {
            this.ballonDir.GetComponent<MoveTargetGen>().BallonBomb();
            print("풍선과 충돌");
            Destroy(other.gameObject);
            Destroy(gameObject);
            this.director.GetComponent<ScoreDirector>().HitBallon(); //점수를위한
        }
        Debug.Log("충돌한 오브젝트: " + other.gameObject.name);
    }
    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f) //rb.linearVelocity : 선형속도 , Velocity : rd의 속도를 나타냄.
            //magnitude : 벡터의 길이 또는 크기를 나타냄. 즉 선형 속도 벡터의 크기 > 속도를 나타냄.
        {//linearVelocity는 2d에서 선형속도를 나타냄
            Quaternion targetRotation = Quaternion.LookRotation(rb.linearVelocity.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            //Quaternion : 회전을 표현하는 타입. ,Quaternion.LookRotation(Vector3 forward) :
            //forward 벡터를 바라보는 방향으로 회전. 즉 현재 속도 방향으로 향하게 하는 회전을 만드는것.
            //Quaternion.Lerp(from, to, t) > 두 회전 사이를 선형보간함. from:현재 회전상태, to : 목표 회전상태, 
            // t : 보간 정도(0이면 시작회전, 1이면 목표회전)

        }
    }

}
