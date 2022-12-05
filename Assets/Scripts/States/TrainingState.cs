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
            musicPlayer.Stop();
            trainingMenu.SetActive(true);
        }

        public override void Exit()
        {
            Time.timeScale = 1;
            musicPlayer.Play();
            trainingMenu.SetActive(false);
        }

        public override void Update()
        {
            
        }
    }
}
