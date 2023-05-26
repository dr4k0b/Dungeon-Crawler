using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Shop : MonoBehaviour
{
    int gameIndex = 3;
    Hand_Script hand;

    void Start()
    {
    }

    void Update()
    {
        
    }
    public void ChooseShotGun()
    {
        hand.CurrentWeapon = hand.ShotgunBullet;
    }

    public void ChooseNormalBullet()
    {
        hand.CurrentWeapon = hand.NormalBullet;
    }
    public void ExitShopToGame()
    {
        SceneManager.LoadScene(gameIndex);
    }
}
