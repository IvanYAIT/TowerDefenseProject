using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootstraperYA : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private Text moneyText;
    [SerializeField] private List<Transform> spawnpoints;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private bool isLvl0;

    private StateMachine stateMachine;
    private MoneyView moneyView;
    private Spawner spawner;

    void Start()
    {
        stateMachine = new StateMachine(menu, isLvl0);
        moneyView = new MoneyView(moneyText);
        spawner = new Spawner(spawnpoints, enemies, ProgressBar, isLvl0);
    }

    void Update()
    {
        stateMachine.Update();
        moneyView.View();
        spawner.Spawn();
    }
}
