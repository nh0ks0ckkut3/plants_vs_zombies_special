using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnpoint;
    public GameObject[] zombies;
    //public ZombieType[] zombieTypes;
    void SpawnZombie()
    {
        // trả về ngẫu nhiên 1 thứ tự trong 6 thứ tự
        int r = Random.Range(0, spawnpoint.Length);
        int rz = Random.Range(0, spawnpoint.Length);
        // tạo ra 1 zombie bản sao với 1 vị trí ngẫu nhiên
        GameObject myZombie = Instantiate(zombies[rz], spawnpoint[r].position, Quaternion.identity);
        //myZombie.GetComponent<Zombie>().type = zombieTypes[Random.Range(0,zombieTypes.Length)];
    }
    void Start()
    {
        //SpawnZombie();
        // gọi hàm SpawnZombie sau khi chạy màn chơi 6s thì hàm SpawnZombie sẽ chạy và  tiếp tục 5s lại gọi lại
        InvokeRepeating("SpawnZombie", 6, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
