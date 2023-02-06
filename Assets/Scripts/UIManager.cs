using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    [SerializeField] public static UIManager instance;
    private void Start()
    {
        if (UIManager.instance == null)
        {
            UIManager.instance = this;
        }
    }
    #endregion

    [SerializeField] public TextMeshProUGUI movesText;
    [SerializeField] public GameObject loseText;
    [SerializeField] public GameObject winText;
    [SerializeField] public TextMeshProUGUI scoreText;

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
