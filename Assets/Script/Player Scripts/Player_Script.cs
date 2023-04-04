using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class Player_Script : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Exit;
    [SerializeField] Transform BulletSpawn;
    Random RNG = new Random();
    Vector2 StartPos;
    float Speed = 10;
    float WalkAni = 1;
    public List<Vector2> ItemPos = new List<Vector2>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * Speed, moveInput.y * Speed);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnShoot()
    {
        Instantiate(Bullet, BulletSpawn.transform.position, transform.rotation);
    }
    public void RoomReset()
    {
        Vector2 pos;
        do
        {
            pos = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        } while (ItemPos.Contains(pos));
        ItemPos.Add(pos);
        rb.position = pos;
    }
}
