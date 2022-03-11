using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroFade : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator IntroStart()
    {
        float InColor = 0;
        for (int a = 0; a < 20f; a++)
        {
            InColor++;
            image.color = new Color(image.color.r, image.color.g, image.color.b, InColor / 20.0f);
            yield return new WaitForSeconds(0.1f);

        }
        SceneManager.LoadScene("GameMain");
    }
}
