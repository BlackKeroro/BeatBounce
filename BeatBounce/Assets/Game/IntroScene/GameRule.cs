using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameRule : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject RuleCanvas1;
    public GameObject RuleCanvas2;

    public GameObject ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameRule()
    {
        RuleCanvas1.SetActive(true);
        RuleCanvas2.SetActive(true);
        UICanvas.SetActive(false);
        GetComponent<HpRender>().enabled = true;
    }

    public void OutGameRull()
    {
        RuleCanvas1.SetActive(false);
        RuleCanvas2.SetActive(false);
        UICanvas.SetActive(true);
        ExitButton.SetActive(false);
        GetComponent<HpRender>().enabled = false;

    }
}
