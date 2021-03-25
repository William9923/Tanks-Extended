using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    public int m_NumCoins = 10;                  // Number of coins generated per round
    public float m_StartDelay = 3f;             // The delay between the start of RoundStarting and RoundPlaying phases.
    public float m_EndDelay = 3f;               // The delay between the end of RoundPlaying and RoundEnding phases.
    
    public float m_MatchDuration = 60f;         // The deathmatch duration for one game
    public float m_CurrentTime = 0f;

    public float m_SpawnCoinTime = 1f;
    public float m_SpawnCoinDelay = 7.5f;
    public int m_SpawnMin = 5;
    public int m_SpawnMax = 10;

    public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.
    public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.
    public Text m_TimeText;                     // Reference to the overlay Text to display game timer.
    public Text m_PlayerStats;                  // Reference to the overlay Text to display player stats.

    public GameObject m_TankPrefab;             // Reference to the prefab the players will control.
    public GameObject m_CoinPrefab;             // Reference to the coin player will try to obtain
    
    public Transform[] m_SpawnPoints;           // To choose spawnPoint possible for max 4 players
    public TankCountdownManager[] m_Tanks;               // A collection of managers for enabling and disabling different aspects of the tanks.
    private ArrayList m_Coins;                  // A collection of managers for enabling and disabling coins in every rounds
    
    private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.
    private WaitForSeconds m_PlayWait;

    private TankCountdownManager m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.
    
    private int m_CurrentCoinsInPlay;
    private GameState m_GameState;

    private void Start()
    {
        // Create the delays so they only have to be made once.
        m_StartWait = new WaitForSeconds (m_StartDelay);
        m_EndWait = new WaitForSeconds (m_EndDelay);
        m_PlayWait = new WaitForSeconds (m_MatchDuration);

        m_Coins = new ArrayList();
        m_CurrentCoinsInPlay = 0;
        m_GameState = GameState.Waiting;

        SpawnAllTanks();
        SetCameraTargets();
        
        // Once the tanks have been created and the camera is using them as targets, start the game.
        StartCoroutine (GameLoop ());
    }

    /*
        Utility Function
    */

    private void SpawnAllTanks()
    {
        // For all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... create them, set their player number and references needed for control.
            m_Tanks[i].m_SpawnPoint = m_SpawnPoints;
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_SpawnPoints[i].position, m_SpawnPoints[i].rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].m_InitialSpawnPointIdx = i;
            m_Tanks[i].Setup();
        }
    }

    private void StartSpawningCoins()
    {
        InvokeRepeating("SpawnCoins", m_SpawnCoinTime, m_SpawnCoinDelay);
    }

    private void SpawnCoins()
    {
        if (m_GameState == GameState.Playing)
        {
            for (int i = 0; i < UnityEngine.Random.Range(m_SpawnMin, m_SpawnMin); i++)
            {
                m_Coins.Add(new CoinManager());
            
                (m_Coins[m_CurrentCoinsInPlay] as CoinManager).m_Instance = 
                    Instantiate(m_CoinPrefab, (m_Coins[m_CurrentCoinsInPlay] as CoinManager).GetRandomInField(),  Quaternion.identity);
                (m_Coins[m_CurrentCoinsInPlay] as CoinManager).Setup(m_CurrentCoinsInPlay, UnityEngine.Random.Range(0, 5));
                m_CurrentCoinsInPlay++;
            }
        } 
        else 
        {
            CancelInvoke("SpawnCoins");
        }
        
    }

    private void SetCameraTargets()
    {
        // Create a collection of transforms the same size as the number of tanks.
        Transform[] targets = new Transform[m_Tanks.Length];

        // For each of these transforms...
        for (int i = 0; i < targets.Length; i++)
        {
            // ... set it to the appropriate tank transform.
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        // These are the targets the camera should follow.
        m_CameraControl.m_Targets = targets;
    }

    /*
        Game Rules
    */

    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop ()
    {
        // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine (RoundStarting ());

        // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine (RoundPlaying());

        // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine (RoundEnding());

    }


    private IEnumerator RoundStarting ()
    {
        // As soon as the round starts reset the tanks and make sure they can't move.
        ResetAllTanks ();
        DisableTankControl ();

        // Snap the camera's zoom and position to something appropriate for the reset tanks.
        m_CameraControl.SetStartPositionAndSize ();

        // Set Leaderboard
        SetLeaderBoardMessage();

        // Increment the round number and display text showing the players what round it is.
        m_MessageText.text = "Ready ... ";

        // Setup gamestate
        m_GameState = GameState.Playing;

        // Setup All Coins
        StartSpawningCoins();

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying ()
    {
        // As soon as the round begins playing let the players control the tanks.
        EnableTankControl ();

        // Clear the text from the screen.
        m_MessageText.text = string.Empty;

        // Invoke Repeatedly to update text for time and game state
        InvokeRepeating("SetLeaderBoardMessage", 1f, 0.2f);
        InvokeRepeating("UpdateCountdown", 1f, 1f);

        // While the game still being played, don't return the control yet
        yield return m_PlayWait;
    }


    private IEnumerator RoundEnding ()
    {
        CancelInvoke("UpdateCountdown");

        // setup game state
        m_GameState = GameState.Waiting;

        // Stop tanks from moving.
        DisableTankControl ();

        // Delete from scene unused coins
        DeleteUnusedCoins();

        // Now the winner's score has been incremented, see if someone has one the game.
        m_GameWinner = GetGameWinner ();

        // Get a message based on the scores and whether or not there is a game winner and display it.
        string message = EndMessage ();
        m_MessageText.text = message;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_EndWait;
    }


    // This function is to find out if there is a winner of the game.
    private TankCountdownManager GetGameWinner()
    {
        int index = -1;
        int numberOfWin = -1;
        // Go through all the tanks...
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            // ... and if one of them has enough rounds to win the game, return it.

            TankMoney targetMoney = m_Tanks[i].m_Instance.GetComponent<TankMoney> ();
            if (!targetMoney)
                continue;
            int points = targetMoney.GetMoney();
            if (points > numberOfWin) 
            {
                index = i;
                numberOfWin = points; 
            }
            
        }

        // If no tanks get from this process, return null
        return index != -1 ? m_Tanks[index] : null;
    }


    // Returns a string message to display at the end of each round.
    private string EndMessage()
    {
        // By default when a round ends there are no winners so the default end message is a draw.
        string message = "DRAW!";

        // If there is a winner then change the message to reflect that.
        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        // Add some line breaks after the initial message.
        message += "\n\n\n\n";
        message += Leaderboard();
        return message;
    }

    private void SetLeaderBoardMessage()
    {
        m_PlayerStats.text = Leaderboard();
    }

    private string Leaderboard()
    {
        string message = "Leaderboard: \n";

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            TankMoney targetMoney = m_Tanks[i].m_Instance.GetComponent<TankMoney> ();
            if (!targetMoney)
                continue;
            int points = targetMoney.GetMoney();
            message += m_Tanks[i].m_ColoredPlayerText + ": " + points + "\n";
        }
        return message;
    }

    private void UpdateCountdown()
    {
        // logic for decreasing time
        m_CurrentTime++;
        m_TimeText.text = string.Format("{0}",Mathf.Max(0f, m_MatchDuration - m_CurrentTime));
    }


    // This function is used to turn all the tanks back on and reset their positions and properties.
    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }

    private void DeleteUnusedCoins()
    {
        for (int i = 0; i < m_CurrentCoinsInPlay; i++)
        {
            (m_Coins[i] as CoinManager).Delete();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}