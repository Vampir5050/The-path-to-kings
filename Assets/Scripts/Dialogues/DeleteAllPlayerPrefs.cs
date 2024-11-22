
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

}
