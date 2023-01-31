using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //Json을 사용하기 위함
using System.IO;//파일 생성, 삭제 등 파일 관련 함수 사용 가능

public class JsonImport : MonoBehaviour
{
    float currentTime = 0.0f;
    //노트를 찍을 노래
    AudioSource aus;
    bool isStart = false;
    //생성할 파일위치 지정
    string m_strPath = "Assets/Resources/";
    FileStream fs;
    StreamWriter sw;
    
    public float tempTime = 0.3f;

    //json파일 데이터에 대한 LIST만들기
    public List<Mydata> myData = new List<Mydata>();

    public struct Mydata
{
    public int index; //data의 인덱스 값
    public float time; //Note Save의 버튼을 누른 시간
}
//변수선언
void Start()
{
        //해당 이름을 가진(One.json) 파일 생성 및 작성할 수 있도록 적용
        fs = new FileStream(m_strPath + "One.json", FileMode.Create, FileAccess.Write);
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
        aus = GetComponent<AudioSource>();
        

}

    public void StartMusic() //음악 시작 버튼 클릭시
    {
        currentTime = 0.0f; //currentTime 초기화
        isStart = true;
        aus.Play();// 해당 노래 시작
    }

    private void FixedUpdate()
    {
        if (isStart == true) 
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

    public void NoteSave()//노트 세이브 버튼을 클릭시
    {

        //sw.WriteLine("{0},{1}", 0, (currentTime - tempTime));
        //print("0, " + (currentTime - tempTime));
 
            Mydata data;
            data.index = 0; //입력된 인덱스 값을 0으로 만들기
           data.time = (currentTime - tempTime); //currentTime에 tempTime 값을 뺀 시간을 기록
            myData.Add(data); //index 기록과 time기록을 합침 ("{0}, {1}", index(0), time(currentTime - tempTime))
            

    }
    public void EndMusic() //음악 종료 버튼 클릭시
    {
        currentTime = 0.0f;
        aus.Stop();

        //제이슨파일 경로를 한번 사용했으면 close로 닫아주고 사용해 줘야함
        sw.Close();
        DoWrite();
    }
    public void DoWrite() //JSON string 만들기
{
    string json = JsonConvert.SerializeObject(myData.ToArray());   // Json파일로 밀어넣기
    File.WriteAllText(Application.dataPath + "/Resources/One.json", json);  // json 파일로 만들어 기록한 data 값을 저장
    print(json); // 테스트
}


}

