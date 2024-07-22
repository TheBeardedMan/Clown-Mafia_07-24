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
    public GameObject spawner;
    public GameObject rotator;

    public float projectileSpeed = 10.0f;
    public float projectileLifeDuration = 1.0f;


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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
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
        Instantiate(projectilePrefab, spawner.transform.position, spawner.transform.rotation);
    }
}
