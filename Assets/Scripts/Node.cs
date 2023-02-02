using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    [SerializeField] CircleCollider2D circle;
    public bool visited;

    private void OnMouseDown()
    {
        if (!visited)
        {
            OnClick();
        }
    }

    public virtual void OnClick()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !visited)
        {
            print("Colided");
            if (!collision.GetComponent<Player>().isMoving)
            {
                PlayerCollision();
                visited = true;
            }
        }
    }

    public virtual void PlayerCollision()
    {
        circle.enabled = false;
    }

    private void OnEnable()
    {
        Player.eventMove += OnPlayerMoved;
    }

    private void OnDisable()
    {
        Player.eventMove -= OnPlayerMoved;
    }

    public virtual void OnPlayerMoved()
    {
        
    }
}