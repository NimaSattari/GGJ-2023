using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNode : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] int foodPlus;
    public override void OnClick(bool isShort)
    {
        base.OnClick(isShort);
        Player.instance.MoveToLocation(transform.position, 1,isShort);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.wholeFoodsEaten += foodPlus;
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
