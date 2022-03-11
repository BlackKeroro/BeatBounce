using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject noteObjPrefab;

    float currentTime = 0.0f;
    public float createTime = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        createTime += 1.0f + Random.Range(0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            NoteCreate();
                createTime += 1.0f + Random.Range(0.0f, 2.0f);
            currentTime = 0.0f;
        }
    }
    void NoteCreate()
    {
        GameObject go = Instantiate(noteObjPrefab);
        go.transform.position = transform.position;
    
    }
}
