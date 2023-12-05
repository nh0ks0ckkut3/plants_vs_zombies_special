using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieNhayXao : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;
    public float eatCooldown;
    private bool isRun = true;
    private bool FirstPlant = true; // theo logic zombie này sẽ bỏ qua plant đầu thay đổi speed, trở thành zombie thường
    private game_manager gameManager;
    private UnityEngine.Vector3 vector3;
    private bool canEat = true;
    public Plant targetPlant;
    private Animator zombieAnimator;// Tham chiếu tới Animator của zombie


    void Start()
    {
        gameManager = game_manager.instance;
        if (gameManager.isRoofMap)
        {
            vector3 = new UnityEngine.Vector3(-1, -0.11f, 0);
        }
        else
        {
            vector3 = UnityEngine.Vector3.left;
        }
        zombieAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            transform.Translate(vector3 * speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            gameManager.sound_die.Play();
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
           
            if (FirstPlant)
            {
                Collider2D collider1 = GetComponent<Collider2D>(); // Collider của đối tượng hiện tại
                Collider2D collider2 = collision; // Collider của đối tượng bạn muốn bỏ qua va chạm

                Physics2D.IgnoreCollision(collider1, collider2);
                jump();
            }
            else
            {
                isRun = false;
            }
        }
        
        if (collision.CompareTag("bullet"))
        {
            gameManager.sound_bullet.Play();
            Destroy(collision.gameObject);
            health--;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("plant") && FirstPlant== false)
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
    void jump()
    {
        
        // code nhảy

        //animation
        zombieAnimator.SetInteger("PoleValtingZombie_status", 1);
        Invoke("DoSomethingElse", 0.5f);


    }
    void DoSomethingElse()
    {
        // Hành động tiếp theo ở đây
        zombieAnimator.SetInteger("PoleValtingZombie_status", 0);
        speed = speed - 0.5f;
        FirstPlant = false;
    }
}
