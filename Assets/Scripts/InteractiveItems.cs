using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveItems : MonoBehaviour
{
    [SerializeField] GameObject triger;
    [SerializeField] GameObject buttonInteraction;
    [SerializeField] string ItemName;
    TextMeshProUGUI textInteraction;
    
    private void Start()
    {
        buttonInteraction = GameObject.Find("/Canvas/ButtonInteraction");
        textInteraction = buttonInteraction.GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerStay(Collider other)
    {
        textInteraction.enabled = true;
        if (Input.GetKey(KeyCode.E))
        {
            if (!InventorySystem.Instance.CheckIfFull())
            {
               
                InventorySystem.Instance.AddToInventory(ItemName);
                SoundManager.Instance.PlayPickupSound();
                Destroy(triger);
                textInteraction.enabled = false;

            }
            
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        textInteraction.enabled = false;
    }
   
     
}
