using UnityEngine;

namespace State
{
    class GameState : AState
    {
        public GameState(StateMachine owner) : base(owner)
        {
        }

        public override void Enter()
        {
            Time.timeScale = 1;
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                owner.ChangeState(typeof(PauseMenuState));
            if (Input.GetKeyDown(KeyCode.PageDown))
                owner.ChangeState(typeof(LoseState));
            if (Input.GetKeyDown(KeyCode.PageUp))
                owner.ChangeState(typeof(WinState));
        }
    }
}
