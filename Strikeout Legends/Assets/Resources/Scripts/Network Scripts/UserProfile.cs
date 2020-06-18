using UnityEngine;

/// <summary>
/// Scriptable Object responsible for holding player info on login
/// </summary>
[CreateAssetMenu(fileName = "New User Profile", menuName = "Strikeout Legends/Network/Create User Profile")]
public class UserProfile : ScriptableObject
{
    /// Important user info to display in game
    // set as readonly to try and prevent cheating
    public readonly int userId;
    public readonly string username;
    public readonly int userLevel;
    public readonly int[] ownedCharacters;
    public readonly int[,] ownedCharSkins;



    /// User Profile contructor
    /// <summary>
    /// Create user id, name, owned characters and owned skins to select and display in game
    /// </summary>
    public UserProfile(int id, string name, int level, int[] ownedChars)
    {
        userId = id;
        username = name;
        userLevel = level;
        ownedCharacters = ownedChars;
    }
}
