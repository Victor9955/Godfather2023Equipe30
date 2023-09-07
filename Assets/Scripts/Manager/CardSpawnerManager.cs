using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CardSpawnerManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] ScoreSystem score;

    private int timePassed;
    public int TimePassed
    {
        get { return timePassed; }
        set { timePassed = value; }
    }

    public static CardSpawnerManager instance;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        if(instance == null)
            instance = this;

        timePassed = gameManager.CardScoreBonusTime;
    }

    public void StartGame()
    {
        Debug.Log("START GAME");
        InvokeRepeating("TimeBonus", 0f, 1.0f);
        CardSpawner.instance.SpawnCard();
    }

    public void AddStorageCard()
    {
        //Spawn & Setup the card
        if (gameManager.CardInStock < gameManager.MaxCardStock)
            gameManager.CardInStock++;
        else//Game Over
        {
            Debug.Log("T'ES VIR2 GROS RATIO DANS TA MAMA");
            GameManager.GameState = GameManager.gameStateList.EndMenu;
            gameManager.UpdateStateEvent();
        }
    }

    private void TimeBonus()
    {
        timePassed--;
        Debug.Log($"Time Passed : {timePassed}");
        if (timePassed < 1)
            CancelInvoke("TimeBonus");
    }

    public void AddPoint()
    {
        //(Score Card * current Time) / Temps Max
        score.SetAddScore(GameManager.score, (gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime);
        GameManager.score += (gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime;
        Debug.Log($"Add {(gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime} point");
    }

    public void RespawnCard()
    {
        Debug.Log("RESPAWN A CARD WHEN FINISHED");  
        StartCoroutine(RespawnCardAfterTimer());
    }

    IEnumerator RespawnCardAfterTimer()
    {
        yield return new WaitForSeconds(1);
        CardSpawner.instance.SpawnCard();
    }
}
