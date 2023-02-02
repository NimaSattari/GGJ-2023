using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public static Player instance;
    [SerializeField] public LineRenderer lineRenderer;
    public static event Action eventMove;

    private int moveNumb;
    private bool firstMove;
    public float wholeFoodsEaten;
    public float spentFoods;
    public bool isMoving;

/*    private int animationStep;
    private float fps = 30;
    private float fpsCounter;
    [SerializeField] Texture[] textures;*/
    private void Start()
    {
        if (Player.instance == null)
        {
            Player.instance = this;
        }
    }

    /*        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1f / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);
            fpsCounter = 0;
        }*/

    private void LateUpdate()
    {
        UIManager.instance.movesText.text = (wholeFoodsEaten - spentFoods).ToString();
        if (wholeFoodsEaten - spentFoods <= 0 && !isMoving)
        {
            StartCoroutine(Lose());
        }
    }

    public void MoveToLocation(Vector3 endLocation, int foodWaste)
    {
        var dis = Vector3.Distance(transform.position, endLocation);
        if (dis <= 1.1f && wholeFoodsEaten - spentFoods >= foodWaste)
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
        else if (dis >= 1.2f && dis <= 1.6f && wholeFoodsEaten - spentFoods >= foodWaste*2)
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
            spentFoods += foodWaste * 2;
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
