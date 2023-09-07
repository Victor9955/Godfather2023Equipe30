using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject TempCardStock;
    private GameManager gameManager;

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
        InvokeRepeating("AddStorageCard", 0f, GameManager.Instance.TimeBtwCard);
        CardSpawner.instance.SpawnCard();
    }

    public void AddStorageCard()
    {
        if (gameManager.CardInStock < gameManager.MaxCardStock)
        {
            gameManager.CardInStock++;
            TempCardStock.GetComponent<TextMeshProUGUI>().text = gameManager.CardInStock.ToString();
        }
        else//Game Over
        {
            Debug.Log("T'ES VIR2 GROS RATIO DANS TA MAMA");
            Debug.Log($"T'as {gameManager.CardInStock} carte avec un max de {gameManager.MaxCardStock}");
            GameManager.GameState = GameManager.gameStateList.EndMenu;
            gameManager.UpdateStateEvent();
        }
    }

    private void TimeBonus()
    {
        timePassed--;
        //Debug.Log($"Time Passed : {timePassed}");
        if (timePassed < 1)
            CancelInvoke("TimeBonus");
    }

    public void AddPoint()
    {
        int _scoreToAdd = ((gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime) + gameManager.CardScore;
        //(Score Card * current Time) / Temps Max
        GameManager.score += _scoreToAdd;
        Debug.Log($"Add {((gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime) + gameManager.CardScore} point with {gameManager.CardScore} base point and {((gameManager.CardScore * timePassed) / gameManager.CardScoreBonusTime)} Bonus Point");
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
        CancelInvoke("TimeBonus");
        InvokeRepeating("TimeBonus", 0f, 1.0f);
    }
}
