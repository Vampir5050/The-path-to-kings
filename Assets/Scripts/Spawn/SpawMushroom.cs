using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawMushroom : MonoBehaviour
{
    [SerializeField] GameObject mushrooms;
    public List<Transform> SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            
            Instantiate(mushrooms, SpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}

