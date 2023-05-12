using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Player_Script : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;

    int HP = 5;
    [SerializeField] GameObject Exit;

    Random RNG = new Random();
    float Speed = 10;
    public List<Vector2> ItemPos = new List<Vector2>();
    public Vector2 Position;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (HP > 0)
        {
            rb.velocity = new Vector2(moveInput.x * Speed, moveInput.y * Speed);
            Position = rb.position;
        }
        else
        {
            SceneManager.LoadScene(2);
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            HP--;
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void RoomReset()
    {
        Vector2 pos;
        do
        {
            pos = new Vector2(RNG.Next(-1, 2) * 6, RNG.Next(-1, 2) * 3);
        } while (ItemPos.Contains(pos));
        ItemPos.Add(pos);
        rb.position = pos;
    }
}
