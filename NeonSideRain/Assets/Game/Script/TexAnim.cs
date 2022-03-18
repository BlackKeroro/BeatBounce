using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexAnim : MonoBehaviour
{
    public MeshRenderer[] mb; //�ش� ������ �迭
    public MeshRenderer[] mm;
    //public MeshRenderer[] 
    public enum eAnimDirect //�ؽ�Ʈ �̵� ���⿡ ���� ����
    {
       AnimDown=0,
       AnimLeft,
       AnimUp,
       AnimRight,
    };

    //Unity ���ο��� Anim���� ���� ����(����ġ)
    public eAnimDirect eAniDir;
    //�ؽ�Ʈ �̵� �ӵ�
    public float speed = 2.0f;

    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
        eAniDir = eAnimDirect.AnimUp;
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTexDir();
        TexAni();
        RandEmissionColor();
        MRandEmissionColor();
        ColorLerp();
    }

    // �����Ϳ��� �ٲܶ� �ٷ� �����Ű���� ������Ʈ���� ó�� 
    void SetTexDir()
    {
        switch (eAniDir) //Anim���� ������ ���� ����
        {
            //AnimDown�� �����ϸ� Vector2.down�� ���
            case eAnimDirect.AnimDown:
                dir = Vector2.down;
                break;
            case eAnimDirect.AnimLeft:
                dir = Vector2.left;
                break;
            case eAnimDirect.AnimUp:
                dir = Vector2.up;
                break;
            case eAnimDirect.AnimRight:
                dir = Vector2.right;
                break;
        }
    }


    // �ؽ��� �ִϸ��̼� 
    void TexAni()
    {
        for (int i = 0; i < mb.Length; i++)//mb�� ������ŭ �ݺ�
        {
            //�ش� ������ �迭�� Material�� offset���� �����Ӹ��� ��ȯ���� �����̴� ��ó�� ����
            mb[i].material.mainTextureOffset += dir * speed * Time.deltaTime;
        }
    }


    //�����ð��� �ѹ��� �� ���� ���� 
    float currentTime = 0.0f;
    public float chageTime = 3.0f;
    void RandEmissionColor()
    {
        currentTime += Time.deltaTime;
        if (currentTime > chageTime)//currentTime�� changTime���� ũ��
        {
            ColorSelect();
            currentTime = 0.0f;
        }
    }
    //���� �¿쿡 �ִ� ��(Mountain)�� ����
    float McurrentTime = 0.0f;
    public float MchangeTime = 3.0f;
    void MRandEmissionColor()
    {
        McurrentTime += Time.deltaTime;
        if(McurrentTime > MchangeTime)
        {
            MColorSelect();
            McurrentTime = 0.0f;
        }
    }


    //�����ð��� �����ϰ� ���ο���� ������
    Color newColor = Color.blue; //ó�� ���� �÷�
    Color currentColor = Color.blue; 
    void ColorSelect()
    {
        //�ش� ���� �������� ����
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        //newcolor�� ����
        newColor = new Color(r,g,b);
        
    }

    Color MnewColor = Color.blue;
    Color McurrentColor = Color.blue;
    void MColorSelect()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

        MnewColor = new Color(r, g, b);
    }

    // ���Ӱ� ���ǵ� ���� �������� �����ؼ� �ε巴�� ó�� 
    float cSpeed = 0.5f;
    void ColorLerp()
    {
        //currntColor�� Color.Lerp�� ����Ͽ� ������ �÷�(currentColor)���� ���ο� �÷�(new Color)�� �ε巴�� ����
        currentColor = Color.Lerp(currentColor, newColor, Time.deltaTime * cSpeed);
        for (int i = 0; i < mb.Length; i++) //mb �迭�� �����ϴ� �� ��� ����
        {
            mb[i].material.SetColor("_EmissionColor", currentColor);
        }
        McurrentColor = Color.Lerp(McurrentColor, MnewColor, Time.deltaTime * cSpeed);
        for (int i = 0; i < mm.Length; i++)
        {
            mm[i].material.SetColor("_EmissionColor", McurrentColor);
        }
    }

}