namespace FrameworkGoat.FiniteStateMachine
{
    public abstract class State<T>
    {
        protected T _owner;
        protected FiniteStateMachine<T> _stateMachine;
        
        /// <summary>
        /// Called by the Finite State Machine when creating a state. Sets the state values.
        /// </summary>
        /// <param name="sm">State machine</param>
        /// <param name="owner">Owner</param>
        /// <returns>The state</returns>
        public State<T> SetState(FiniteStateMachine<T> sm, T owner)
        {
            _stateMachine = sm;
            _owner = owner;
            return this;
        }

        /// <summary>
        /// Called when entering the state
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// Called to update the state
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Called to late update the state
        /// </summary>
        public abstract void LateUpdate();

        /// <summary>
        /// Called to exit the state
        /// </summary>
        public abstract void Exit();
    }
}