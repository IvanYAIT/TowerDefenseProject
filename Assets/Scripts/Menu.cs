using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;

    public GameObject PauseMenu => pauseMenu;
    public GameObject WinMenu => winMenu;
    public GameObject LoseMenu => loseMenu;
}
