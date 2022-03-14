using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Perfect : MonoBehaviour
{
    private float moveSpeed;
    private float destroyTime;
    private float alphaSpeed;
    TextMeshPro text;
    Color alpha;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.0f;
        destroyTime = 2.0f;
        alphaSpeed = 2.0f;

        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        Invoke("DestroyObject", destroyTime);
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        text.color = alpha;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
