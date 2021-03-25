using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class OptionPref : MonoBehaviour
{
    InputField playerOneName, playerTwoName;
    Slider volumeSlider;

    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        playerOneName = GameObject.Find("PlayerOneInput").GetComponent<InputField>();
        playerTwoName = GameObject.Find("PlayerTwoInput").GetComponent<InputField>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        if (PlayerPrefs.HasKey("playerOneName"))
        {
            playerOneName.text = PlayerPrefs.GetString("playerOneName");
        }
        if (PlayerPrefs.HasKey("playerTwoName"))
        {
            playerTwoName.text = PlayerPrefs.GetString("playerTwoName");
        }
        if (PlayerPrefs.HasKey("volumeValue"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volumeValue");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        PlayerPrefs.SetString("playerOneName", playerOneName.text);
        PlayerPrefs.SetString("playerTwoName", playerTwoName.text);
        PlayerPrefs.SetFloat("volumeValue", volumeSlider.value);
        PlayerPrefs.Save();
    }

    public void setVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
