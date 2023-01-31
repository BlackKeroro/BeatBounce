using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour
{
    NoteActive DD, FD, SD, JD, KD;
    GameObject DB, FB, SB, JB, KB;

    // Start is called before the first frame update
    void Start()
    {
        DB = GameObject.Find("DCode");
        DD = DB.GetComponent<NoteActive>();
        FB = GameObject.Find("FCode");
        FD = FB.GetComponent<NoteActive>();
        SB = GameObject.Find("Space");
        SD = SB.GetComponent<NoteActive>();
        JB = GameObject.Find("JCode");
        JD = JB.GetComponent<NoteActive>();
        KB = GameObject.Find("KCode");
        KD = KB.GetComponent<NoteActive>();
        chiledfalse();
    }
    void chiledfalse()
    {
        for(int i = 0; i<5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DButton();
        FButton();
        SpaceButton();
        JButton();
        KButton();
    }

    void DButton()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            DD.currentTime = 0.0f;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void FButton()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            FD.currentTime = 0.0f;
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void SpaceButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SD.currentTime = 0.0f;
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    void JButton()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            JD.currentTime = 0.0f;
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    void KButton()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.GetChild(4).gameObject.SetActive(true);
            Debug.Log("K½ÇÇà");
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            KD.currentTime = 0.0f;
            transform.GetChild(4).gameObject.SetActive(false);
            Debug.Log("K´ÝÀ½");

        }
    }

}
