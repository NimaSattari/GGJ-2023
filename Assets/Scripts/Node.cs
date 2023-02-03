using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    [SerializeField] CircleCollider2D circle;
    public bool visited;
    public int scoreToAdd;
    [SerializeField] AudioClip clip;

    private void OnMouseDown()
    {
        var dis = Vector3.Distance(transform.position, Player.instance.transform.position);
        if (!visited && dis <= 1.1f)
        {
            OnClick(true);
        }
        else if(!visited && dis >= 1.2f && dis <= 1.6f)
        {
            OnClick(false);
        }
    }

    public virtual void OnClick(bool isShort)
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
                Player.instance.source.PlayOneShot(clip);
            }
        }
    }

    public virtual void PlayerCollision()
    {
        circle.enabled = false;
        Player.instance.score += scoreToAdd;
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