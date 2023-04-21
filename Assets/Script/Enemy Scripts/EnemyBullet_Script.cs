using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Script : MonoBehaviour
{
    [SerializeField] Player_Script p;
    Vector2 VelocityVector;
    void Start()
    {
       // int lengthToP = Math.Sqrt(Convert.ToDouble(Raised(VelocityVector.x - p.Position.x, 2);
        VelocityVector = transform.position - new Vector3(p.Position.x, p.Position.y, 0);
       // VelocityVector = new Vector2(VelocityVector.x * (200f / Math.Sqrt(Convert.ToDouble(Raised(VelocityVector.x - p.Position.x,2) - (Raised(VelocityVector.y - p.Position.y, 2), VelocityVector.y * (200f / VelocityVector.y);
    }
    void Update()
    {

    }
    float Raised(float x, float y)
    {
        x *= x;
        if (y == 1)
        {
            return x;
        }
        else
            return Raised(x, y - 1);
    }
}
