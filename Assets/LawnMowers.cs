using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LawnMowers : MonoBehaviour
{
    
    public float speed;
  
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        // Xử lý khi lawnmower va chạm với zombie
        if (other.CompareTag("zombie"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("detroy"))
        {
            Destroy(gameObject);
        }
    }


    }

