using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeDirector : MonoBehaviour
{
    GameObject StartBt;
    GameObject ptEasyBt;
    GameObject CustomBt;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartScene()
    {
        SceneManager.LoadScene("BallonHitGame");
    }
    public void PtEasyScene()
    {
        SceneManager.LoadScene("PtEasy");
    }
    public void CustomScene()
    {
        SceneManager.LoadScene("BowSelectS");
    }
    public void HomeScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    // Update is called once per frame

}
