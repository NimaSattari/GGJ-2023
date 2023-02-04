using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public static Player instance;
    [SerializeField] public LineRenderer lineRenderer;
    public AudioSource source;
    public static event Action eventMove;

    private int moveNumb;
    private bool firstMove;
    public float wholeFoodsEaten;
    public float spentFoods;
    public bool isMoving;
    public int score;

    public Vector2 nowLoc, beforeLoc;

    private void Start()
    {
        if (Player.instance == null)
        {
            Player.instance = this;
        }
    }

    private void LateUpdate()
    {
        UIManager.instance.movesText.text = (wholeFoodsEaten - spentFoods).ToString();
        UIManager.instance.scoreText.text = score.ToString();

        if (wholeFoodsEaten - spentFoods <= 0 && !isMoving)
        {
            StartCoroutine(Lose());
        }
    }

    public void MoveToLocation(Vector3 endLocation, int foodWaste)
    {
        if (wholeFoodsEaten - spentFoods >= foodWaste)
        {
            beforeLoc = transform.position;
            isMoving = true;
            print("Player Move");
            transform.DOMove(endLocation, 1);
            if (!firstMove)
            {
                lineRenderer.positionCount += 2;
                lineRenderer.SetPosition(moveNumb, transform.position);
                firstMove = true;
            }
            else
            {
                lineRenderer.positionCount += 1;
            }
            lineRenderer.SetPosition(moveNumb + 1, endLocation);
            moveNumb++;
            spentFoods += foodWaste;
            StartCoroutine(ChangeIsMove());
            eventMove?.Invoke();
        }
        else
        {
            print("NO NO");
        }
    }

    public IEnumerator ChangeIsMove()
    {
        yield return new WaitForSeconds(1f);
        nowLoc = transform.position;

        if(nowLoc.y - beforeLoc.y >= 0.9f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (nowLoc.y - beforeLoc.y <= -0.9f)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (nowLoc.x - beforeLoc.x <= -0.9f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (nowLoc.x - beforeLoc.x >= 0.9f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        isMoving = false;
    }

    public void Win()
    {
        print("Win");
        UIManager.instance.winText.SetActive(true);
        score += (int)(wholeFoodsEaten - spentFoods) * 10;
    }

    public IEnumerator Lose()
    {
        yield return new WaitForSeconds(1f);
        if(wholeFoodsEaten - spentFoods <= 0 && !isMoving)
        {
            print("Lose");
            UIManager.instance.loseText.SetActive(true);
        }
    }
}
