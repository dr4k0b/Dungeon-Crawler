using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy_Script : MonoBehaviour
{
    Rigidbody2D rb;
    Random RNG = new Random();
    [SerializeField] GameLoader_Script g;
    [SerializeField] Player_Script p;
    [SerializeField] GameObject Enemy;
    public int EnemyType = 0;
    int ThisEnemyType;
    float EnemyHP = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ThisEnemyType = EnemyType;
        if (ThisEnemyType == 1)
            EnemyHP = 3;
        if (ThisEnemyType == 2)
            EnemyHP = 5;
        if (ThisEnemyType == 3)
            EnemyHP = 1;
    }
    void Update()
    {
        if (ThisEnemyType == 1)
            Enemy1();
        if (ThisEnemyType == 2)
            Enemy2();
        if (ThisEnemyType == 3)
            Enemy3();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            EnemyHP--;
            Destroy(other.gameObject);
            if (EnemyHP <= 0)
            {
                g.EnemyCount -= 1;
                Destroy(gameObject);
            }
        }
    }
    void Enemy1()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, p.Position, 1 * Time.deltaTime);
    }
    bool spawned = false;
    void Enemy2()
    {
        if (!spawned)
        {
            Invoke("Enemy3spawn", 3f);
            spawned = true;
        }
    }
    void Enemy3spawn()
    {
        spawned = false;
        EnemyType = 3;
        g.EnemyCount += 1;
        Instantiate(Enemy, rb.position, transform.rotation);
        EnemyType = 0;
    }
    void Enemy3()
    {

        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        transform.position = Vector2.MoveTowards(this.transform.position, p.Position, 1 * Time.deltaTime);
    }
}
