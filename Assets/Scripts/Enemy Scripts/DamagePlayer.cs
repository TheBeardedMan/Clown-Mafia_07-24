using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Player")
        { 
            Destroy(other);
        }
    }
}
