using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public Animator ani;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            ani.Play("deathAni");
        }
    }
}
