using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConfigQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int qualitySelection;

    void Start()
    {
        SFXManager.INSTANCE.init();
        qualitySelection = PlayerPrefs.GetInt("numCalidad", 3);
        dropdown.value = qualitySelection;
        CustomQuality();
    }

    public void CustomQuality() { 
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numcalidad", dropdown.value);
        qualitySelection = dropdown.value;
    }

    public void OnChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
