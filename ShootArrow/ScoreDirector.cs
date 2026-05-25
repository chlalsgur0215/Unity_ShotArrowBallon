
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreDirector : MonoBehaviour
{
    GameObject timeText;
    float time = 30.0f;

    int point = 0;
    GameObject pointText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.timeText = GameObject.Find("Time");
        this.pointText = GameObject.Find("ScoreText");
    }
    public void HitBallon()
    {
        this.point += Random.Range(100,301);
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timeText.GetComponent<Text>().text = this.time.ToString("F");
        this.pointText.GetComponent<Text>().text = "Score : " + this.point.ToString();
        if (this.time < 0)
        {
            PlayerPrefs.SetInt("EndPoint", point);
            SceneManager.LoadScene("EndScene");
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("HomeDirector");
        }
    }
}
