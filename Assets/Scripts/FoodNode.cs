using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNode : Node
{
    [SerializeField] GameObject emptyNode;
    public override void OnClick()
    {
        base.OnClick();
        Player.instance.MoveToLocation(transform.position, 1);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.wholeFoodsEaten++;
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
