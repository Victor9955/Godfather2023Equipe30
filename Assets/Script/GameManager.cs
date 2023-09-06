using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameStateList
    {
        MainMenu,
        IgTuto,
        Ig,
        EndMenu,
    }

    private gameStateList gameState;
    public gameStateList GameState   // property
    {
        get { return gameState; }   // get method
        set { gameState = value; }  // set method
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
