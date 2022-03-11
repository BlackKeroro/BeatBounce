using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexAnim : MonoBehaviour
{
    public MeshRenderer[] mb;
    public MeshRenderer[] mm;
    //public MeshRenderer[] 
    public enum eAnimDirect
    {
       AnimDown=0,
       AnimLeft,
       AnimUp,
       AnimRight,
    };


    public eAnimDirect eAniDir;
    
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
        switch (eAniDir)
        {
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
        for (int i = 0; i < mb.Length; i++)
        {
            mb[i].material.mainTextureOffset += dir * speed * Time.deltaTime;
        }
    }


    //일정시간에 한번씩 벽 색을 선택 
    float currentTime = 0.0f;
    public float chageTime = 3.0f;
    void RandEmissionColor()
    {
        currentTime += Time.deltaTime;
        if (currentTime > chageTime)
        {
            ColorSelect();
            currentTime = 0.0f;
        }
    }

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
    Color newColor = Color.blue;
    Color currentColor = Color.blue;
    void ColorSelect()
    {
        
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

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
        currentColor = Color.Lerp(currentColor, newColor, Time.deltaTime * cSpeed);
        for (int i = 0; i < mb.Length; i++)
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