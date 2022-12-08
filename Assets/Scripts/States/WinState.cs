using Core;
using UnityEngine;

namespace State
{
    class WinState : AState
    {
        private GameObject winMenu;

        public WinState(StateMachine owner, Menu menu) : base(owner)
        {
            winMenu = menu.WinMenu;
        }

        public override void Enter()
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            winMenu.SetActive(false);
            Game.OnWin -= owner.ChangeState;
            Time.timeScale = 1;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.PageUp))
                owner.ChangeState(typeof(GameState));
        }
    }
}
