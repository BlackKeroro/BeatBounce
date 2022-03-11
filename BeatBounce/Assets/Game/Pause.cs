using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPause = false;
    public GameObject MV;
    MusicManager MM;
    public GameObject PU;
    public GameObject Menu;
    MenuSong MS;

     public GameObject ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        MM = MV.GetComponent<MusicManager>();
        MS = Menu.GetComponent<MenuSong>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPause == false)
        {
            Time.timeScale = 0;

            MM.Song[MM.SongList].Pause();
            PU.SetActive(true);
            isPause = true;
            Debug.Log("일시정지");
        }
    }

    public void OutPause()
    {
        MM.Song[MM.SongList].Play();
        Time.timeScale = 1;
            isPause = false;
            PU.SetActive(false);
        ExitButton.SetActive(false);
    }
}
