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
    //ü�� �̹��� ����
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
        if(UpHpbar == 10) //ü���� 10������ ��� ��Ʈ�� �ѹ� ������ ������ UpHpbar 1���
        {
            //UpHpbar�� 10�̸� ü�� ����
            Hp++; 
            UpHpbar = 0;
            //����� ü���� �̹��� Ȱ��ȭ(�迭�� 1�� ������ 0�̱� ������ ���� ü���� -1)
            Heart[Hp - 1].SetActive(true);
        }

        if (Hp <= 0 && isCoroutine == true) //Hp�� 0���� �۰ų� ������
        {
            //Fade Ȱ��ȭ �� FadeDie �ڷ�ƾ ����
            FD.SetActive(true);
            Fade.StartCoroutine("FadeDie");
            isCoroutine = false;
        }

        if(Hp - HpCount <= 0) //hp ���� hpcount(9)�� ���� ���� �� ������ �۰ų� ������
        {
            if(isCoroutine == true)
            {
                //���� ü�¿� �ش��ϴ� ü�� �̹��� ��Ȱ��ȭ
                Heart[Hp].SetActive(false);
            }
        } 
        
    }


}
