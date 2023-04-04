using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;

public class Exit_Script : MonoBehaviour
{
    [SerializeField] GameLoader_Script g;
    Random RNG = new Random();
    void Start()
    {

    }
    void Update()
    {
        if (g.EnemyCount <= 0)
        {
            g.RoomDone = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            g.RoomReset();
            Destroy(gameObject);
        }
    }
}
