using UnityEngine;

namespace State
{
    class PauseMenuState : AState
    {
        private GameObject pauseMenu;

        public PauseMenuState(StateMachine owner, Menu menu) : base(owner)
        {
            pauseMenu = menu.PauseMenu;
        }

        public override void Enter()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                owner.ChangeState(typeof(GameState));
        }
    }
}
