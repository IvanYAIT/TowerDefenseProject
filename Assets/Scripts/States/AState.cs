namespace State
{
    abstract class AState
    {
        protected StateMachine owner;

        public AState(StateMachine owner)
        {
            this.owner = owner;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}