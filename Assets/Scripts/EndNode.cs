using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : Node
{
    public override void OnClick(int foodWaste)
    {
        base.OnClick(foodWaste);
        Player.instance.MoveToLocation(transform.position, foodWaste);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.Win();
    }
}
