using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameOver = false;
    }

    public void StartGame()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
        
            
    }
    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }

}
