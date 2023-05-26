using Assets.Script.Player_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand_Script : MonoBehaviour
{
    Vector2 moveInput;
    public GameObject normalBulletObject;
    [SerializeField] GameObject Shotgun_Bullet;
    [SerializeField] Transform BulletSpawn;

    public Bullet_Class CurrentWeapon = new Bullet_Class(0);
    public Bullet_Class NormalBullet = new Bullet_Class(1);
    public Bullet_Class ShotgunBullet = new Bullet_Class(0.5f);


    void Start()
    {
        CurrentWeapon = NormalBullet;

        CurrentWeapon.rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (moveInput != new Vector2(0f, 0f))
        {
            transform.localScale = new Vector3(moveInput.x, moveInput.y, 0f);
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnShoot()
    {
        if (CurrentWeapon == NormalBullet)
            Instantiate(normalBulletObject, BulletSpawn.transform.position, transform.rotation);
        else if (CurrentWeapon == ShotgunBullet)
        {
            Instantiate(Shotgun_Bullet, BulletSpawn.transform.position, transform.rotation);
            Instantiate(Shotgun_Bullet, BulletSpawn.transform.position + new Vector3(-1,1,0), transform.rotation);
            Instantiate(Shotgun_Bullet, BulletSpawn.transform.position + new Vector3(1,-1,0), transform.rotation);
        }
    }
}
