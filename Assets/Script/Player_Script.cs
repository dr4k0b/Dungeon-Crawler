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
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Exit;
    [SerializeField] Transform BulletSpawn;
    Vector2 EnemySpawnPoint;
    Random RNG = new Random();
    int MaxEnemys = 5;
    int EnemyCount = 0;
    static List<Vector2> EnemyPos = new List<Vector2>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RoomReset();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * 10, moveInput.y * 10);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnShoot()
    {
        Instantiate(Bullet, BulletSpawn.transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit" && Input.GetKeyUp(KeyCode.E))
        {
            RoomReset();
            Destroy(other.gameObject);
        }
    }
    //eassdsdf
    void EnemySpawn()
    {
        int x;
        int y;
        do
        {
            x = RNG.Next(-1, 2) * 6;
            y = RNG.Next(-1, 2) * 3;
        }
        while (EnemyPos.Contains(new Vector2(x, y)));
        EnemyPos.Add(new Vector2(x, y));
        EnemySpawnPoint = new Vector2(x, y);
        Instantiate(Enemy, EnemySpawnPoint, transform.rotation);
    }
    void RoomReset()
    {
        EnemyCount = 0;
        Vector2 exitPos;
        rb.transform.position = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        EnemyPos.Add(rb.transform.position);
        do
        {
            exitPos = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        } while (EnemyPos.Contains(exitPos));
        EnemyPos.Add(exitPos);
        Instantiate(Exit, exitPos, transform.rotation);
        while (EnemyCount < MaxEnemys)
        {
            EnemyCount++;
            EnemySpawn();
        }
        EnemyPos.Clear();
    }
}
