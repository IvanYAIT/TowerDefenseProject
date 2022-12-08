using System;
using UnityEngine;

namespace State
{
    class TrainingState : AState
    {
        private GameObject trainingMenu;
        private AudioSource musicPlayer;

        public TrainingState(StateMachine owner, Menu menu) : base(owner)
        {
            trainingMenu = menu.TrainingMenu;
            musicPlayer = menu.MusicPlayer.GetComponent<AudioSource>();
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            Training.OnPlayBtnPress += owner.ChangeState;
            musicPlayer.Stop();
            trainingMenu.SetActive(true);
        }

        public override void Exit()
        {
            Time.timeScale = 1;
            Training.OnPlayBtnPress -= owner.ChangeState;
            musicPlayer.Play();
            trainingMenu.SetActive(false);
        }

        public override void Update()
        {
            
        }
    }
}
