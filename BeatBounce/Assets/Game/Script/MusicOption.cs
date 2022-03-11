using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOption : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource[] audioSource;
    /* public AudioSource audio2;
     public AudioSource audio3;
     public AudioSource audio4;*/

    public GameObject Menu; // 노래 선택 창의 오브젝트 받아오기
    MenuSong MS;


    private float backVol = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        MS = Menu.GetComponent<MenuSong>();

        backVol = PlayerPrefs.GetFloat("backVol", 1f);
        backVolume.value = backVol;
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = backVolume.value;
            MS.SelectSong[i].volume = backVolume.value;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Soundslider();
    }

    public void Soundslider()
    {
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backVol", backVol);
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = backVolume.value;
            MS.SelectSong[i].volume = backVolume.value;

        }
    }
}
