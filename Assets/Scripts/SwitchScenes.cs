using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public string newScene;

    void Update()
    {
        // Check if there are any game objects with the specified tag
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // All enemies are gone, so switch the scene
            SwitchScene(newScene);
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
