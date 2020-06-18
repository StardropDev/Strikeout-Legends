using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class/object to debug and test things
/// </summary>
public class DebugManager : MonoBehaviour
{
    /// Singleton Type object
    [Header("Debug Manager")]
    [SerializeField] DebugManager _debugManager;
    public static DebugManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = _debugManager;
    }


    /// Variables
    /// 
    [SerializeField] string[] _randomNames;



    /// Create Random Username
    public string GenerateRandomUsername()
    {
        // 1st select random name from array
        string _randName = _randomNames[Random.Range(0, _randomNames.Length)];

        // 2nd we add a random number next to it
        int _randNumLength = Random.Range(1, 3);
        for (int i = 0; i < _randNumLength; i++)
        {
            int num = Random.Range(0, 10);
            _randName += num.ToString();
        }

        // 3rd return generated name
        return _randName;
    }
}
