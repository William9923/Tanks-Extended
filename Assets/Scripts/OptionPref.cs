using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPref : MonoBehaviour
{
    InputField playerName;
    Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GameObject.Find("PlayerNameInput").GetComponent<InputField>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        if (PlayerPrefs.HasKey("playerName"))
        {
            playerName.text = PlayerPrefs.GetString("playerName");
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
        PlayerPrefs.SetString("playerName", playerName.text);
        PlayerPrefs.SetFloat("volumeValue", volumeSlider.value);
        PlayerPrefs.Save();
    }
}
