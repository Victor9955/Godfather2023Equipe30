using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        _inputActionMap = controls.FindActionMap("MainMenu");
        left = _inputActionMap.FindAction("Left");
        left.performed += Left;
        right = _inputActionMap.FindAction("Right");
        right.performed += Right;
        validate = _inputActionMap.FindAction("Validate");
        validate.performed += Validate;

        UpdateUI(0, 0);
    }

    public void Left(InputAction.CallbackContext ctx) //Unity Input Call
    {
        int _previousActive = buttonSelected;
        if (buttonSelected < buttonList.Length - 1)
            buttonSelected++;
        else
            buttonSelected = 0;

        UpdateUI(_previousActive, buttonSelected);
    }

    public void Right(InputAction.CallbackContext ctx) //Unity Input Call
    {
        int _previousActive = buttonSelected;
        if (buttonSelected > 0)
            buttonSelected--;
        else
            buttonSelected = buttonList.Length - 1;

        UpdateUI(_previousActive, buttonSelected);
    }

    public void Validate(InputAction.CallbackContext ctx) //Unity Input Call
    {
        switch (buttonSelected)
        {
            case 0:
                ReStartGame();
                return;
            case 1:
                Quit();
                return;
        }
    }

    void ReStartGame()
    {
        GameManager.GameState = GameManager.gameStateList.IgTuto;
        SceneManager.LoadScene("InGame");
    }

    void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    private void UpdateUI(int _lastActiveButton, int _newActiveButton)
    {
        buttonList[_lastActiveButton].GetComponent<Image>().color = Color.white;
        buttonList[_newActiveButton].GetComponent<Image>().color = Color.green;
    }
}
