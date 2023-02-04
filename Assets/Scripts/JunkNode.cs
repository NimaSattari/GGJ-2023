using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkNode : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] int takenFood;
    public override void OnClick(bool isShort)
    {
        base.OnClick(isShort);
        Player.instance.MoveToLocation(transform.position, takenFood,isShort);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
