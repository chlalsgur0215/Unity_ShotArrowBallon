using UnityEngine;
using UnityEngine.SceneManagement;

public class BowSelector : MonoBehaviour
{
    public int bowIndex;
    void OnMouseDown()
    {
        Debug.Log("클릭된 활 인덱스: " + bowIndex); //  1. 인덱스 확인
        PlayerPrefs.SetInt("SelectedBow", bowIndex);
        PlayerPrefs.Save(); //  2. 저장 반영
        SceneManager.LoadScene("HomeDirector");
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update() //update에 하니까 모든 활이 다 찍혀버림
    {
       
    }
}
