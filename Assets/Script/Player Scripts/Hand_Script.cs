using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand_Script : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletSpawn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (moveInput != new Vector2(0f, 0f))
        {
            transform.localScale = new Vector3(moveInput.x, moveInput.y, 0f);
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnShoot()
    {
        Instantiate(Bullet, BulletSpawn.transform.position, transform.rotation);
    }
}
