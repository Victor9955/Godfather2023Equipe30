using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject[] buttonList;
    private int buttonSelected = 0;

    [Header("Input")]
    [SerializeField] private InputActionAsset controls;
    public InputAction left;
    public InputAction right;
    public InputAction validate;
    private InputActionMap _inputActionMap;

    [Header("Crédits")]
    [SerializeField] private GameObject creditPanel;
    private bool inCredit = false;

    private void Start()
    {
        _inputActionMap = controls.FindActionMap("MainMenu");
        left = _inputActionMap.FindAction("Left");
        left.performed += Left;
        right = _inputActionMap.FindAction("Right");
        right.performed += Right;
        validate = _inputActionMap.FindAction("Validate");
        validate.performed += Validate;

        UpdateUI(0, 0);
        GameManager.GameState = GameManager.gameStateList.MainMenu;
    }

    public void Left(InputAction.CallbackContext ctx) //Unity Input Call
    {
        if (!inCredit)
        {
            int _previousActive = buttonSelected;
            if (buttonSelected < buttonList.Length - 1)
                buttonSelected++;
            else
                buttonSelected = 0;

            UpdateUI(_previousActive, buttonSelected);
        }
    }

    public void Right(InputAction.CallbackContext ctx) //Unity Input Call
    {
        if (!inCredit)
        {
            int _previousActive = buttonSelected;
            if (buttonSelected > 0)
                buttonSelected--;
            else
                buttonSelected = buttonList.Length - 1;

            UpdateUI(_previousActive, buttonSelected);
        }
    }

    public void Validate(InputAction.CallbackContext ctx) //Unity Input Call
    {
        if (!inCredit)
        {
            switch (buttonSelected)
            {
                case 0:
                    StartGame();
                    return;
                case 1:
                    Quit();
                    return;
                case 2:
                    ShowCredit();
                    return;
            }
        }
        else
            HideCredit();
    }

    private void UpdateUI(int _lastActiveButton, int _newActiveButton)
    {
        buttonList[_lastActiveButton].GetComponent<Image>().color = Color.white;
        buttonList[_newActiveButton].GetComponent<Image>().color = Color.green;
    }

    void StartGame()
    {
        Debug.Log("Start Game");
        GameManager.GameState = GameManager.gameStateList.IgTuto;
        SceneManager.LoadScene("InGame");
    }

    void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    void ShowCredit()
    {
        Debug.Log("SHOW CREDIT");
        inCredit = true;
        
        foreach (GameObject btn in buttonList){
            btn.SetActive(false);
        }

        if (creditPanel != null)
            creditPanel.SetActive(true);
        else
            Debug.LogError("NO CREDITS PANEL");
    }

    void HideCredit()
    {
        inCredit = false;

        if (creditPanel != null)
            creditPanel.SetActive(false);

        foreach (GameObject btn in buttonList)
        {
            btn.SetActive(true);
        }
    }
}
