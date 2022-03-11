using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    Image Image;

    
    MusicManager MM;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    void Start()
    {
        Image = GetComponent<Image>();
        MM = GameObject.Find("MusicVoice").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public IEnumerator FadeOut()
    {
        int ImageColor = 20;
        for (int i = 20; i > 0f; i--)
        {
            ImageColor--;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)ImageColor / 20);
            yield return new WaitForSeconds(0.1f);
            Debug.Log("∆‰¿ÃµÂ æ∆øÙ");

        }
        gameObject.SetActive(false);
    }

    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(7.0f);
        int InColor = 0;
        for (int a = 0; a < 20f; a++)
        {
            InColor++;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)InColor / 20);
            yield return new WaitForSeconds(0.1f);

        }
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);

    }
    public IEnumerator FadeDie()
    {
        int InColor = 0;
        for (int a = 0; a < 20f; a++)
        {
            InColor++;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, (float)InColor / 20);
            yield return new WaitForSeconds(0.1f);

        }
        GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        MM.Song[MM.SongList].Stop();

        }



}
