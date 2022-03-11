using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

public class JsonImport : MonoBehaviour
{
    float currentTime = 0.0f;
    AudioSource aus;
    bool isStart = false;
    string m_strPath = "Assets/Resources/";
    FileStream fs;
    StreamWriter sw;
    public float tempTime = 0.3f;

    public List<Mydata> myData = new List<Mydata>();

    public struct Mydata
{
    public int index;
    public float time;
}
//변수선언
void Start()
{

        fs = new FileStream(m_strPath + "One.json", FileMode.Create, FileAccess.Write);
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
        aus = GetComponent<AudioSource>();
        //데이터 넣기

}
    public void StartMusic()
    {
        currentTime = 0.0f;
        isStart = true;
        aus.Play();
    }
    public void NoteSave()
    {

        //sw.WriteLine("{0},{1}", 0, (currentTime - tempTime));
        //print("0, " + (currentTime - tempTime));
 
            Mydata data;
            data.index = 0;
           data.time = (currentTime - tempTime);
            myData.Add(data);
            

    }

    public void DoWrite() // 2. JSON string 만들기
{
    string json = JsonConvert.SerializeObject(myData.ToArray());   // Json파일로 밀어넣기
    File.WriteAllText(Application.dataPath + "/Resources/One.json", json);  // 파일로 만들기
    print(json); // 테스트
}
    public void EndMusic()
    {
        currentTime = 0.0f;
        aus.Stop();

        //제이슨파일 경로를 한번 사용했으면 close로 닫아주고 사용해야함
        sw.Close();
        DoWrite();
    }
    private void FixedUpdate()
    {
        if (isStart == true)
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

}

