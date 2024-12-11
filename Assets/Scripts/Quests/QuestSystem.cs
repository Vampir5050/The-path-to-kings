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

    List<string> quests = new List<string>();
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

        //CheckingQuestCompletion();
    }

    //private void CheckingQuestCompletion()
    //{
    //    if (quests.Count != 0)
    //    {
    //        int count = InventorySystem.Instance.CheckCountItemName(quests[0]);
    //        if (count == 5)
    //        {
    //            PlayerPrefs.SetInt(quests[0], 2);
    //            InventorySystem.Instance.RemoveItems(count, quests[0]);

    //        }
    //    }
       
        
    //}

    public void GetQuest(string questName, string title,string description)
    {
        if (questName != "")
        {
            quests.Add(questName);
            image.SetActive(true);
            imageTitle.text = title;
            imageDescriprion.text = description;
        }
    }

}
