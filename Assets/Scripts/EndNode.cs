using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : Node
{
    public override void OnClick()
    {
        base.OnClick();
        Player.instance.MoveToLocation(transform.position, 1);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.Win();
    }
}
