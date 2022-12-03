using System;
using System.Collections.Generic;
using UnityEngine;
namespace State
{
    public class StateMachine
    {
        private Dictionary<Type, AState> states;
        private AState currentState;

        public StateMachine(Menu menu, bool isLvl0)
        {
            states = new Dictionary<Type, AState>();
            states.Add(typeof(GameState), new GameState(this));
            states.Add(typeof(PauseMenuState), new PauseMenuState(this, menu));
            states.Add(typeof(WinState), new WinState(this, menu));
            states.Add(typeof(LoseState), new LoseState(this, menu));
            states.Add(typeof(TrainingState), new TrainingState(this, menu));

            currentState = new GameState(this);

            if (isLvl0)
                ChangeState(typeof(TrainingState));

            MainTower.OnTowerDestroy += ChangeState;
            SceneLoader.OnSceneChange += ChangeState;
        }

        public void ChangeState(Type type)
        {
            currentState.Exit();
            states.TryGetValue(type, out currentState);
            currentState.Enter();
            Debug.Log(type);
            MainTower.OnTowerDestroy -= ChangeState;
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}