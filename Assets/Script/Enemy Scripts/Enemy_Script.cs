using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy_Script : MonoBehaviour
{
    Random RNG = new Random();
    [SerializeField] Player_Script p;
    static List<Vector2> EnemyPos = new List<Vector2>();
    Rigidbody2D rb;
    [SerializeField] GameObject Enemy;
    Vector2 EnemySpawnPoint;
    int MaxEnemys = 5;
    public int EnemyCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
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
        while (EnemyCount < MaxEnemys)
        {
            EnemyCount++;
            EnemySpawn();
        }
        EnemyPos.Clear();
    }
}
