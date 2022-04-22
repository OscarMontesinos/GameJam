using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public  Slider sliderVolume;
    public static string LoadScene;
    public GameObject options;

    public void Continue()
    {
        SceneManager.LoadScene(LoadScene);
    }

    public void NewGame()
    {
        LoadScene = "Casa";
        SceneManager.LoadScene(LoadScene);
    }
    public void Options() 
    {
        options.SetActive(!options.activeSelf);
    }

    public void ChangeVolume()
    {
        AudioManager.Instance.volume = sliderVolume.value;
        AudioManager.Instance.PlaySong("Test");
    }
}
