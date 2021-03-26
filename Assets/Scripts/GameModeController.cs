using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeController : MonoBehaviour
{
    private Button map1Button, map2Button, mode1Button, mode2Button, playButton;
    private int selectedMap;
    private int selectedMode;
    // Start is called before the first frame update
    void Start()
    {
        map1Button = GameObject.Find("Map1Button").GetComponent<Button>();
        map2Button = GameObject.Find("Map2Button").GetComponent<Button>();
        mode1Button = GameObject.Find("Mode1Button").GetComponent<Button>();
        mode2Button = GameObject.Find("Mode2Button").GetComponent<Button>();
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        map1Button.onClick.AddListener(Map1OnClick);
        map2Button.onClick.AddListener(Map2OnClick);
        mode1Button.onClick.AddListener(Mode1OnClick);
        mode2Button.onClick.AddListener(Mode2OnClick);
        
        playButton.gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Map1OnClick()
    {
        ColorBlock cbSelect = map1Button.colors;
        ColorBlock cbUnselect = map2Button.colors;

        cbSelect.normalColor = new Color32(44, 98, 25, 255);
        cbSelect.selectedColor = new Color32(44, 98, 25, 255);
        cbUnselect.normalColor = new Color32(255, 255, 255, 255);
        cbUnselect.selectedColor = new Color32(255, 255, 255, 255);

        map1Button.colors = cbSelect;
        map2Button.colors = cbUnselect;

        selectedMap = 1;
        if((selectedMap != 0) & (selectedMode!= 0)){
            playButton.gameObject.SetActive(true);
        }
    }

    void Map2OnClick()
    {
        ColorBlock cbSelect = map2Button.colors;
        ColorBlock cbUnselect = map1Button.colors;

        cbSelect.normalColor = new Color32(44, 98, 25, 255);
        cbSelect.selectedColor = new Color32(44, 98, 25, 255);
        cbUnselect.normalColor = new Color32(255, 255, 255, 255);
        cbUnselect.selectedColor = new Color32(255, 255, 255, 255);

        map2Button.colors = cbSelect;
        map1Button.colors = cbUnselect;

        selectedMap = 2;

        if ((selectedMap != 0) & (selectedMode != 0))
        {
            playButton.gameObject.SetActive(true);
        }
    }

    void Mode1OnClick()
    { 
        ColorBlock cbSelect = mode1Button.colors;
        ColorBlock cbUnselect = mode2Button.colors;

        cbSelect.normalColor = new Color32(44, 98, 25, 255);
        cbSelect.selectedColor = new Color32(44, 98, 25, 255);
        cbUnselect.normalColor = new Color32(255, 255, 255, 0);
        cbUnselect.selectedColor = new Color32(255, 255, 255, 0);

        mode1Button.colors = cbSelect;
        mode2Button.colors = cbUnselect;

        selectedMode = 1;

        if ((selectedMap != 0) & (selectedMode != 0))
        {
            playButton.gameObject.SetActive(true);
        }
    }

    void Mode2OnClick()
    {
        ColorBlock cbSelect = mode2Button.colors;
        ColorBlock cbUnselect = mode1Button.colors;

        cbSelect.normalColor = new Color32(44, 98, 25, 255);
        cbSelect.selectedColor = new Color32(44, 98, 25, 255);
        cbUnselect.normalColor = new Color32(255, 255, 255, 0);
        cbUnselect.selectedColor = new Color32(255, 255, 255, 0);

        mode2Button.colors = cbSelect;
        mode1Button.colors = cbUnselect;

        selectedMode = 2;

        if ((selectedMap != 0) & (selectedMode != 0))
        {
            playButton.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        Debug.Log("Map " + selectedMap + " Mode " + selectedMode);
        int mapAddition = selectedMap == 1 ? 0 : 2;
        int sceneActivated = SceneManager.GetActiveScene().buildIndex + mapAddition + selectedMode;
        SceneManager.LoadScene(sceneActivated);
        Debug.Log("Load Scene " + sceneActivated);
        
    }
}
