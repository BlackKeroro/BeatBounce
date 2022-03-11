using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPrefab : MonoBehaviour
{
    float RTime = 0.0f;
    float LTime = 0.0f;
    public GameObject []Note;
    GameObject rnd;
    public GameObject [] RightPos;
    public GameObject[] LeftPos;
    public float RD;
    public float LD;
    // Start is called before the first frame update
    void Start()
    {
       RD = Random.Range(2.0f, 3.0f);
       LD = Random.Range(3.0f, 5.0f);
    }

// Update is called once per frame
void Update()
    {
        RTime += Time.deltaTime;
        LTime += Time.deltaTime;
        if (RTime > RD)
        {
            rnd = RightPos[UnityEngine.Random.Range(0, RightPos.Length)];
            GameObject A = Instantiate(Note[0]);
            A.transform.position = rnd.transform.position;
            A.transform.rotation = rnd.transform.rotation;
            RTime = 0.0f;
            RD = Random.Range(2.0f, 3.0f);
        }
        if(LTime > LD)
        {
            rnd = LeftPos[UnityEngine.Random.Range(0, LeftPos.Length)];
            GameObject A = Instantiate(Note[1]);
            A.transform.position = rnd.transform.position;
            A.transform.rotation = rnd.transform.rotation;
            LTime = 0.0f;
            LD = Random.Range(3.0f, 5.0f);
        }
    }
}
