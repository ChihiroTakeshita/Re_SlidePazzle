using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager GameManager { get; private set; }

    public ScoreUI scoreUI;
    SceneController sceneController;

    [SerializeField] public int defaultScore;
    [SerializeField] public float[] multiply;
    [SerializeField] public float maxTime;

    public bool freezing = true;
    public bool timeUp = false;

    public int m_score { get; private set; }

    private void Awake()
    {
        if(GameManager == null)
        {
            GameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        sceneController = SceneController.scene;
        if(!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.SetInt("isFirst", 0);
        }
    }

    public void AddScore(int score)
    {
        scoreUI.PrintScore(m_score, score);
        m_score += score;
    }

    public void LoadTitle()
    {
        sceneController.SceneChange("Title");
    }

    public void LoadGame()
    {
        m_score = 0;
        timeUp = false;
        sceneController.SceneChange("Game");
    }

    public void LoadResult()
    {
        sceneController.SceneChange("Result");
    }
}
