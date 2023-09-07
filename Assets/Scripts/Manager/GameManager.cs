using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private TutoManager tutoManager; // Nsm l'instance marche pas je sais pas pourquoi

    [Header("Variable")]
    public static int score;
    [SerializeField][Range(0, 20)] private int timeBtwCard;
    public int TimeBtwCard => timeBtwCard;

    [SerializeField][Range(0, 5)] private int freezeTime;
    public int FreezeTime => freezeTime;

    [SerializeField] private int cardScore;
    public int CardScore => cardScore;

    [SerializeField] private int cardScoreBonusTime;
    public int CardScoreBonusTime => cardScoreBonusTime;

    [SerializeField] private int maxCardStock;
    public int MaxCardStock => maxCardStock;



    public enum gameStateList
    {
        MainMenu,
        IgTuto,
        Ig,
        EndMenu,
    }


    public static gameStateList GameState;

    public static GameManager Instance; 

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        UpdateStateEvent();
    }

    public void UpdateStateEvent()
    {
        switch (GameState)
        {
            case gameStateList.MainMenu:
                return;
            case gameStateList.IgTuto:
                tutoManager.StartTuto();
                return;
            case gameStateList.Ig:
                return;
            case gameStateList.EndMenu:
                SceneManager.LoadScene("GameOverMenu");
                return;
            default: return;

        }
    }
}
