using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSlashPrefab : MonoBehaviour
{
    float DT = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DT += Time.deltaTime;
        if (DT > 0.5f)
            Destroy(gameObject);
    }
}
