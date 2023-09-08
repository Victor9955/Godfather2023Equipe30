using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class CardSpawnerManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private ScoreSystem score;
    [SerializeField] private List<GameObject> blankCardZone;
    [SerializeField] private GameObject[] cardStock;

    [SerializeField] private GameObject card;
    [SerializeField] private GameObject newCardSpawner;

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

        cardStock = new GameObject[gameManager.MaxCardStock];
    }

    public void StartGame()
    {
        Debug.Log("START GAME");
        InvokeRepeating("TimeBonus", 0f, 1.0f);
        InvokeRepeating("AddStorageCard", 0f, gameManager.TimeBtwCard);
        CardSpawner.instance.SpawnCard();
    }

    public void AddStorageCard()
    {
        Debug.Log("Add Storage");
        //Spawn & Setup the card
        if (gameManager.CardInStock < gameManager.MaxCardStock)
        {
            gameManager.CardInStock++;
            GameObject _newCard = Instantiate(card, newCardSpawner.transform.position, Quaternion.identity);
            cardStock[gameManager.CardInStock] = _newCard;
            UpdateStockPosition();
            
        }
        else//Game Over
        {
            Debug.Log("T'ES VIR2 GROS RATIO DANS TA MAMA");
            GameManager.GameState = GameManager.gameStateList.EndMenu;
            gameManager.UpdateStateEvent();
        }
    }

    private void UpdateStockPosition()
    {
        for (int i = 0; i < cardStock.Length; i++) 
        {
            Vector3 _pos = blankCardZone[i].transform.position;
            cardStock[i].transform.DOMove(_pos, 1.0f);
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
