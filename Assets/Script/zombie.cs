using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int health;
    public int damage;// mỗi lần ăn plant -1 máu
    public float range;
    //public ZombieType type;
    public LayerMask plantMask;
    public float eatCooldown;// thời gian 1s thì ăn tiếp
    private bool canEat = true;
    public Plant targetPlant;
    
    //private void Start()
    //{
    //    health = type.health; 
    //    speed = type.speed;
    //    damage = type.damage; 
    //    range = type.range; 

    //    // xác định hình ảnh được hiển thị  và type.sprite = lấy các thuộc tính bỏ vào hình ảnh đó
    //    GetComponent<SpriteRenderer>().sprite = type.sprite;
    //}

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider)
        {
            // tìm đến đối tượng component Plant 
            targetPlant = hit.collider.GetComponent<Plant>();
            Eat();
        }
        //if (health == 1)
        //{
        //    // chuyển đổi hình ảnh khi máu của Zombie = 1
        //    GetComponent<SpriteRenderer>().sprite = type.deathSprite;
        //}

    }

    void Eat()
    {
        // nếu đúng 1 trong 2 điều kiện thì hàm sẽ return không cho chạy hàm dưới
        if (!canEat || !targetPlant)
            return;
        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);

        targetPlant.Hit(damage);
    }

    void ResetEatCooldown()
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        if (!targetPlant)
            transform.position -= new Vector3(speed, 0, 0);
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
