using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Class/Object responsible for all game scene loading
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    /// Singleton type thing
    // (this class/object has no need for updates, since it will be directly controlled by the GameManager)
    [Header("Scene Manager")]
    [SerializeField] GameSceneManager _sceneManager;
    public static GameSceneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = _sceneManager;
            DontDestroyOnLoad(Instance);
        }        
    }



    /// Load Scene Asynch
    /// <summary>
    /// Load Scenes Async
    /// <para> 0 = Initialize Managers 1 = Login, 2 = Main Menu, 3 = Game Match </para>
    /// </summary>
    public void LoadGameSceneAsync(int _sceneIndex)
    {
        StartCoroutine(CR_LoadSceneAsync(_sceneIndex));
    }

    IEnumerator CR_LoadSceneAsync(int index)
    {
        AsyncOperation _operation = SceneManager.LoadSceneAsync(index);

        while (_operation.isDone == false)
        {
            // loading screen/bar update here

            yield return null;
        }
    }
}
