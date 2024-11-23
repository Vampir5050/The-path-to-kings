using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] GameObject triger, e;
   
    private void OnTriggerStay(Collider other)
    {


        e.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            Destroy(triger);
            e.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        e.SetActive(false);
    }
}
