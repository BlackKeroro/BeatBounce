using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    public float tempTime;

    public AudioSource[] Song;

    MenuSong MS;
    public GameObject Menu;
    public float Delay;

    public int SongList;

    /*bool isSelect = false;*/

    MusicManager MU;
    Parser Ps;
    public GameObject FD;
    Fade Fade;
    public Pause PU;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        SongList = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        MS = Menu.GetComponent<MenuSong>();
        Fade = FD.GetComponent<Fade>();
        MS.SelectSong[List-1].Play();
        PU = PU.GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
       /*if (isSelect == false)
        {
            Time.timeScale = 0;
            return;
        }
        if (isSelect == true)
        {
            Time.timeScale = 1;
            return;
        }*/
    }

    public GameObject[] MusicSelect ;
    public GameObject SongSel;

    public void MusicSeletInit(bool bActive)
    {
        for(int i=0; i < MusicSelect.Length; i++) {
            MusicSelect[i].gameObject.SetActive(bActive);
        }
        
    }

    public void SongPlayint(int ActiveSong)
    {
        Song[ActiveSong].enabled = true;
        Song[ActiveSong].Play();
        SongList = ActiveSong;
    }
    

    public void OnPhysical()
    {
        Menu.SetActive(false);

        MusicSeletInit(false);
        //isSelect = true;
        Time.timeScale = 1;
        GameObject.Find("NoteFactory").gameObject.GetComponent<Parser>().enabled = true;
        SongSel.SetActive(false);
        Fade.StartCoroutine("FadeOut");
        Invoke("PhysicStart", Delay);
    }

    public void OnStarLight()
    {
        Menu.SetActive(false);

        MusicSeletInit(false);
        //isSelect = true;
        Time.timeScale = 1;
        GameObject.Find("NoteFactory").gameObject.GetComponent<Star>().enabled = true;
        SongSel.SetActive(false);
        Fade.StartCoroutine("FadeOut");
        Invoke("StarStart", Delay);
    }
    public void OnBlack()
    {
        Menu.SetActive(false);

        MusicSeletInit(false);
        //isSelect = true;
        Time.timeScale = 1;
        GameObject.Find("NoteFactory").gameObject.GetComponent<Black>().enabled = true;
        SongSel.SetActive(false);
        Fade.StartCoroutine("FadeOut");
        
        Invoke("HeavenStart", Delay);
    }
    public void OnOne()
    {
        Menu.SetActive(false);

        MusicSeletInit(false);
        //isSelect = true;
        Time.timeScale = 1;
        GameObject.Find("NoteFactory").gameObject.GetComponent<One>().enabled = true;
        SongSel.SetActive(false);

        Fade.StartCoroutine("FadeOut");

        Invoke("PieceStart", Delay);
    }

    //노래 선택시 해당 변수 대입 및 실행
    public void PhysicStart()
    {
        SongPlayint(0);
    }

    public void StarStart()
    {
       SongPlayint(1);
    }
    public void HeavenStart()
    {
        SongPlayint(2);
    }
    public void PieceStart()
    {
        SongPlayint(3);
    }
    

    public int List = 1; // 노래 선택 전 노래 선택 변수(화면 전환시 노래 변경)

    public void NextSong() //
    {
        for (int i = 0; i < MusicSelect.Length; i++)
        {//ITween을 사용하여 MoveBy(현재 위치에서 원하는 숫자만큼 이동), X에 -1500만큼 1.5초에 걸쳐 이동한다.
            iTween.MoveBy(MusicSelect[i], iTween.Hash( "X", -1500, "time", 1.5f, "easetype", iTween.EaseType.easeInBack));
        }
        MS.SelectSong[List-1].Stop(); //해당 노래의 하이라이트 부분 정지
        GameObject.Find("NextButton").transform.GetChild(0).gameObject.SetActive(false); //마우스를 버튼에 가까이 했을때 빛나는 버튼 비활성화
        SongSel.transform.GetChild(0).gameObject.SetActive(false);//다음 버튼 잠시 비활성화
        SongSel.transform.GetChild(1).gameObject.SetActive(false);//이전 버튼 잠시 비활성화
        List++;
        Invoke("Previous", 1.5f);
    }
    public void Previous()
    {
        MS.SelectSong[List - 1].Play();//다음 곡 재생
        if (List == 4)//만약 List(노래)가 4라면
        {
            SongSel.transform.GetChild(1).gameObject.SetActive(true);//이전 버튼 활성화
         }
            else if(List != 1)//그렇다면 만약 List가 1이 아니면 
            {
            //이전, 다음 버튼 활성화
            SongSel.transform.GetChild(0).gameObject.SetActive(true);
            SongSel.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void PreviousSong()
    {
        for (int i = 0; i < MusicSelect.Length; i++)
        {
            //ITween을 사용하여 MoveBy(현재 위치에서 원하는 숫자만큼 이동), X에 1500만큼 1.5초에 걸쳐 이동한다.
                iTween.MoveBy(MusicSelect[i], iTween.Hash( "X", 1500, "time", 1.5f, "easetype", iTween.EaseType.easeInBack));
        }
        MS.SelectSong[List-1].Stop();
        GameObject.Find("PreviousButton").transform.GetChild(0).gameObject.SetActive(false);
        SongSel.transform.GetChild(0).gameObject.SetActive(false);
        SongSel.transform.GetChild(1).gameObject.SetActive(false);
        List--;
        Invoke("Next", 1.5f);
    }
    public void Next()
    {
        MS.SelectSong[List - 1].Play();
        if (List == 1)
        {
            SongSel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(List != 4)
        {
            SongSel.transform.GetChild(0).gameObject.SetActive(true);
            SongSel.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}

