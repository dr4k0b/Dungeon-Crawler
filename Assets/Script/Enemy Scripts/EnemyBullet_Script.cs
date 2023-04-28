using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyBullet_Script : MonoBehaviour
{
    [SerializeField] GameObject p;
    Vector2 target;
    Vector2 StartPos;
    void Start()
    {
        target = p.transform.position;
        StartPos = transform.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(StartPos, target, 5f);
    }
}