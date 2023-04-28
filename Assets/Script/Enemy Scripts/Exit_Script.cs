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
        Debug.Log("ShopOrNot = " + g.shopOrNot);
        if (other.tag == "Player")
        {
            if (g.shopOrNot < 2)
            {
                g.shopOrNot++;
                g.RoomReset();
                Destroy(gameObject);
            }
            else if (g.shopOrNot >= 2)
            {
                g.shopOrNot = 0;
                Debug.Log("ShopOrNot = " + g.shopOrNot);
                SceneManager.LoadScene(shopIndex);
                Destroy(gameObject);
            }
        }
    }
}
