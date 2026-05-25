using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    GameObject StartText;
    public float blinkSpeed = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartText = GameObject.Find("Start3");
    }

    // Update is called once per frame
    void Update()
    {
        StartText.GetComponent<CanvasGroup>().alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);
        //Time.time : 게임이 실행된 누적 시간(초) , deltaTime : 한 프레임이 지난 시간.
        //얼마나 시간이 흘렀나 vs 지금 프레임과 이전 프레임 사이 시간
        //Mathf.PingPong(a,b) : 0에서b까지 갔다가 다시 0으로 오는걸 반복. a : 현재 시간 같은 값, b : 반복 최대값.
        //blinkSpeed가 적을수록 느리게 깜박임. 1.0 : 1초 1번, 2.0 : 1초2번.

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("HomeDirector");
        }
    }
}
