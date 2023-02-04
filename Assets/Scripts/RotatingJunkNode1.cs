using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingJunkNode1 : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] int nowPos;
    [SerializeField] bool isClickedOn = false;
    [SerializeField] GameObject rotatingObject;
    [SerializeField] int takenFood;

    public override void OnClick(bool isShort)
    {
        print("OnClick");
        base.OnClick(isShort);
        float playerY = Player.instance.transform.position.y, playerx = Player.instance.transform.position.x;
        float myX = transform.position.x, myY = transform.position.y;

        if ((nowPos == 0 && playerY - myY >= 0.9f && playerx - myX <= 0.1f) ||
            (nowPos == 0 && playerY - myY <= -0.9f && playerx - myX <= 0.1f))
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, takenFood, isShort);
        }
        else if ((nowPos == 2 && playerY - myY >= 0.9f && playerx - myX <= 0.1f) ||
            (nowPos == 2 && playerY - myY <= -0.9f && playerx - myX <= 0.1f))
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, takenFood, isShort);
        }
        else if ((nowPos == 1 && playerx - myX >= 0.9f && playerY - myY <= 0.1f) ||
            (nowPos == 1 && playerx - myX <= -0.9f && playerY - myY <= 0.1f))
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, takenFood, isShort);
        }
        else if ((nowPos == 3 && playerx - myX >= 0.9f && playerY - myY <= 0.1f) ||
            (nowPos == 3 && playerx - myX <= -0.9f && playerY - myY <= 0.1f))
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, takenFood, isShort);
        }
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        GameObject emptyInstant = Instantiate(emptyNode, transform.position, Quaternion.identity, transform.parent);
        emptyInstant.GetComponent<Node>().visited = true;
        Destroy(gameObject);
    }

    public override void OnPlayerMoved()
    {
        print("OnMove");
        base.OnPlayerMoved();
        if (!isClickedOn)
        {
            NextPath();
        }
    }

    public void NextPath()
    {
        rotatingObject.transform.DORotate(rotatingObject.transform.eulerAngles + new Vector3(0, 0, 90), 0.25f);
        nowPos++;
        if(nowPos == 4)
        {
            nowPos = 0;
        }
    }
}
