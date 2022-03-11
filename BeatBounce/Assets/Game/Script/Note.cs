using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

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
        transform.position += Vector3.back * speed * Time.deltaTime;

    }

}
