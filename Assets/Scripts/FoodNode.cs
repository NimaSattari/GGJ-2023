using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNode : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] int givenFood;

    public override void OnClick(int foodWaste)
    {
        base.OnClick(foodWaste);
        Player.instance.MoveToLocation(transform.position, foodWaste);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.wholeFoodsEaten += givenFood;
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }
}
