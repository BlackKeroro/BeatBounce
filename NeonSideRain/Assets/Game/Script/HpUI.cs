using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    public static int Hp;
    public Image Hpbar;
    
    public static int UpHpbar;
    Image Image;

    public GameObject FD;
    Fade Fade;
    //체력 이미지 개수
    public GameObject[] Heart;

    int HpCount;

    bool isCoroutine = true;
    void Awake()
    {
        Hp = 10;
        UpHpbar = 0;
        HpCount = 9;
    }
    // Start is called before the first frame update
    void Start()
    {
        Image = Hpbar.GetComponent<Image>();
        Fade = FD.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UpHpbar == 10) //체력이 10이하일 경우 노트를 한번 성공할 때마다 UpHpbar 1상승
        {
            //UpHpbar가 10이면 체력 증가
            Hp++; 
            UpHpbar = 0;
            //상승한 체력의 이미지 활성화(배열의 1번 순서가 0이기 떄문에 현재 체력의 -1)
            Heart[Hp - 1].SetActive(true);
        }

        if (Hp <= 0 && isCoroutine == true) //Hp가 0보다 작거나 같으면
        {
            //Fade 활성화 및 FadeDie 코루틴 실행
            FD.SetActive(true);
            Fade.StartCoroutine("FadeDie");
            isCoroutine = false;
        }

        if(Hp - HpCount <= 0) //hp 값에 hpcount(9)의 값을 뺐을 때 ㅇ보다 작거나 같으면
        {
            if(isCoroutine == true)
            {
                //현재 체력에 해당하는 체력 이미지 비활성화
                Heart[Hp].SetActive(false);
            }
        } 
        
    }


}
