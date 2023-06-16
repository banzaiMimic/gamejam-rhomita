using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int qualitySelection;

    void Start()
    {
        qualitySelection = PlayerPrefs.GetInt("numCalidad", 3);
        dropdown.value = qualitySelection;
        CustomQuality();
    }

    public void CustomQuality() { 
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numcalidad", dropdown.value);
        qualitySelection = dropdown.value;
    }
}
