using System;
using UnityEngine;

namespace State
{
    class TrainingState : AState
    {
        private GameObject trainingMenu;

        public TrainingState(StateMachine owner, Menu menu) : base(owner)
        {
            trainingMenu = menu.TrainingMenu;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            trainingMenu.SetActive(true);
        }

        public override void Exit()
        {
            Time.timeScale = 1;
            trainingMenu.SetActive(false);
        }

        public override void Update()
        {
            
        }
    }
}
