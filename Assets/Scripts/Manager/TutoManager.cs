using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutoManager : MonoBehaviour
{
    [SerializeField] private GameObject tutoCard;

    [SerializeField] private GameObject[] TutoPanels;


    public static TutoManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartTuto()
    {
        StartCoroutine(StartTutoInfos());
    }

    public void CloseTuto()
    {
        Debug.Log("Close TUTO");
        GameManager.GameState = GameManager.gameStateList.Ig;
        GameManager.Instance.UpdateStateEvent();
        this.gameObject.SetActive(false);
    }

    IEnumerator StartTutoInfos() // Beurk mais y'a plus le temps
    {
        TutoPanels[0].SetActive(true);

        yield return new WaitForSeconds(3);

        TutoPanels[0].SetActive(false);
        TutoPanels[1].SetActive(true);

        yield return new WaitForSeconds(3);

        TutoPanels[1].SetActive(false);
        TutoPanels[2].SetActive(true);

        yield return new WaitForSeconds(3);

        TutoPanels[2].SetActive(false);
        TutoPanels[3].SetActive(true);

        CloseTuto();
    }
}
