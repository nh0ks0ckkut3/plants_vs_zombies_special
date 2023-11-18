using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{

    public Transform[] spawnpoint;


    public GameObject Zombie;
    private void Start()
    {
        InvokeRepeating("SpawnZombie", 2, 1);
    }
    void SpawnZombie()
    {
        int r = Random.Range(0, spawnpoint.Length);
        GameObject myZombie = Instantiate(Zombie, spawnpoint[r].position, Quaternion.identity);
    }
}
