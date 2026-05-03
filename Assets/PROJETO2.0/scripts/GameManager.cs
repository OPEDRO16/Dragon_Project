using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isMusicOn = true;

    public AudioSource music;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject exit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }

    public void TurnMusic()
    {
        if (isMusicOn)
        {
            isMusicOn = false;
            music.mute = true;
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            isMusicOn = true;
            music.mute = false;
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }

}
