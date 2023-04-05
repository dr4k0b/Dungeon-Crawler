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
    float EnemyHP = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Enemy1();
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
            Invoke("Enemy3", 1f);
            spawned = true;
        }
    }
    void Enemy3()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
        transform.position = Vector2.MoveTowards(this.transform.position, p.Position, 1 * Time.deltaTime);
        spawned = false;
    }
}
