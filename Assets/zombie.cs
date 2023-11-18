using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float speed;

    public int health;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }

    public void hit (int damage)
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
