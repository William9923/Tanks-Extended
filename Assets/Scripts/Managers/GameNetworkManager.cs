using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNetworkManager : NetworkManager
{
    // public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
    // public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
    // public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.

    // [SyncVar]
    // public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.
    
    // [SyncVar]
    // public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
    // public GameObject m_TankPrefab;             // Reference to the prefab the players will control.
    
    // [SyncVar]
    // public TankManager[] m_Tanks;               // A collection of managers for enabling and disabling different aspects of the tanks.

    // [SyncVar]
    // private int m_RoundNumber;                  // Which round the game is currently on.
    
    // [SyncVar]
    // private bool onGoingRound;                  // tells if current round is going on
    
    // private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    // private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.
    // private TankManager m_RoundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
    // private TankManager m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.


    public override void OnStartServer() 
    {
        Debug.Log("Server started!");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server stopped!");
    }

    public override void OnClientConnect(NetworkConnection conn) 
    {
        Debug.Log("Connected to the server!");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Disconnect to the server");
    }
}
