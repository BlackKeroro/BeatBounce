using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActive : MonoBehaviour
{

    public float currentTime = 0.0f;//키 입력 시간 체크
    public GameObject ComboFade;//COmboUI가 있는 게임 매니저

    ComboUI CU; //콤보 Fade실행을 위한 UI받아오가

    public GameObject PerfectText; //Pertect텍스트
    public GameObject GoodText; //Good 텍스트
    public Transform TPos; //생성될 텍스트 위치

    void Start()
    {
        CU = ComboFade.GetComponent<ComboUI>();

    }

    // Update is called once per frame
    void Update()
    {
        //해당 오브젝트 활성화 시 실행
        currentTime += Time.deltaTime;
    }

    /*public void PerfactText()
    {
        GameObject Perfacttxt = Instantiate(Perfact, transform.position, Quaternion.identity, Canvas.transform);
    }*/

      void NoteAttack()
    {
        ComboUI.Combo++; //콤보 수 증가
        if (HpUI.Hp < 10) // 체력이 10 이하일 경우
        {
            HpUI.UpHpbar++; //체력 상승을 위한 개수 증가(UPHpbar = 10 일 때 Hp 증가)
        }
        CU.StopCoroutine("FadeInanim"); //실행되고 있는 코루틴 중지
        CU.StartCoroutine("FadeInanim"); // 재시작
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Note") || coll.gameObject.CompareTag("NoteCut"))
        {
            if(currentTime < 0.3f) // 만약 currenTime(누르고 있는 시간)이 0.3초 이하일 경우
            {
                NoteAttack(); 
                Debug.Log("Perfect!!");
                ScoreUI.Score += (10 * ComboUI.Combo); //점수에 10*콤보 수 적용
                GameObject PText = Instantiate(PerfectText); //Perfect 텍스트 생성
                PText.transform.position = TPos.position;
                coll.gameObject.tag = "NoteCut"; //충돌한 오브젝트의 태그를 NoteCut으로 변경


            }
            else if(currentTime < 0.8f)
            {
                NoteAttack();
                Debug.Log("Good!");
                ScoreUI.Score += (5 * ComboUI.Combo); //점수에 5*콤보 수 적용
                GameObject GText = Instantiate(GoodText); //Good 텍스트 생성
                GText.transform.position = TPos.position;
                coll.gameObject.tag = "NoteCut";

            }
            else
            {
                Debug.Log("Bad");
                ComboUI.Combo = 0;
                HpUI.Hp --;
               // Destroy(coll.gameObject);

            }
            
        }
    }
}
