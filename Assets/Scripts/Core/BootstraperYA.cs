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
        [SerializeField] private Slider ProgressBar;
        [SerializeField] private bool isLvl0;
        [SerializeField] private MainTower mainTower;

        private StateMachine stateMachine;
        private MoneyView moneyView;
        private Spawner spawner;
        private MainTowerHPView mainTowerHPView;
        private Game game;

        void Start()
        {
            stateMachine = new StateMachine(menu, isLvl0);
            game = new Game();
            moneyView = new MoneyView(moneyText);
            mainTowerHPView = new MainTowerHPView(mainTowerHpText);
            spawner = new Spawner(spawnpoints, waveDatas, ProgressBar, isLvl0);
        }

        void Update()
        {
            stateMachine.Update();
            game.CheckWin(ProgressBar.value, ProgressBar.maxValue);
            moneyView.View();
            spawner.Spawn();
            mainTowerHPView.View(mainTower.HP);
        }
    }
}