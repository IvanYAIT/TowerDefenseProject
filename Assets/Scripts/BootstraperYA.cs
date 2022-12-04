using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BootstraperYA : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI mainTowerHpText;
    [SerializeField] private List<Transform> spawnpoints;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private bool isLvl0;
    [SerializeField] private MainTower mainTower;

    private StateMachine stateMachine;
    private MoneyView moneyView;
    private Spawner spawner;
    private MainTowerHPView mainTowerHPView;

    void Start()
    {
        stateMachine = new StateMachine(menu, isLvl0);
        moneyView = new MoneyView(moneyText);
        mainTowerHPView = new MainTowerHPView(mainTowerHpText);
        spawner = new Spawner(spawnpoints, enemies, ProgressBar, isLvl0);
    }

    void Update()
    {
        stateMachine.Update();
        moneyView.View();
        spawner.Spawn();
        mainTowerHPView.View(mainTower.HP);
    }
}
