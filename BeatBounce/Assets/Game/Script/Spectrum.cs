using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    //public GameObject spectrumObj;
    public Transform Pos; //스펙트럼 위치
    public Transform Pos2; //스펙트럼 위치2
    public int spectrumSize = 64; //스펙트럼사이즈(갯수)

    public Material Color; //스펙트럼의 색깔

    GameObject spectrumObj; //스펙트럼 오브젝트

    GameObject spectrum2; //스펙트럼 오브젝트2
    // Start is called before the first frame update
    void Start()
    {
        spectrumObj = new GameObject("Spectrum"); //스펙트럼의 이름을 가진 오브젝트를 생성
        for (int i = 0; i < spectrumSize; i++)//스펙트럼의 사이즈만큼 반복
        {
            //큐브 이름의 오브젝트를 생성하고 오브젝트의 모양을 큐브형태로 만들기
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //스펙트럼 부모 오브젝트를 지정된 스펙트럼의 위치로 이동
            spectrumObj.transform.position = Pos.transform.position;
            //생성된 큐브를 스펙트럼 오브젝트의 하위 오브젝트로 넣기
            cube.transform.parent = spectrumObj.transform;
            //큐브의 위치를 나열해주기 위하여 X방향에 * i(반복문)을 넣어 순차적으로 배열, 크기는 동일
            cube.transform.localPosition = new Vector3(4f*i,0,0);
            cube.transform.localScale= new Vector3(4f,3, 4f);
            //큐브의 색을 통일
            cube.GetComponent<Renderer>().material = Color;

        }
        
        spectrum2 = new GameObject("Spect2");
        for (int i = 0; i < spectrumSize; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            spectrum2.transform.position = Pos2.transform.position;
            spectrum2.transform.rotation = Pos2.transform.rotation;
            cube.transform.parent = spectrum2.transform;
            cube.transform.localPosition = new Vector3(4.0f * i, 0, 0);
            cube.transform.localScale = new Vector3(4f, 3, 4f);
            cube.GetComponent<Renderer>().material = Color;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //스펙트럼 배열에 스펙트럼 사이즈 만큼 만들기
        float[] spectrum = new float[spectrumSize];
        //재생중인 Source의 스펙트럼 데이터 블록을 반환하여 스펙트럼의 갯수(2의 배수)작동
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        
        for (int i = 0; i < spectrumSize; i++) //스펙트럼 사이즈 갯수만큼 반복
        {
            //스펙트럼의 크기가 뒤로 갈 수록 데이터 블록을 받았을 때 커지는 크기가 달라짐(뒤로 갈 수록 크기가 커짐)
            spectrumObj.transform.GetChild(i).transform.localScale = new Vector3(4f, 110  * spectrum[i], 4f);

        }
        for (int i = 0; i < spectrumSize; i++)
        {
            spectrum2.transform.GetChild(i).transform.localScale = new Vector3(4f, 110 * spectrum[i], 4f);
            /*
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
           */
        }
    }



}
