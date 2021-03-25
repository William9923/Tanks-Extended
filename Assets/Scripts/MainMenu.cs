using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volumeValue"));
    }
    
    public void QuitGame()
    {
        PlayerPrefs.Save();

        UnityEditor.EditorApplication.isPlaying = false;
        
        Application.Quit();
    }
}
