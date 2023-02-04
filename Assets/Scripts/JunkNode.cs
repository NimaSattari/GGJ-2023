using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkNode : Node
{
    [SerializeField] GameObject emptyNode;

    public override void OnClick(int foodWaste)
    {
        base.OnClick(foodWaste);
        Player.instance.MoveToLocation(transform.position, foodWaste);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
