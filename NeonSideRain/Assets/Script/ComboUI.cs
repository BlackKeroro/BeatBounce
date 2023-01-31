using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour
{
    public static int Combo;

    public GameObject Combotxt;

    Text txt;

    // Start is called before the first frame update
    void Awake()
    {
        Combo = 0;
        
        txt = Combotxt.GetComponent<Text>();


    }

    void Start()
    {
        StartCoroutine("FadeInanim");

    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Combo " + Combo;
    }
    public IEnumerator FadeInanim()
    {
         float fadeCount = 0.75f;
        while(fadeCount > 0.0f)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.1f);
            txt.color = new Color(1, 1, 1, fadeCount);


        }


    }

}
