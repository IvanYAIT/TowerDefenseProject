using UnityEngine;

namespace State
{
    class PauseMenuState : AState
    {
        private GameObject pauseMenu;
        private AudioSource musicPlayer;

        public PauseMenuState(StateMachine owner, Menu menu) : base(owner)
        {
            pauseMenu = menu.PauseMenu;
            musicPlayer = menu.MusicPlayer.GetComponent<AudioSource>();
        }

        public override void Enter()
        {
            pauseMenu.SetActive(true);
            musicPlayer.Pause();
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            pauseMenu.SetActive(false);
            musicPlayer.UnPause();
            Time.timeScale = 1;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                owner.ChangeState(typeof(GameState));
        }
    }
}
