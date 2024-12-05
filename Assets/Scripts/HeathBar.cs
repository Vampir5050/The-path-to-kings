using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI healthCounter;
    [SerializeField] GameObject playerState;
    Slider slider;

    float currentHealth, maxHealth;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    
    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHealth + "/" + maxHealth;
    }
}
