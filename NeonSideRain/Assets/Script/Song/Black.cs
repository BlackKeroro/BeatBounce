﻿using System.Collections;
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

public struct Heaven
{
    public int index;
    public float time;
}

public class Black : MonoBehaviour
{
    public GameObject[] Factory;
    public GameObject[] Note;
    //string m_strPath = "Assets/Resources/";

    List<int> listFireObjIdx = new List<int>();
    List<float> listFireShotTime = new List<float>();
    public List<Heaven> data = new List<Heaven>();

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
        //경로의 파일 불러옴
        string json = File.ReadAllText(Application.dataPath + "/Resources/Black.json");
        //제이슨파일 직렬화 해제
        data = JsonConvert.DeserializeObject<List<Heaven>>(json);
        //반복문을 돌면서 해당 데이터 계속 읽어옴
        for (int i = 0; i < data.Count; i++)
        {
            //제이슨파일에 인덱스 호출
            listFireObjIdx.Add(Convert.ToInt32(data[i].index));
            //제이슨파일에 타임 호출
            listFireShotTime.Add((float)(Convert.ToDouble(data[i].time) - MusicManager.instance.tempTime));
        }

    }

    bool isCoroutine = true;
    private void FixedUpdate()
    {
        if(listFireObjIdx.Count > 0  && listFireShotTime.Count > 0)
        {
            if (listFireObjIdx.Count > shotCnt)
            {
                currentTime += Time.fixedDeltaTime;
                if (currentTime > listFireShotTime[shotCnt])
                {
                    int idx = listFireObjIdx[shotCnt];
                    rnd = Factory[UnityEngine.Random.Range(0, Factory.Length)];
                    GameObject fireObjects = Instantiate(Note[idx]);
                    fireObjects.transform.position = rnd.transform.position;

                  print("오브젝트인덱스:" + listFireObjIdx[shotCnt] + " 경과시간: " + listFireShotTime[shotCnt]);
                    shotCnt++;

                }
            }
            else
            {
                GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
                Fade.StopCoroutine("FadeOut");
                if (isCoroutine == true)
                {
                    Fade.StartCoroutine("FadeIn");
                    isCoroutine = false;
                }


            }
        }
       
    }

}