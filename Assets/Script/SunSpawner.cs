using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sunObject;
    private game_manager game_Manager;
    void Start()
    {
        game_Manager = game_manager.instance;
        
    }

    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(Random.Range(-7.44f, 7.44f), 6, 0), Quaternion.identity);
        mySun.GetComponent<sunScripts>().dropToYPos = Random.Range(1f, -3.5f);
        Invoke("SpawnSun", Random.Range(4, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if(game_Manager.isStart)
        {
            SpawnSun();
        }
    }
}
