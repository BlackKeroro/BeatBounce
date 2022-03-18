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

    public void Cam()//게임 시작 시 실행
    {
        //iTween을 이용하여 카메라를 이용하여 MoveTo(지정 위치로 이동)로 z 308으로 이동, 2초 후 시작하며, 17초에 걸쳐 이동한다
        iTween.MoveTo(gameObject, iTween.Hash("z", 308, "delay", 2f, "time", 17, "easetype", iTween.EaseType.easeInCirc, "speed", 25));
    }


}
