using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onstart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void OnHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
