using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject mazePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject tapText;
    
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        mazePanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt ("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
