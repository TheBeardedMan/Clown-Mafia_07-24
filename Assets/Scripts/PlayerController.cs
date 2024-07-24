using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float maxPlayerHealth = 100.0f;
    private float playerHealth;
    private bool isAlive;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = maxPlayerHealth;
        isAlive = true;
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            isAlive = false;
            Death();
        }

        //MOVEMENT
        float forwardMovement = Input.GetAxis("Vertical");
        float sideMovement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(sideMovement * playerSpeed, forwardMovement * playerSpeed);
    }

    void Death()
    {
        //die
    }
}
