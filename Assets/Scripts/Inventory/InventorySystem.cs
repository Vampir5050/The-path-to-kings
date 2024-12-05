using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;
    public List<GameObject> slotList = new List<GameObject>();
    public List<string> itemList = new List<string>();

    GameObject itemAdd, slotToEquip;

    //Pickup
    [SerializeField] GameObject pickupAllert;
    [SerializeField] TextMeshProUGUI pickupName;
    [SerializeField] Image pickupImage;

     bool isOpen;


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


    void Start()
    {
        PopulateSlotList();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Cursor.visible = true;
            Debug.Log("i is pressed");
            inventoryScreenUI.SetActive(true);
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            Cursor.visible = false;
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }

    void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform)
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }

    public bool CheckIfFull()
    {
        int counter = 0;
        foreach(GameObject slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                counter++;
            }
        }
        if (counter == slotList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddToInventory(string ItemName)
    {

            slotToEquip = NextEmptySlot();
            itemAdd = Instantiate(Resources.Load<GameObject>(ItemName), slotToEquip.transform.position, slotToEquip.transform.rotation);
            itemAdd.transform.SetParent(slotToEquip.transform);
            itemList.Add(ItemName);

        TriggerPickupPopUp(ItemName, itemAdd.GetComponent<Image>().sprite);



    }

    private GameObject NextEmptySlot()
    {
        foreach(GameObject slot in slotList)
        {
            if(slot.transform.childCount == 0)
            {
                return slot;
            }

        }
        return new GameObject();
    }

    void TriggerPickupPopUp(string itemName,Sprite itemSprite)
    {
        
        pickupName.text = "Вы подобрали - " + itemName;
        pickupImage.sprite = itemSprite;
        pickupAllert.GetComponent<Animation>().Play("PickupPopUp");
    }
}