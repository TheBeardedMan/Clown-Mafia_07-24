using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Vector2 bulletDirection = new Vector2(1,0);
    public float bulletSpeed = 5.0f;

    public Vector2 bulletVelocity;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        bulletVelocity = bulletDirection * bulletSpeed;

        Vector2 pos = transform.position;

        pos += bulletVelocity * Time.deltaTime;

        //transform.position = pos;
    }

    private void FixedUpdate()
    {

    }
}
