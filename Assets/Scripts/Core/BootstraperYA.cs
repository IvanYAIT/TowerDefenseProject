using State;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core
{
    public class BootstraperYA : MonoBehaviour
    {
        [SerializeField] private Menu menu;
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private TextMeshProUGUI mainTowerHpText;
        [SerializeField] private List<Transform> spawnpoints;
        [SerializeField] private List<WaveData> waveDatas;
        [SerializeField] private List<GameObject> enemies;
        [SerializeField] private Slider ProgressBar;
        [SerializeField] private bool isLvl0;
        [SerializeField] private MainTower mainTower;
        [SerializeField] private Training training;
        [SerializeField] private float waveDelay;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private Timer timer;

        private StateMachine stateMachine;
        private MoneyView moneyView;
        private Spawner spawner;
        private MainTowerHPView mainTowerHPView;
        private Game game;

        void Awake()
        {
            ResourceManager.Instance.money = int.Parse(moneyText.text);
            stateMachine = new StateMachine(menu, isLvl0);
            game = new Game();
            moneyView = new MoneyView(moneyText);
            mainTowerHPView = new MainTowerHPView(mainTowerHpText);
            spawner = new Spawner(spawnpoints, waveDatas, ProgressBar, enemies, isLvl0, waveDelay, waveText);
            timer.StartTimer();
        }

        void Update()
        {
            if (isLvl0)
            {
                if (training.IsTrainingEnd)
                {
                    stateMachine.Update();
                    game.CheckWin(ProgressBar.value, ProgressBar.maxValue);
                    moneyView.View();
                    spawner.Spawn();
                    mainTowerHPView.View(mainTower.HP);
                    timer.Check();
                }
            }
            else
            {
                stateMachine.Update();
                game.CheckWin(ProgressBar.value, ProgressBar.maxValue);
                moneyView.View();
                spawner.Spawn();
                mainTowerHPView.View(mainTower.HP);
                timer.Check();
            }
        }
    }
}