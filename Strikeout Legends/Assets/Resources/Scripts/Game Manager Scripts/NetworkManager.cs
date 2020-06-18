
using UnityEngine;


/// <summary>
/// Class/Object responsible for all networking systems
/// </summary>
public class NetworkManager : MonoBehaviour
{
    /// Singleton Type object
    [SerializeField] NetworkManager _networkManager;
    public static NetworkManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = _networkManager;
            DontDestroyOnLoad(Instance);
        }
    }

    /// Important variables
    [Header("Network Info")]
    public UserProfile _userProfile;
    [SerializeField] string _databseURL;
    [SerializeField] string _serverIP;
    [SerializeField] string _gameServerIP;

    [Header("Debug Options")]
    [SerializeField] bool debugMode;

    /// Create User Profile
    public void CreateUserProfile(string username)
    {
        if (debugMode)
        {
            /// create an array with length of total playable characters
            var owned = new int[4];

            /// profile only owns character id nº 0 (zeus)
            owned[0] = 1;

            //_userProfile = ScriptableObject.CreateInstance<UserProfile>();
            _userProfile = new UserProfile(1234, username, 1, owned);
            _userProfile.name = "User Profile";
        }

        Debug.Log(_userProfile.username);
    }
}
