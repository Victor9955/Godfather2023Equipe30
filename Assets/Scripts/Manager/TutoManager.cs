using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    [SerializeField] private GameObject TutoPanel;

    public static TutoManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartTuto()
    {
        TutoPanel.SetActive(true);
        //CardSpawner.instance.SpawnCard();
    }

    public void CloseTuto()
    {
        TutoPanel.SetActive(false);
        GameManager.GameState = GameManager.gameStateList.Ig;
        GameManager.Instance.UpdateStateEvent();
    }
}
