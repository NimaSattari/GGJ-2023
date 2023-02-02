using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkNode : Node
{
    [SerializeField] GameObject emptyNode;
    public override void OnClick()
    {
        base.OnClick();
        Player.instance.MoveToLocation(transform.position, 2);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
