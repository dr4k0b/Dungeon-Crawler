using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Shop : MonoBehaviour
{
    int gameIndex = 3;
    Hand_Script hand;
    bool choseWeapon1 = false;
    bool choseWeapon2 = false;
    bool choseWeapon3 = false;


    public void Weapon1()
    {
        choseWeapon1 = true;
    }

    public void Weapon2()
    {
        choseWeapon2 = true;
    }
    public void Weapon3()
    {
        choseWeapon3 = true;
    }
    public void Cancel()
    {
        choseWeapon1 = false;
        choseWeapon2 = false;
        choseWeapon3 = false;
    }

    public void ExitShopToGame()
    {
        SceneManager.LoadScene(gameIndex);
    }
}
