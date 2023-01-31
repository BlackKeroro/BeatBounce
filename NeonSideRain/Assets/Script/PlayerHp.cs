using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    HpUI Hp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Note"))
        {
            ComboUI.Combo = 0;
            HpUI. Hp--;
            Destroy(coll.gameObject);

        }
        if (coll.gameObject.CompareTag("NoteCut"))
        {

            Destroy(coll.gameObject);
        }
    }
}
