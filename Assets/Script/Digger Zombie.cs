using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DiggerZombie : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;
    public float eatCooldown;
    private bool isRun = false;
    private bool isDig = true;
    private game_manager gameManager;
    private Vector3 vector3;
    private bool canEat = true;
    public Plant targetPlant;
    private Animator zombieAnimator;// Tham chiếu tới Animator của zombie

    void Start()
    {
        gameManager = game_manager.instance;
        zombieAnimator = GetComponent<Animator>();
        if (gameManager.isRoofMap)
        {
            vector3 = new UnityEngine.Vector3(-1, -0.11f, 0);
        }
        else
        {
            vector3 = UnityEngine.Vector3.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDig)
        {
            transform.Translate(vector3 * speed * Time.deltaTime);
        }
        if (isRun)
        {
            transform.Translate(-vector3 * speed * Time.deltaTime);
        }
        if (health == 0)
        {
            gameManager.sound_die.Play();
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("turning"))
        {
            
            appear();
            

        }
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
    void appear()
    {
        Debug.Log("truoc");
        zombieAnimator.SetInteger("RiggerZombie_Status", 1);
        Debug.Log("sau");
        Invoke("DoSomethingElse", 0.5f);
        isDig = false;

    }
    void DoSomethingElse()
    {
        // Hành động tiếp theo ở đây
        zombieAnimator.SetInteger("RiggerZombie_Status", 2);
        speed = speed - 0.5f;
        isRun = true;
    }
    void ResetEatCooldown()
    {
        canEat = true;
    }
}
