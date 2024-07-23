using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float maxPlayerHealth = 100.0f;
    private float playerHealth;
    private bool isAlive;

    public GameObject cam;

    public GameObject projectilePrefab;
    public Transform spawner;

    public float projectileSpeed = 10.0f;
    public float projectileLifeDuration = 1.0f;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            isAlive = false;
            Death();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {
            Fire();
        }
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        //MOVEMENT
        float forwardMovement = Input.GetAxis("Vertical");

        float sideMovement = Input.GetAxis("Horizontal");


        Vector3 moveDir = new Vector3(sideMovement, forwardMovement, 0);
        Vector3 movement = moveDir * playerSpeed * Time.deltaTime;

        transform.Translate(movement);
    }

    void Death()
    {
        //die
    }

    void Fire()
    {
        canFire = false;
        Instantiate(projectilePrefab, spawner.position, Quaternion.identity);
    }
}
