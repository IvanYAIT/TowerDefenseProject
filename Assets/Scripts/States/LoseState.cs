using UnityEngine;

namespace State
{
    class LoseState : AState
    {
        private GameObject loseMenu;
        private AudioSource music;

        public LoseState(StateMachine owner, Menu menu) : base(owner)
        {
            loseMenu = menu.LoseMenu;
            music = menu.MusicPlayer.GetComponent<AudioSource>();
        }

        public override void Enter()
        {
            loseMenu.SetActive(true);
            music.Stop();
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            loseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.PageDown))
                owner.ChangeState(typeof(GameState));

        }
    }
}
