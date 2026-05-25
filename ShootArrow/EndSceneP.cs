using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneP : MonoBehaviour
{
    int point = 0;
    int arrow = 0;
    GameObject AText;
    GameObject PText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.point = PlayerPrefs.GetInt("EndPoint");
        this.arrow = PlayerPrefs.GetInt("ArrowNum");
        this.PText = GameObject.Find("PointText");
        this.AText = GameObject.Find("ArrowText");
    }

    
    void Update()
    {
        this.PText.GetComponent<Text>().text = "총 점수 : " + this.point;
        this.AText.GetComponent<Text>().text = "사용 화살 개수 : " + this.arrow;
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("HomeDirector");
        }
    }
}
