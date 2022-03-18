using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    Image Image;

    
    MusicManager MM;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    void Start()
    {
        Image = GetComponent<Image>();
        MM = GameObject.Find("MusicVoice").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public IEnumerator FadeOut()
    {
        //이미지의 투명도에 사용할 변수 생성
        int ImageColor = 20;
        for (int i = 20; i > 0f; i--)
        {
           //반복문을 통해 실행될 때마다 투명도 변수를 1씩 감소하여 점점 투명해 지도록 적용
            ImageColor--;
            //해당 투명도 변수를 해당하는 이미지의 투명도(a)값에 대입
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)ImageColor / 20);
            yield return new WaitForSeconds(0.1f); //대입 후 0.1초의 대기시간 후 다시 반복
            Debug.Log("페이드 아웃");

        }
        gameObject.SetActive(false);//반복이 끝난 후 Fade 오브젝트 비활성화
    }

    public IEnumerator FadeIn()
    {
        //게임 인트로에서 게임 시작 후 7초의 대기시간 후 실행
        yield return new WaitForSeconds(7.0f);
        int InColor = 0; //투명도 값을 0으로 처음 지정
        for (int a = 0; a < 20f; a++)
        {
            InColor++; // 투명도 값 증가하여 점점 어두워 지도록 적용
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)InColor / 20);
            yield return new WaitForSeconds(0.1f);

        }
        //Canvas의 5번째 자식(End UI)을 활성화
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);

    }
    public IEnumerator FadeDie()
    {
        int InColor = 0;
        for (int a = 0; a < 20f; a++)
        {
            InColor++;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)InColor / 20);
            yield return new WaitForSeconds(0.1f);

        }
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        MM.Song[MM.SongList].Stop();
        Time.timeScale = 0;

        }



}
