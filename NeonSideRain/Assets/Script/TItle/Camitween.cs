using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camitween : MonoBehaviour
{

    public GameObject Sound;
    AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = Sound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cam()//���� ���� �� ����
    {
        //iTween�� �̿��Ͽ� ī�޶� �̿��Ͽ� MoveTo(���� ��ġ�� �̵�)�� z 308���� �̵�, 2�� �� �����ϸ�, 17�ʿ� ���� �̵��Ѵ�
        iTween.MoveTo(gameObject, iTween.Hash("z", 308, "delay", 2f, "time", 17, "easetype", iTween.EaseType.easeInCirc, "speed", 25));
    }


}
