using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject trainingMenu;
    [SerializeField] GameObject musicPlayer;

    public GameObject PauseMenu => pauseMenu;
    public GameObject WinMenu => winMenu;
    public GameObject LoseMenu => loseMenu;
    public GameObject TrainingMenu => trainingMenu;
    public GameObject MusicPlayer => musicPlayer;
}
