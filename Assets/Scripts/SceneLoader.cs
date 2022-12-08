using State;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    public static Action<Type> OnSceneChange;

    public void LoadScene()=>
        SceneManager.LoadScene(sceneNumber);

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnSceneChange?.Invoke(typeof(GameState));
    }
        

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        OnSceneChange?.Invoke(typeof(GameState));
    }

    public void Continue()=>
        OnSceneChange?.Invoke(typeof(GameState));

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit() =>
        Application.OpenURL("https://shgamerk.itch.io/croco-beat");
}
