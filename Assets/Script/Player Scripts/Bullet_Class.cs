using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Player_Scripts
{
    public class Bullet_Class
    {
        public Rigidbody2D rb;
        public GameObject hand;
        public Vector2 direction;

        public float damage;

        public Bullet_Class(float argDamage)
        {
            damage = argDamage;
        }
    }
}
