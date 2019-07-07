using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongManager : MonoBehaviour {

    [Header("Rackets")]
    public GameObject playerRacket;
    public GameObject IARacket;
    public GameObject ball;

    [Header("UI Configuration")]
    public Text enemyScoreText;
    public Text playerScoreText;
    public Button playButton;

    [Header("Scores")]
    public int enemyScore = 0;
    public int playerScore = 0;

    [Header("Runtime Watchers")]
    public bool isPlaying = false;


    #region Singleton
    public static PongManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public void ResetBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        ball.transform.position = Vector2.zero;
        StartCoroutine("LaunchBallAgain");
    }

    IEnumerator LaunchBallAgain()
    {
        yield return new WaitForSeconds(1.0f);
        ball.SendMessage("LaunchBallFirstTime");
    }

    public void StartGame()
    {
        ResetScore();
        playerRacket.GetComponent<RacketMovement>().enabled = true;
        playerRacket.GetComponent<RacketIA>().enabled = false;
        playerRacket.transform.position = new Vector2(playerRacket.transform.position.x, -0.5f);
        IARacket.transform.position = new Vector2(IARacket.transform.position.x, 0f);
        ResetBall();
        PongSkillMngr.Instance.ResetSkill();
        isPlaying = true;
    }

    public void ExitGame()
    {
        ResetScore();
        playerRacket.GetComponent<RacketMovement>().enabled = false;
        playerRacket.GetComponent<RacketIA>().enabled = true;
        playerRacket.transform.position = new Vector2(playerRacket.transform.position.x, -0.5f);
        IARacket.transform.position = new Vector2(IARacket.transform.position.x, 0f);
        ResetBall();
        PongSkillMngr.Instance.ResetSkill();
        isPlaying = false;
    }


    public void IncreaseEnemyScore()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }

    public void IncreasePlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        PongSkillMngr.Instance.UpdateEnemySkill();
    }

    void Start()
    {
        ExitGame();
    }

    private void ResetScore()
    {
        enemyScore = 0;
        playerScore = 0;
        enemyScoreText.text = enemyScore.ToString();
        playerScoreText.text = playerScore.ToString();
    }
}
