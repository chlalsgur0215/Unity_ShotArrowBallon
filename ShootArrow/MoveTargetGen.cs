using UnityEngine;

public class MoveTargetGen : MonoBehaviour
{
    public GameObject MoveTarget;
    float span = 2.0f;
    float delta = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BallonBomb()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(MoveTarget) as GameObject;
            int px = Random.Range(100, 140);
            int pz = Random.Range(60,90);
            go.transform.position = new Vector3(px, 2, pz);
        }
    }
}
