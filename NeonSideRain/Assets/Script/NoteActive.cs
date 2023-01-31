using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActive : MonoBehaviour
{

    public float currentTime = 0.0f;//Ű �Է� �ð� üũ
    public GameObject ComboFade;//COmboUI�� �ִ� ���� �Ŵ���

    ComboUI CU; //�޺� Fade������ ���� UI�޾ƿ���

    public GameObject PerfectText; //Pertect�ؽ�Ʈ
    public GameObject GoodText; //Good �ؽ�Ʈ
    public Transform TPos; //������ �ؽ�Ʈ ��ġ

    void Start()
    {
        CU = ComboFade.GetComponent<ComboUI>();

    }

    // Update is called once per frame
    void Update()
    {
        //�ش� ������Ʈ Ȱ��ȭ �� ����
        currentTime += Time.deltaTime;
    }

    /*public void PerfactText()
    {
        GameObject Perfacttxt = Instantiate(Perfact, transform.position, Quaternion.identity, Canvas.transform);
    }*/

      void NoteAttack()
    {
        ComboUI.Combo++; //�޺� �� ����
        if (HpUI.Hp < 10) // ü���� 10 ������ ���
        {
            HpUI.UpHpbar++; //ü�� ����� ���� ���� ����(UPHpbar = 10 �� �� Hp ����)
        }
        CU.StopCoroutine("FadeInanim"); //����ǰ� �ִ� �ڷ�ƾ ����
        CU.StartCoroutine("FadeInanim"); // �����
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Note") || coll.gameObject.CompareTag("NoteCut"))
        {
            if(currentTime < 0.3f) // ���� currenTime(������ �ִ� �ð�)�� 0.3�� ������ ���
            {
                NoteAttack(); 
                Debug.Log("Perfect!!");
                ScoreUI.Score += (10 * ComboUI.Combo); //������ 10*�޺� �� ����
                GameObject PText = Instantiate(PerfectText); //Perfect �ؽ�Ʈ ����
                PText.transform.position = TPos.position;
                coll.gameObject.tag = "NoteCut"; //�浹�� ������Ʈ�� �±׸� NoteCut���� ����


            }
            else if(currentTime < 0.8f)
            {
                NoteAttack();
                Debug.Log("Good!");
                ScoreUI.Score += (5 * ComboUI.Combo); //������ 5*�޺� �� ����
                GameObject GText = Instantiate(GoodText); //Good �ؽ�Ʈ ����
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
