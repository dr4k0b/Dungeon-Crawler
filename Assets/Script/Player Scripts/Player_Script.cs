using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class Player_Script : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Exit;
    [SerializeField] Transform BulletSpawn;
    Random RNG = new Random();
    public List<Vector2> ItemPos = new List<Vector2>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RoomReset();
    }
    void Update()
    {
        rb.velocity = new Vector2(moveInput.x * 10, moveInput.y * 10);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnShoot()
    {
        Instantiate(Bullet, BulletSpawn.transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit" && Input.GetKeyUp(KeyCode.E))
        {
            RoomReset();
            Destroy(other.gameObject);
        }
    }
    void RoomReset()
    {
        Vector2 exitPos;
        rb.transform.position = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        ItemPos.Add(rb.transform.position);
        do
        {
            exitPos = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        } while (ItemPos.Contains(exitPos));
        ItemPos.Add(exitPos);
        Instantiate(Exit, exitPos, transform.rotation);
        ItemPos.Clear();
    }
}
