using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawMushroom : MonoBehaviour
{
    [SerializeField] GameObject mushroom;
    public List<Transform> SpawnPoints;

    private void Awake()
    {
        Spawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            Instantiate(mushroom, SpawnPoints[i].transform.position, Quaternion.identity);
            
        }
    }
}

