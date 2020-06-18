
using UnityEngine;
using UnityEditor;

public class CustomCommands : Editor
{
    /// Custom Activate / Deactivate Action - key A
    [MenuItem("Custom Commands/Activate_Or_Deactivate _a")]
    static void ActivateOrDeactivate()
    {
        if (Selection.activeTransform != null)
        {
            // get all selected objects
            GameObject[] _selectedObjs = Selection.gameObjects;

            foreach (GameObject go in _selectedObjs)
            {
                if (go.activeSelf)
                    go.SetActive(false);
                else
                    go.SetActive(true);
            }
        }
    }
}
