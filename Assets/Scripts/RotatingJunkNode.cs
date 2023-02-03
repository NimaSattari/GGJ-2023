using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingJunkNode : Node
{
    [SerializeField] GameObject emptyNode;
    [SerializeField] int nowPos;
    [SerializeField] bool isClickedOn = false;
    [SerializeField] GameObject rotatingObject;

    public override void OnClick(bool isShort)
    {
        print("OnClick");
        base.OnClick(isShort);
        if (nowPos == 0 && Player.instance.transform.position.y - transform.position.y >= 0.9f && Player.instance.transform.position.x - transform.position.x <= 0.1f)
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, 2, isShort);
        }
        if (nowPos == 2 && Player.instance.transform.position.y - transform.position.y <= -0.9f && Player.instance.transform.position.x - transform.position.x <= 0.1f)
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, 2, isShort);
        }
        if (nowPos == 1 && Player.instance.transform.position.x - transform.position.x >= 0.9f && Player.instance.transform.position.y - transform.position.y <= 0.1f)
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, 2, isShort);
        }
        if (nowPos == 3 && Player.instance.transform.position.x - transform.position.x <= -0.9f && Player.instance.transform.position.y - transform.position.y <= 0.1f)
        {
            isClickedOn = true;
            Player.instance.MoveToLocation(transform.position, 2, isShort);
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
