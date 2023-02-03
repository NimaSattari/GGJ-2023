using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : Node
{
    public override void OnClick(bool isShort)
    {
        base.OnClick(isShort);
        Player.instance.MoveToLocation(transform.position, 1,isShort);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.Win();
    }
}
