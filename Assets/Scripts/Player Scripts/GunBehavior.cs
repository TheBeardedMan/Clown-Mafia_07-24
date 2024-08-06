using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.VFX;

public class GunBehavior : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject projectilePrefab;
    public Transform spawner;
    Quaternion newRot;

    public float pelletCount = 4;
    public float spread = 30f;
    private float exitAngle = 0.8f;

    public float projectileLifeDuration = 1.0f;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    bool firing;

    public float kickBackAmount = 20f;

    private void Start()
    {
        player = player.GetComponent<Rigidbody2D>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenFiring)
        {
            canFire = true;
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire)
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        
        if(firing)
        {
            Vector2 kickBackDirection = (player.transform.position - transform.position).normalized;
            player.AddForce(kickBackDirection * kickBackAmount, ForceMode2D.Impulse);
            firing = false;
        }
    }

    void Fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            canFire = false;
            timer = 0;

            float addedOffset = (i - (pelletCount / 2) * exitAngle);

            newRot = Quaternion.Euler(spawner.eulerAngles.x,
                spawner.eulerAngles.y,
                spawner.eulerAngles.z + (spread * addedOffset));

            GameObject bullet0 = Instantiate(projectilePrefab, spawner.position, newRot);

            Destroy(bullet0, projectileLifeDuration);
        }

        firing = true;
    }
}