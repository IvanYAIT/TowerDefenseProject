using State;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    public void LoadScene()=>
        SceneManager.LoadScene(sceneNumber);

    public void Restart()=>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void NextLevel()=>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
