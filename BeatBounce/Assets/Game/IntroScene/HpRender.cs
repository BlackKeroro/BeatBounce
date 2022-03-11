using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpRender : MonoBehaviour
{
    public int Hp;


    public GameObject[] Hpbar;

    float Dtime = 0.0f;
    float Atime = 1.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        Hp = 6;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dtime += Time.deltaTime;
        if (Hp == -1)
        {
            for( int i = 0; i < Hpbar.Length; i++)
            {
                Hpbar[i].gameObject.SetActive(true);
            }
            Hp = 6;

        }
        if (Dtime >= Atime)
        {
            Hpbar[Hp].SetActive(false);
            Hp--;
            Dtime = 0.0f;
        }


    }
}
