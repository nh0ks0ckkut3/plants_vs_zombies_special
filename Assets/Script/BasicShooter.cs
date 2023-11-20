using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    //public Transform shootOrigin;

    public float cooldown; // thời gian

    private bool canShoot;

    /*public float range;*/// độ xa đạn bắn ra

   /* public LayerMask shootMask;*/// pha chạm collider 

    //private GameObject target;

    public int health = 4;


    //private int maxBullets = 5;
    //private int currentBullets = 0;
    private void Start()
    {
        // sau 4s thì hàm này thực hiện
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit2D kiểm tra xem có va chạm hay không
        //
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);

        //if (hit.collider)
        //{
        //    // khi có Gameobject chứa target xuất hiện thì thực hiện hàm này
        //    target = hit.collider.gameObject;
        //    Shoot();
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (currentBullets < maxBullets)
        //    {
        //        StartCoroutine(FireBullet());
        //    }
        //}
    }

    private void ResetCooldown()
    {
        canShoot = true;
    }
    void Shoot()
    {
        //if (!canShoot)
        //    return;

        //canShoot = false;
        //Invoke("ResetCooldown", cooldown);

        //// tạo ra viên đạn
        //GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);



        GameObject bullet_drag = Instantiate(bullet, new Vector3(transform.position.x + 0.1f, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
        Destroy(bullet_drag, 6f);
        InvokeRepeating("Shoot", cooldown, 0f);
    }

    //IEnumerator FireBullet()
    //{
    //    GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    //    currentBullets++;
    //    // chờ đợi 
    //    yield return new WaitForSeconds(4f);

    //    Destroy(myBullet);
    //    currentBullets--;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("abc");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("abc2");
    }
}
