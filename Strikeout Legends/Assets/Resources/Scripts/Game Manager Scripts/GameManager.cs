
using UnityEngine;


/// <summary>
/// Class/Object responsible for managing and dictating what all other managers must do depending on its state.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// Singleton Type object
    // ( there are several ways of doing this, this is just my favourite )
    // ( object responsible for controlling whole game. DO NOT DESTROY ON LOAD )
    [Header("Game Manager")]
    [SerializeField] GameManager _gameManager;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = _gameManager;
            DontDestroyOnLoad(Instance);
            _gameState = gameState.disconnected;
        }
    }



    /// Now we determain the game states:
    /// 0 LOGIN - user registration and login (will be on seperate initial scene)
    /// 1 MAINMENU - main app hub for user action (main server connection) (has its own states: check player stats, go shopping, enter matchmaking, etc)
    /// 2 MATCHMAKING - searching for a match (has its own states: lobby/readiness check, create game server instance)
    /// 3 MATCH - user is playing a match against other people
    /// 4 RESULT - show post match stats and give rewards
    /// 5 DISCONNECTED - game app failed to connect to server
    public enum gameState { login, mainMenu, matchmaking, match, result, disconnected }
    public gameState _gameState;



    /// Now we update the Game State based on user input
    private void Update()
    {
        GameStateMachine();
    }



    /// "State Machine"
    void GameStateMachine()
    {
        switch (_gameState)
        {
            case gameState.login:
                StateLogin();
                break;

            case gameState.mainMenu:
                StateMainMenu();
                break;

            case gameState.matchmaking:
                StateMatchmaking();
                break;

            case gameState.match:
                StateMatch();
                break;

            case gameState.result:
                StateResult();
                break;

            case gameState.disconnected:
                StateDisconnected();
                break;

            default:
                Debug.LogError("Something went terribly wrong with Game States!");
                break;
        }
    }


    #region // Game State Methods
    /// Login State
    /// <summary>
    /// 1ST - we tell the NetworkManager to try to connect to the server and fetch user info/data;
    /// 2ND - we tell the NetworkManager to create a scriptable object holding this info/data;
    /// 3RD - we load the Main Menu scene and change state to Main Menu;
    /// </summary>
    void StateLogin()
    {

    }



    /// Main Menu State
    /// <summary>
    /// Gives user the following options:
    ///     1 check profile info
    ///     2 shop for characters, cosmetics & currency
    ///     3 join matchmaking;
    ///     
    /// All this from CanvasManager
    /// </summary>
    void StateMainMenu()
    {

    }



    /// Matchmaking State
    /// /// <summary>
    /// 
    /// </summary>
    void StateMatchmaking()
    {

    }



    /// Match State (where the gameplay happens)
    /// /// <summary>
    /// 
    /// </summary>
    void StateMatch()
    {

    }



    /// Result State
    /// /// <summary>
    /// 
    /// </summary>
    void StateResult()
    {

    }



    /// Disconnected State
    /// /// <summary>
    /// 
    /// </summary>
    void StateDisconnected()
    {

    }

    #endregion



    #region // Game State Changers

    /// Confirmed Login / Registration
    /// <summary>
    /// Change Game State to Main Menu
    /// </summary>
    public void ConfirmedLogin()
    {
        GameSceneManager.Instance.LoadGameSceneAsync(2);
        _gameState = gameState.mainMenu;
    }

    #endregion
}
