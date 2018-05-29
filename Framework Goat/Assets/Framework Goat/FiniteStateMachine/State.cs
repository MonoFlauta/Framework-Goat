namespace FrameworkGoat.FiniteStateMachine
{
    public abstract class State<T>
    {
        protected T _owner;
        protected FiniteStateMachine<T> _stateMachine;

        /// <summary>
        /// Constructor of the State
        /// </summary>
        /// <param name="owner">Owner of the state</param>
        public State(T owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Sets the Finite State Machine that owns this state. Automatically called from Finite State Machine when added the state.
        /// </summary>
        /// <param name="sm">The finite state machine</param>
        public void SetStateMachine(FiniteStateMachine<T> sm)
        {
            _stateMachine = sm;
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