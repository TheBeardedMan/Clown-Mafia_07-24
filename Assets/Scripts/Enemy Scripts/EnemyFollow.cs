using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Transform target;
    public float moveSpeed = 3f;
    public string targetTag = "Player";

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    public void Update()
    {
        if (target.gameObject == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
