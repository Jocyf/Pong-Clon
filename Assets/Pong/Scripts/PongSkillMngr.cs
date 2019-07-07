using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongSkillMngr : MonoBehaviour {

    public int skill = 0;

    private RacketIA IARacket;
    private Ball BallScr;

    private float ballSpeedOrig = 0f;
    private float iaSpeedOrig = 0f;
    private int playerScoreOrig = 0;

    #region Singleton
    public static PongSkillMngr Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public void ResetSkill()
    {
        skill = 1;
        SetSkill();
    }

    public void SetSkill()
    {
        IARacket.speed = iaSpeedOrig + skill * 0.25f;
        BallScr.speed = ballSpeedOrig + skill * 0.25f;
    }

    void Start ()
    {
        BallScr = PongManager.Instance.ball.GetComponent<Ball>();
        ballSpeedOrig = BallScr.speed;

        IARacket = PongManager.Instance.IARacket.GetComponent<RacketIA>();
        iaSpeedOrig = IARacket.speed;

        playerScoreOrig = PongManager.Instance.playerScore;
    }
	
    // SE llama de PongManager, cada vez que el player hace un punto.
	public void UpdateEnemySkill ()
    {
        if (!PongManager.Instance.isPlaying) return;

        if (playerScoreOrig != PongManager.Instance.playerScore)
        {
            playerScoreOrig = PongManager.Instance.playerScore;
            skill++;
            SetSkill();
        }
    }

}
