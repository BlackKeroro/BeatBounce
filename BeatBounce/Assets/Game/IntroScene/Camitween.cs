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

    public void Cam()
    {
        iTween.MoveTo(gameObject, iTween.Hash("z", 308, "delay", 2f, "time", 17, "easetype", iTween.EaseType.easeInCirc, "speed", 25));
        StartCoroutine("SongDown");
    }

    IEnumerator SongDown()
    {
        float S = 1.0f;
        yield return new WaitForSeconds(9.0f);
        while(S < 0.0f)
        {
            S -= 0.01f;
            Audio.volume = S;
            yield return new WaitForSeconds(0.01f);

        }
    }
}
