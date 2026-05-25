using System.Collections.Generic;
using UnityEngine;

public class BowLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform bowGroup; // BowGroup 오브젝트
    int selectedIndex;
    void Start()
    {
        bowGroup = transform.Find("BowGroup");

        if (bowGroup == null)
        {
            Debug.LogError("BowGroup을 찾을 수 없습니다.");
            return;
        }

        this.selectedIndex = PlayerPrefs.GetInt("SelectedBow", 0); // 선택된 활 인덱스 가져오기
        //playerprefs는 간단한 저장기능으로, GetInt로 가져오기 / SetInt로 저장이 가능하다.
        //Selectedbow라는 이름에 숫자값을 불러오거나 저장할 수 있고, 없다면 0값을 넣는다.

        for (int i = 0; i < bowGroup.childCount; i++)
        {
            // 선택된 인덱스만 활성화
            bowGroup.GetChild(i).gameObject.SetActive(i == selectedIndex);
            //bowGroup 객체의 i번째 자식을 가져오기 / 오브젝트 켜거나 끄기 
        }
        
    }
    public void BowSound()
    {
        bowGroup.GetChild(this.selectedIndex).GetComponent<AudioSource>().Play();
    }
    public void BowSoundEnd()
    {
        bowGroup.GetChild(this.selectedIndex).GetComponent<AudioSource>().Stop();
    }
}
