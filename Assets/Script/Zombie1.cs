using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Zombie1 : MonoBehaviour
{
    public float speed;
  private float speedslow;
    public int health;
    public int damage;
    public float eatCooldown;
  public GameObject gameover;
    private bool isRun = true;

    private game_manager gameManager;
    private Vector3 vector3;
    private bool canEat = true;
    public Plant targetPlant;
    private Image image;

  void Start()
    {
        gameManager = game_manager.instance;
        if (gameManager.isRoofMap)
        {
            vector3 = new Vector3(-1, -0.11f, 0);
        }
        else
        {
            vector3 = Vector3.left;
        }
    speedslow = speed - 0.1f;
    image = GetComponent<Image>();
  }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            transform.Translate(vector3 * speed * Time.deltaTime);
        }
        if(health == 0) {
            gameManager.sound_die.Play();
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            isRun = false;
        }
        if (collision.CompareTag("bullet"))
        {
            gameManager.sound_bullet.Play();
            Destroy(collision.gameObject);
            health--;
        }
        if (collision.CompareTag("bullet_cold"))
        {
            gameManager.sound_bullet.Play();
            Destroy(collision.gameObject);
      health--;
      speed = speedslow;
            Invoke("khoiphuc", 1);

    }

    if (collision.CompareTag("LawnMower"))
        {
            LawnMowers lawnMowersComponent = collision.gameObject.GetComponent<LawnMowers>();

            if (lawnMowersComponent == null)
            {
                // Nếu chưa tồn tại, thêm mới
                collision.gameObject.AddComponent<LawnMowers>();
                gameManager.sound_lawnMower.Play();

            }

            // Sau đó, hủy GameObject hiện tại
            Destroy(gameObject);
        }
        if (collision.CompareTag("GameOver"))
        {
            gameManager.sound_gameover.Play();
            //gameover.SetActive(true);
            //Time.timeScale = 0;
            Invoke("back", 3f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            targetPlant = collision.GetComponent<Plant>();
            Eat();
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
            isRun = true;
            
    }
    void Eat()
    {
        // nếu đúng 1 trong 2 điều kiện thì hàm sẽ return không cho chạy hàm dưới
        if (!canEat || !targetPlant)
            return;
        gameManager.sound_eat_plant.Play();
        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);

        targetPlant.Hit(damage);
    }
    void ResetEatCooldown()
    {
        canEat = true;
    }
  void khoiphuc()
  {
    speed = speedslow + 0.1f;

  }
  void back()
  {
    SceneManager.LoadScene("Welcome");
  }
}
