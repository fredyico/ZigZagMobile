using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject mazePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject tapText;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject highScore1;
    [SerializeField] private GameObject highScore2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        mazePanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
