using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class/Object Responsible for controlling the Main Menu States ( idle, shopping, matchmaking )
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    /// Singleton Type object
    // ( this class/object will only be active when Main Menu scene is loaded )
    [Header("Main Menu Manager")]
    [SerializeField] MainMenuManager _mainMenuManager;
    public static MainMenuManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = _mainMenuManager;
    }


    /// 1st we determain the States & variables
    /// 
    public enum mainMenuState { main, stats, social, shop, matchmaking }
    [Header("Main Menu State")]
    public mainMenuState _mainMenuState;



    /// 2nd we start up the scene and update important info
    /// 
    private void Start()
    {
        /// debuging / testing
        // if there is no user profile, create one
        if (NetworkManager.Instance._userProfile == null)
        {
            NetworkManager.Instance.CreateUserProfile(DebugManager.Instance.GenerateRandomUsername());
        }

        MainMenuCanvasManager.Instance.UpdateUserInfo();
        MainMenuCanvasManager.Instance.ChangeMenu(0);
    }
}
