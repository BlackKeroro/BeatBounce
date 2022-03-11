using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroNote : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        speed = Random.Range(2.0f, 4.0f);
        int r = Random.Range(0, 3);
        Color c = Color.white;
        if (r == 0)
        {
            c = Color.red;
        }
        else if (r == 1)
        {
            c = Color.blue;
        }
        else if (r == 2)
        {
            c = Color.green;
        }
        mr.material.SetColor("_EmissionColor", c);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        Invoke("OnDestroy", 15.0f);

    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}

