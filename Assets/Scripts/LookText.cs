 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookText : MonoBehaviour
{
    [SerializeField] GameObject hero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(hero.transform.position * Time.deltaTime);
    }
}
