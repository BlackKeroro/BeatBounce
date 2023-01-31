using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //Json�� ����ϱ� ����
using System.IO;//���� ����, ���� �� ���� ���� �Լ� ��� ����

public class JsonImport : MonoBehaviour
{
    float currentTime = 0.0f;
    //��Ʈ�� ���� �뷡
    AudioSource aus;
    bool isStart = false;
    //������ ������ġ ����
    string m_strPath = "Assets/Resources/";
    FileStream fs;
    StreamWriter sw;
    
    public float tempTime = 0.3f;

    //json���� �����Ϳ� ���� LIST�����
    public List<Mydata> myData = new List<Mydata>();

    public struct Mydata
{
    public int index; //data�� �ε��� ��
    public float time; //Note Save�� ��ư�� ���� �ð�
}
//��������
void Start()
{
        //�ش� �̸��� ����(One.json) ���� ���� �� �ۼ��� �� �ֵ��� ����
        fs = new FileStream(m_strPath + "One.json", FileMode.Create, FileAccess.Write);
        sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
        aus = GetComponent<AudioSource>();
        

}

    public void StartMusic() //���� ���� ��ư Ŭ����
    {
        currentTime = 0.0f; //currentTime �ʱ�ȭ
        isStart = true;
        aus.Play();// �ش� �뷡 ����
    }

    private void FixedUpdate()
    {
        if (isStart == true) 
        {
            currentTime += Time.fixedDeltaTime;
        }
    }

    public void NoteSave()//��Ʈ ���̺� ��ư�� Ŭ����
    {

        //sw.WriteLine("{0},{1}", 0, (currentTime - tempTime));
        //print("0, " + (currentTime - tempTime));
 
            Mydata data;
            data.index = 0; //�Էµ� �ε��� ���� 0���� �����
           data.time = (currentTime - tempTime); //currentTime�� tempTime ���� �� �ð��� ���
            myData.Add(data); //index ��ϰ� time����� ��ħ ("{0}, {1}", index(0), time(currentTime - tempTime))
            

    }
    public void EndMusic() //���� ���� ��ư Ŭ����
    {
        currentTime = 0.0f;
        aus.Stop();

        //���̽����� ��θ� �ѹ� ��������� close�� �ݾ��ְ� ����� �����
        sw.Close();
        DoWrite();
    }
    public void DoWrite() //JSON string �����
{
    string json = JsonConvert.SerializeObject(myData.ToArray());   // Json���Ϸ� �о�ֱ�
    File.WriteAllText(Application.dataPath + "/Resources/One.json", json);  // json ���Ϸ� ����� ����� data ���� ����
    print(json); // �׽�Ʈ
}


}

