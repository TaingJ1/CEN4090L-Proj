using UnityEngine;
using UnityEngine.SceneManagement;      // Allows the script to change scenes


public class Title : MonoBehaviour
{
    //[SerializeField] private string

    public void NewGame()
    {
        SceneManager.LoadScene(3);      // Loads the overworld scene for now
    }

    public void Quit()        // Ends the current playing session of the game
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
}
