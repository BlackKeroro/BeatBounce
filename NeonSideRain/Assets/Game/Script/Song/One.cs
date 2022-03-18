using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UIElements;
using Newtonsoft.Json;
/*
text파일에 string 데이터 쓰고 읽기
1. 파일을 저장할때는 쉼표단위로 저장하였다.
예) 1,sword,attack

2.읽을때는 한줄읽어 쉼표로 구분된 데이터를 추출한다.
- values 배열에 쉼표로 구분된 데이터가 저장된다.
*/

public struct Piece
{
    //Json파일에서 호출할 인덱스와 시간
    public int index;
    public float time;
}

public class One : MonoBehaviour
{
    //생성될 노트 블럭 위치
    public GameObject[] Factory;
    //생성할 노트 프리팹
    public GameObject[] Note;
    //string m_strPath = "Assets/Resources/";

    //Json파일에서 받아올 인덱스 리스트
    List<int> listFireObjIdx = new List<int>();
    //Json파일에서 받아올 타임 리스트
    List<float> listFireShotTime = new List<float>();
    //Json 파일에 가져올 데이터 리스트
    public List<Piece> data = new List<Piece>();

    float currentTime = 0.0f;
    int shotCnt = 0;
    public GameObject rnd;
    public GameObject FD;

    Fade Fade;
    void Start()
    {
        Parse();
        Fade = FD.GetComponent<Fade>();

    }
    // Use this for initialization

    public void Parse()
    {
        /*TextAsset data = Resources.Load("Data", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);
        // 먼저 한줄을 읽는다. 
        string source = sr.ReadLine();
        string[] values;                // 쉼표로 구분된 데이터들을 저장할 배열 (values[0]이면 첫번째 데이터 )

        while (source != null)
        {
            values = source.Split(',');  // 쉼표로 구분한다. 저장시에 쉼표로 구분하여 저장하였다.
            if (values.Length == 0)
            {
                sr.Close();
                return;
            }
            source = sr.ReadLine();    // 한줄 읽는다.
            listFireObjIdx.Add(Convert.ToInt32(values[0]));
            listFireShotTime.Add((float)(Convert.ToDouble(values[1])- MusicManager.instance.tempTime));*/

        //제이슨 파서
        //해당 경로의 Json파일 불러옴
        string json = File.ReadAllText(Application.dataPath + "/Resources/One.json");
        //제이슨파일 직렬화 해제
        data = JsonConvert.DeserializeObject<List<Piece>>(json);
        //반복문을 돌면서 해당 데이터 계속 읽어옴
        for (int i = 0; i < data.Count; i++)
        {
            //제이슨파일에 인덱스 호출
            listFireObjIdx.Add(Convert.ToInt32(data[i].index));
            //제이슨파일에 타임 호출
            listFireShotTime.Add((float)(Convert.ToDouble(data[i].time) - MusicManager.instance.tempTime));
        }

    }

    bool isCoroutine = true; //코루틴 반복 제한
    private void FixedUpdate()
    {
        //인덱스의 갯수와 타임의 갯수가 0보다 크고  
        if(listFireObjIdx.Count > 0  && listFireShotTime.Count > 0)
        {
            //인덱스의 갯수가 실행갯수(ShotCnt)보다 많을 경우 
            if (listFireObjIdx.Count > shotCnt)
            {
                currentTime += Time.fixedDeltaTime;
                //curretTime이 제이슨 파일에 존재하는 실행 번호의 타임(시간)보다 클 경우
                if (currentTime > listFireShotTime[shotCnt])
                {
                    int idx = listFireObjIdx[shotCnt];
                    //랜덤 위치로 지정
                    rnd = Factory[UnityEngine.Random.Range(0, Factory.Length)];
                    //노트 프리팹을 생성
                    GameObject fireObjects = Instantiate(Note[idx]);
                    //해당 랜덤 위치에서 시작
                    fireObjects.transform.position = rnd.transform.position;

                  print("오브젝트인덱스:" + listFireObjIdx[shotCnt] + " 경과시간: " + listFireShotTime[shotCnt]);
                    //실행 번호 증가해서 다음 실행 번호의 타임을 불러옴
                    shotCnt++;

                }
            }
            else
            {
                //아니면(끝났을 경우) Fade에 사용할 Panel 활성화
                GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
                Fade.StopCoroutine("FadeOut"); //Fade 스크립트에 실행되고 있는 FadeOut 코루틴 중지
                if (isCoroutine == true)
                {
                    Fade.StartCoroutine("FadeIn");//코루틴 한번만 실행
                    isCoroutine = false;
                }


            }
        }
       
    }

}