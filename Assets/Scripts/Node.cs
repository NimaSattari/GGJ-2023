using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    private Collider2D mycollider;

    [SerializeField] AudioClip clip;
    [SerializeField] int scoreToAdd;
    [SerializeField] int foodWaste;

    public bool visited;

    private void Start()
    {
        mycollider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        var dis = Vector3.Distance(transform.position, Player.instance.transform.position);
        if (!visited && dis <= 1.1f)
        {
            OnClick(foodWaste);
        }
        else if(!visited && dis >= 1.2f && dis <= 1.6f)
        {
            foodWaste++;
            OnClick(foodWaste);
        }
    }

    public virtual void OnClick(int foodWaste)
    {
        print(gameObject + "ClickedOn" + foodWaste);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !visited)
        {
            if (!collision.GetComponent<Player>().isMoving)
            {
                PlayerCollision();
                visited = true;
                if(clip != null)
                {
                    Player.instance.source.PlayOneShot(clip);
                }
            }
        }
    }

    public virtual void PlayerCollision()
    {
        mycollider.enabled = false;
        Player.instance.score += scoreToAdd;
        print(gameObject + "Collided With Player");
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