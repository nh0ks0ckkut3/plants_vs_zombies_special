using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage;

    public float speed = 0.8f;
  public bool isLeft;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (isLeft)
    {
      transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0));
    }
    else
    {
      transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
    }
        
        //transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Zombie>(out Zombie zombie))
        {
            zombie.Hit(damage);
            Destroy(gameObject);
        }
    }
}
