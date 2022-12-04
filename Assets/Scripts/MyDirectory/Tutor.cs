using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutor : MonoBehaviour
{
    [Tooltip("objects that will be shown")]
    [SerializeField] GameObject[] gameObjects;
    private int i = 0;

    public void Show()
    {
        if(i < gameObjects.Length)
        {
            gameObjects[i].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
