using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; set; }

    public GameObject masterValue;
    public GameObject musicValue;
    public GameObject effectValue;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }
    private void Update()
    {
        masterValue.GetComponent<TextMeshProUGUI>().text = "" + (masterSlider.value) + "";
        musicValue.GetComponent<TextMeshProUGUI>().text = "" + (musicSlider.value) + "";
        effectValue.GetComponent<TextMeshProUGUI>().text = "" + (effectsSlider.value) + "";
        SoundManager.Instance.startingMenuAndPause.volume = masterSlider.value / 100;
    }
}
