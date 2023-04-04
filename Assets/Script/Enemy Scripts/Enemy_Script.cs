using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy_Script : MonoBehaviour
{
    Rigidbody2D rb;
    Random RNG = new Random();
    [SerializeField] GameLoader_Script g;
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
            g.EnemyCount -= 1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
