using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFoodNode : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] Transform[] posesToVisit;
    [SerializeField] int nowPos;
    [SerializeField] bool goFromStart = true;

    public override void OnClick()
    {
        base.OnClick();
        //Player.instance.MoveToLocation(transform.position, 1);
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        Player.instance.wholeFoodsEaten++;
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }

    public override void OnPlayerMoved()
    {
        base.OnPlayerMoved();
        NextPath();
    }

    public void NextPath()
    {
        if (goFromStart)
        {
            transform.DOMove(posesToVisit[nowPos + 1].position, 0.25f);
            nowPos++;
            if (nowPos == posesToVisit.Length - 1)
            {
                goFromStart = false;
            }
        }
        else
        {
            transform.DOMove(posesToVisit[nowPos - 1].position, 0.25f);
            nowPos--;
            if (nowPos == 0)
            {
                goFromStart = true;
            }
        }
    }
}
