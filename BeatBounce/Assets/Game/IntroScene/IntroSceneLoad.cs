using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneLoad : MonoBehaviour
{
    public GameObject IntroFD;
    IntroFade Fade;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        Fade = IntroFD.GetComponent<IntroFade>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnIntroStart()
    {
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);

        
        Invoke("Coroutine", 13f);
    }

    void Coroutine()
    {
        Fade.StartCoroutine("IntroStart");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
