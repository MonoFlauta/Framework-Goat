using System.Collections.Generic;

namespace FrameworkGoat.FiniteStateMachine
{
    public class FiniteStateMachine<T>
    {
        private T _owner;
        private Dictionary<System.Type, State<T>> _states;
        private State<T> _currentState;

        /// <summary>
        /// Creates a Finite State Machine
        /// </summary>
        /// <param name="owner">The owner of the state machine</param>
        public FiniteStateMachine(T owner)
        {
            _owner = owner;
        }
        
        /// <summary>
        /// Adds a state
        /// </summary>
        /// <param name="state">State to add</param>
        public void AddState(State<T> state)
        {
            state.SetStateMachine(this);
            _states.Add(state.GetType(), state);
        }

        /// <summary>
        /// Exits the current state and, if it exists, sets the new state and calls its enter
        /// </summary>
        /// <typeparam name="TS">Type of state to set</typeparam>
        public void SetState<TS>() where TS : State<T>
        {
            if (_currentState != null)
                _currentState.Exit();
            if (_states.ContainsKey(typeof(TS)))
            {
                _currentState = _states[typeof(TS)];
                _currentState.Enter();
            }
        }

        /// <summary>
        /// Updates the current state
        /// </summary>
        public void Update()
        {
            if(_currentState!=null)
                _currentState.Update();
        }

        /// <summary>
        /// Late updates the current state
        /// </summary>
        public void LateUpdate()
        {
            if (_currentState != null)
                _currentState.LateUpdate();
        }
    }
}