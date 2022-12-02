using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootstraperYA : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private Text moneyText;
    [SerializeField] private Transform spawnpoin1;
    [SerializeField] private Transform spawnpoin2;
    [SerializeField] private GameObject NoramlEnemy;
    [SerializeField] private GameObject HeavyEnemy;
    [SerializeField] private GameObject SpeedEnemy;
    [SerializeField] private Slider ProgressBar;

    private StateMachine stateMachine;
    private MoneyView moneyView;
    private Spawner spawner;

    void Start()
    {
        stateMachine = new StateMachine(menu);
        moneyView = new MoneyView(moneyText);
        spawner = new Spawner(spawnpoin1, spawnpoin2, NoramlEnemy, HeavyEnemy, SpeedEnemy, ProgressBar);
    }

    void Update()
    {
        stateMachine.Update();
        moneyView.View();
        spawner.Spawn();
    }
}
