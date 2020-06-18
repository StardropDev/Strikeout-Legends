using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasManager : MonoBehaviour
{
    /// Singleton Type object
    // ( this class/object will only be active when Main Menu scene is loaded )
    [Header("Main Menu Canvas Manager")]
    [SerializeField] MainMenuCanvasManager _mmCanvasManager;
    public static MainMenuCanvasManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = _mmCanvasManager;
    }


    /// Variables we gonna display from User Profile SObject
    // (they arrays so we can update all of them in bulk)
    [Header("User Info in Bulk")]
    [SerializeField] TextMeshProUGUI[] _usernameUi;
    [SerializeField] TextMeshProUGUI[] _userLevelUi;
    [SerializeField] TextMeshProUGUI[] _gamePointsUi;
    [SerializeField] TextMeshProUGUI[] _strikerPointsUi;
    [SerializeField] Image[] _userIconUi;

    /// State gameobjects to activate and deactivate based on state
    // (0 = Main, 1 = Play, 2 = Shop)
    [Header("Game Menus")]
    [Tooltip("0 = Main, 1 = Matchmaking")]
    [SerializeField] GameObject[] _gameMenus;



    /// Update User information
    /// <summary>
    /// Update user info throughout all text & image displays
    /// </summary>
    public void UpdateUserInfo()
    {
        // update all username display instances
        foreach(TextMeshProUGUI _name in _usernameUi)
            _name.text = NetworkManager.Instance._userProfile.username;

        // update all level display instances
        foreach (TextMeshProUGUI _level in _userLevelUi)
            _level.text = NetworkManager.Instance._userProfile.userLevel.ToString();
    }



    /// Select which menu to activate or deactivate
    /// <summary>
    /// 0 = Main, 1 = Matchmaking
    /// </summary>
    public void ChangeMenu(int menuID)
    {
        // 1st we deactivate all menus
        foreach (GameObject _menu in _gameMenus)
            _menu.SetActive(false);

        // 2nd we activate selected menu
        _gameMenus[menuID].SetActive(true);
    }
}
