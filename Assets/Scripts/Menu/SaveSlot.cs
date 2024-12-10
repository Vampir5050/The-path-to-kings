using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    private Button button;
    private Button yesButton;
    private Button noButton;
    public GameObject alertUI;
    private TextMeshProUGUI buttonText;

    public int slotNumber;

    private void Awake()
    {
        button = GetComponent<Button>();
        yesButton = alertUI.transform.Find("YesButton").GetComponent<Button>();
        noButton = alertUI.transform.Find("NoButton").GetComponent<Button>();
        buttonText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            if (SaveManager.Instance.IsSlotEmpty(slotNumber))
            {
                SaveGameConfirmed();
            }
            else
            {
                DisplayAlert();
            }
        });
    }
    private void Update()
    {
        if (SaveManager.Instance.IsSlotEmpty(slotNumber))
        {
            buttonText.text = "Пусто";
        }
        else
        {

            buttonText.text = PlayerPrefs.GetString("Slot" + slotNumber + "Description");
        }
    }

    public void DisplayAlert()
    {
        alertUI.SetActive(true);
        yesButton.onClick.AddListener(() =>
        {
            SaveGameConfirmed();
            alertUI.SetActive(false);
        });
        noButton.onClick.AddListener(() =>
        {
            alertUI.SetActive(false);
        });
    }

    private void SaveGameConfirmed()
    {
        SaveManager.Instance.SaveGame(slotNumber);
        DateTime dt = DateTime.Now;
        string time = dt.ToString("dd-MM-yyyy HH.mm");

        string description = $"Saved Game {slotNumber} | {time}";
        buttonText.text = description;
        PlayerPrefs.SetString("Slot" + slotNumber + "Description",description);
        PlayerPrefs.Save();

        SaveManager.Instance.DeselectButton();
    }
}
