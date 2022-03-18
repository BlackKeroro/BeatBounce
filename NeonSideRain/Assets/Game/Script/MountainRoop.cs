using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainRoop : MonoBehaviour
{
    public float Speed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 vec = new Vector3(0, 0, -Speed);
        transform.Translate(vec);

        if(transform.position.z <= -13.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 80.6f);
        }
    }
}
