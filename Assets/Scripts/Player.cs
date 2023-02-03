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

    public void MoveToLocation(Vector3 endLocation, int foodWaste, bool isShort)
    {
        if (wholeFoodsEaten - spentFoods >= foodWaste && isShort)
        {
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
        else if (wholeFoodsEaten - spentFoods >= foodWaste + 1 && !isShort)
        {
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
            spentFoods += foodWaste + 1;
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
