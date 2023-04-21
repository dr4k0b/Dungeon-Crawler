using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Shop : MonoBehaviour
{
    int gameIndex = 0;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void ExitShopToGame()
    {
        SceneManager.LoadScene(gameIndex);
    }
}
