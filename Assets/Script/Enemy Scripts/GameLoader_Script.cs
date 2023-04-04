using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameLoader_Script : MonoBehaviour
{
    [SerializeField] Player_Script p;

    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Exit;
    int Floor = 0;
    int CurrentFloor = 0;
    Random RNG = new Random();
    public int EnemyCount = 0;
    public bool RoomDone = false;
    void Start()
    {
        RoomReset();
    }

    void Update()
    {
        if (EnemyCount <= 0 && CurrentFloor == Floor)
        {
            ExitSPawn();
            RoomDone = false;
        }

    }
    public void RoomReset()
    {

        CurrentFloor = Floor;
        EnemySpawn();
        p.RoomReset();
        p.ItemPos.Clear();

    }
    void ExitSPawn()
    {
        Floor++;
        Vector2 exitPos;
        do
        {
            exitPos = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        } while (p.ItemPos.Contains(exitPos));
        p.ItemPos.Add(exitPos);
        Instantiate(Exit, exitPos, transform.rotation);

    }

    void EnemySpawn()
    {
        int x;
        int y;
        Vector2 EnemySpawnPoint;

        int MaxEnemys = 3;
        while (EnemyCount < MaxEnemys)
        {
            EnemyCount++;
            do
            {
                x = RNG.Next(-1, 2) * 6;
                y = RNG.Next(-1, 2) * 3;
            }
            while (p.ItemPos.Contains(new Vector2(x, y)));
            p.ItemPos.Add(new Vector2(x, y));
            EnemySpawnPoint = new Vector2(x, y);
            Instantiate(Enemy, EnemySpawnPoint, transform.rotation);
        }
    }
}
