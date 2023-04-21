using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Exit_Script : MonoBehaviour
{
    [SerializeField] GameLoader_Script g;
    Random RNG = new Random();
    int currentSceneIndex;
    int shopIndex = 1;
    int gameIndex = 0;

    [SerializeField] Keep_Variabel VariKeep;

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
            if (VariKeep.shopOrNot < 2)
            {
                VariKeep.shopOrNot++;
                g.RoomReset();
                Destroy(gameObject);
            }
            else if (VariKeep.shopOrNot >= 2)
            {
                SceneManager.LoadScene(shopIndex);
                VariKeep.shopOrNot = 0;
            }
        }
    }
}
