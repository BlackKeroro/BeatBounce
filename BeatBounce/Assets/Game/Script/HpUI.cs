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
        if(UpHpbar == 10)
        {
            Hp++;
            UpHpbar = 0;
            Heart[Hp - 1].SetActive(true);
        }

        if (Hp <= 0 && isCoroutine == true)
        {
            FD.SetActive(true);
            Fade.StartCoroutine("FadeDie");
            isCoroutine = false;
        }

        if(Hp - HpCount <= 0)
        {
            if(isCoroutine == true)
            {
                Heart[Hp].SetActive(false);
            }
        } 
        
    }


}
