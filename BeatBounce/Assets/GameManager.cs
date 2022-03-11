using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float LightTime = 0.0f;
    float LStart = 3.0f;

    public GameObject Light;
    public Transform LPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightTime += Time.deltaTime;
        if(LightTime >= LStart)
        {
            GameObject LS = Instantiate(Light);
            LS.transform.position = LPos.transform.position;
            LightTime = 0.0f;
        }
    }
}
