using TMPro;
using UnityEngine;

public class PickUp: MonoBehaviour
{
    [SerializeField] GameObject weapon1, weapon2, trigger, buttonInteraction;
    TextMeshProUGUI textInteraction;

    private void Start()
    {
        textInteraction = buttonInteraction.GetComponent<TextMeshProUGUI>();

    }

    private void OnTriggerStay(Collider other)
    {
        textInteraction.enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            Destroy(trigger);
            textInteraction.enabled = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        textInteraction.enabled = false;
    }
}
