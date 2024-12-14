using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance { get; set; }

    string _questName = "";
    [SerializeField] GameObject image;
    [SerializeField] TextMeshProUGUI imageTitle, imageDescriprion;

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

        
    }

    public void GetQuest(string questName, string title,string description)
    {
        if (questName != "")
        {
            _questName = questName;
            image.SetActive(true);
            imageTitle.text = title;
            imageDescriprion.text = description;
        }
    }
    public string CheckQuest()
    {
        if (_questName == "")
            return "";
        else
        {
            return _questName;
        }
    }
    public bool CheckQuestComplited()
    {
        if (InventorySystem.Instance.CheckCountItemName(_questName) >= 5)
        {
            
            return true;
        }
        return false;
    }
    public void DestroyQuest()
    {
        _questName = "";
        image.SetActive(false);
    }

}
