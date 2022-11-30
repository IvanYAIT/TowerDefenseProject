using UnityEngine;

namespace State
{
    class LoseState : AState
    {
        private GameObject loseMenu;

        public LoseState(StateMachine owner, Menu menu) : base(owner)
        {
            loseMenu = menu.LoseMenu;
        }

        public override void Enter()
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            loseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
                owner.ChangeState(typeof(GameState));

        }
    }
}
