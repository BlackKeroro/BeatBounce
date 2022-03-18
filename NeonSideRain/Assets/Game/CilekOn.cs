using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilekOn : MonoBehaviour
{

    public GameObject Next;
    public GameObject Previous;
    public GameObject InPueseExit;
    public GameObject OverRestart;
    public GameObject OverHome;
    public GameObject PueseRestart;
    public GameObject PueseHome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextOn()
    {
        Next.SetActive(true);
    }
    public void NextOut()
    {
        Next.SetActive(false);
    }
    public void PreviousOn()
    {
        Previous.SetActive(true);
    }
    public void PreviousOut()
    {
        Previous.SetActive(false);
    }
    public void InPueseOn()
    {
        InPueseExit.SetActive(true);
    }
    public void InPueseOut()
    {
        InPueseExit.SetActive(false);
    }

    public void OverRestartOn()
    {
        OverRestart.SetActive(true);

    }
    public void OverRestartOut()
    {
        OverRestart.SetActive(false);

    }
    public void OverHomeOn()
    {
        OverHome.SetActive(true);
    }
    public void OverHomeOut()
    {
        OverHome.SetActive(false);
    }
    public void PueseRestartOn()
    {
        PueseRestart.SetActive(true);
    }
    public void PueseRestartOut()
    {
        PueseRestart.SetActive(false);
    }
    public void PueseHomeOn()
    {
        PueseHome.SetActive(true);
    }
    public void PueseHomeOut()
    {
        PueseHome.SetActive(false);
    }
}
