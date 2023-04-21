using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Script : MonoBehaviour
{
    [SerializeField] GameObject p;
    Vector3 VelocityVector;
    double lengthToP;
    void Start()
    {
        VelocityVector = transform.position - new Vector3(p.transform.position.x, p.transform.position.y, 0);
        lengthToP = Math.Sqrt(Convert.ToDouble(Raised(VelocityVector.x - p.transform.position.x, 2) + Raised(VelocityVector.y - p.transform.position.y, 2)));
        VelocityVector = new Vector3(VelocityVector.x * Convert.ToSingle(200 / lengthToP), VelocityVector.y * Convert.ToSingle(200 / lengthToP), 0);
    }
    void Update()
    {
        transform.position += new Vector3(VelocityVector.x, VelocityVector.y, 0);
    }
    float Raised(float x, float y)
    {
        x *= x;
        if (y == 1)
            return x;
        else
            return Raised(x, y - 1);
    }
}
