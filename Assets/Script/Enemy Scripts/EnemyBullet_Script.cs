using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyBullet_Script : MonoBehaviour
{
    [SerializeField] GameObject p;
    Rigidbody2D rb;
    public float Force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = p.transform.position - transform.position;
        rb.velocity = dir.normalized * Force ;
    }
    void Update()
    {

    }
}