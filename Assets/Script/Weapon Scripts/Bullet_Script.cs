using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet_Script : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Hand;
    Vector2 Direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Hand = GameObject.FindGameObjectWithTag("Hand");
        Direction = Hand.transform.localScale;
    }
    void Update()
    {
        rb.velocity = new Vector2(Direction.x * 20, Direction.y * 20);
    }
}
