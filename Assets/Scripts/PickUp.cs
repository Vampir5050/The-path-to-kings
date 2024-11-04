using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp: MonoBehaviour
{
    [SerializeField] GameObject weapon1, weapon2, trigger, e;

    private void OnTriggerStay(Collider other)
    {
        e.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            trigger.SetActive(false);
            e.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        e.SetActive(false);
    }
}
