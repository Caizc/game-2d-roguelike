using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float interval = 0.001f;

    [HideInInspector]
    public bool myTurn;

    Rigidbody2D rb;

    float timer = 0f;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
            myTurn = false;
        }
        else
        {
            myTurn = true;
        }

        if (myTurn)
        {
            MoveOn();
        }
    }

    void MoveOn()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        Vector2 targetPos;

        if (horizontal != 0 && vertical == 0)
        {
            targetPos = new Vector2(transform.position.x + horizontal, transform.position.y);
            rb.MovePosition(targetPos);
            timer = 0f;
        }
        else if (horizontal == 0 && vertical != 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + vertical);
            rb.MovePosition(targetPos);
            timer = 0f;
        }
    }

    void DetectObstacle()
    {
        
    }
}
