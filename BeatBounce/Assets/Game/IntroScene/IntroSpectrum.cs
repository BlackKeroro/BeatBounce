using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSpectrum : MonoBehaviour
{    //public GameObject spectrumObj;
    public Transform Pos;
    public Transform Pos2;

    public int spectrumSize = 256;
    int SpectCnt;

    public Material Color;

    GameObject spectrumObj;

    GameObject spectrum2;

    // Start is called before the first frame update
    void Start()
    {
        spectrumObj = new GameObject("Spectrum");
        for (int i = 0; i < spectrumSize; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            spectrumObj.transform.position = Pos.transform.position;
            cube.transform.parent = spectrumObj.transform;
            cube.transform.localPosition = new Vector3(0, 0, 4f * i);
            cube.transform.localScale = new Vector3(4f, 3, 4f);
            cube.GetComponent<Renderer>().material = Color;

        }
        spectrum2 = new GameObject("Spect2");
        for (int i = 0; i < spectrumSize; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            spectrum2.transform.position = Pos2.transform.position;
            spectrum2.transform.rotation = Pos2.transform.rotation;
            cube.transform.parent = spectrum2.transform;
            cube.transform.localPosition = new Vector3(0, 0, 4.0f * i);
            cube.transform.localScale = new Vector3(4f, 3, 4f);
            cube.GetComponent<Renderer>().material = Color;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[spectrumSize];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);


        for (int i = 0; i < spectrumSize; i++)
        {
            spectrumObj.transform.GetChild(i).transform.localScale = new Vector3(4f, 110 * spectrum[i], 4f);
        }
        for (int i = 0; i < spectrumSize; i++)
        {
            spectrum2.transform.GetChild(i).transform.localScale = new Vector3(4f, 110 * spectrum[i], 4f);

        }

    }
}
