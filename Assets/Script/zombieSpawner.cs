using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnpoint;
    public GameObject[] zombies;
  private game_manager gameManager;
  private bool isStart;
  //public ZombieType[] zombieTypes;
  public void Start()
  {
    gameManager = game_manager.instance;
    // gọi hàm SpawnZombie sau khi chạy màn chơi 6s thì hàm SpawnZombie sẽ chạy và  tiếp tục 5s lại gọi lại
    InvokeRepeating("SpawnZombie", 6, 5);
  }
  public void Update()
  {
    isStart = gameManager.isStart;
    
    
  }
  void SpawnZombie()
    {
      if(isStart)
    {
      int rz = Random.Range(0, zombies.Length);
      int r;
      if (rz == 3 || rz == 4)
      {
        r = Random.Range(0, 1);
        r += 2;
      }
      else
      {
        r = Random.Range(0, spawnpoint.Length);
        if (r == 2)
        {
          r = 1;
        }else if (r == 3)
        {
          r = 5;
        }
            
      }

      // tạo ra 1 zombie bản sao với 1 vị trí ngẫu nhiên
      GameObject myZombie = Instantiate(zombies[rz], spawnpoint[r].position, Quaternion.identity);
      //myZombie.GetComponent<Zombie>().type = zombieTypes[Random.Range(0,zombieTypes.Length)];
    }

  }
}
