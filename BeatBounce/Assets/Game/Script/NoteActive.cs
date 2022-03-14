using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActive : MonoBehaviour
{
    public float currentTime = 0.0f;
    public GameObject ComboFade;

    ComboUI CU;

    public GameObject PerfactText;
    public GameObject GoodText;
    public Transform TPos;

   // public Canvas Canvas;
    //public GameObject Perfact;

    // Start is called before the first frame update
    void Start()
    {
        CU = ComboFade.GetComponent<ComboUI>();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
    }

    /*public void PerfactText()
    {
        GameObject Perfacttxt = Instantiate(Perfact, transform.position, Quaternion.identity, Canvas.transform);
    }*/

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Note") || coll.gameObject.CompareTag("NoteCut"))
        {
            if(currentTime < 0.3f)
            {
                Debug.Log("Perfect!!");
                //PerfactText();
                ComboUI.Combo++;
                ScoreUI.Score += (10 * ComboUI.Combo);
                if(HpUI.Hp < 10)
                {
                    HpUI.UpHpbar++;
                }
                GameObject PText = Instantiate(PerfactText);
                PText.transform.position = TPos.position;
                CU.StopCoroutine("FadeInanim");
                CU.StartCoroutine("FadeInanim");
                coll.gameObject.tag = "NoteCut";


            }
            else if(currentTime < 0.8f)
            {
                Debug.Log("Good!");
                ComboUI.Combo++;
                ScoreUI.Score += (5 * ComboUI.Combo);
                if (HpUI.Hp < 10)
                {
                    HpUI.UpHpbar++;
                }
                GameObject GText = Instantiate(GoodText);
                GText.transform.position = TPos.position;
                CU.StopCoroutine("FadeInanim");
                CU.StartCoroutine("FadeInanim");
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
