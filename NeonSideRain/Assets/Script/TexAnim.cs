using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexAnim : MonoBehaviour
{
    public MeshRenderer[] mb; //해당 렌더러 배열
    public MeshRenderer[] mm;
    //public MeshRenderer[] 
    public enum eAnimDirect //텍스트 이동 방향에 대한 열거
    {
       AnimDown=0,
       AnimLeft,
       AnimUp,
       AnimRight,
    };

    //Unity 내부에서 Anim방향 설정 가능(스위치)
    public eAnimDirect eAniDir;
    //텍스트 이동 속도
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

    // 에디터에서 바꿀때 바로 적용시키도록 업데이트에서 처리 
    void SetTexDir()
    {
        switch (eAniDir) //Anim방향 설정에 따른 방향
        {
            //AnimDown을 선택하면 Vector2.down을 사용
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


    // 텍스쳐 애니메이션 
    void TexAni()
    {
        for (int i = 0; i < mb.Length; i++)//mb의 갯수만큼 반복
        {
            //해당 렌더러 배열의 Material의 offset값을 프레임마다 변환시켜 움직이는 것처럼 만듦
            mb[i].material.mainTextureOffset += dir * speed * Time.deltaTime;
        }
    }


    //일정시간에 한번씩 벽 색을 선택 
    float currentTime = 0.0f;
    public float chageTime = 3.0f;
    void RandEmissionColor()
    {
        currentTime += Time.deltaTime;
        if (currentTime > chageTime)//currentTime이 changTime보다 크면
        {
            ColorSelect();
            currentTime = 0.0f;
        }
    }
    //게임 좌우에 있는 산(Mountain)색 변경
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


    //일정시간에 랜덤하게 새로운색을 설정함
    Color newColor = Color.blue; //처음 시작 컬러
    Color currentColor = Color.blue; 
    void ColorSelect()
    {
        //해당 색을 랜덤으로 지정
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        //newcolor에 대입
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

    // 새롭게 정의된 색을 기존색과 보간해서 부드럽게 처리 
    float cSpeed = 0.5f;
    void ColorLerp()
    {
        //currntColor에 Color.Lerp을 사용하여 기존의 컬러(currentColor)에서 새로운 컬러(new Color)로 부드럽게 변경
        currentColor = Color.Lerp(currentColor, newColor, Time.deltaTime * cSpeed);
        for (int i = 0; i < mb.Length; i++) //mb 배열에 존재하는 것 모두 변경
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