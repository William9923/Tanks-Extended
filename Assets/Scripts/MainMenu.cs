using UnityEngine;
using UnityEngine.Audio;

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
