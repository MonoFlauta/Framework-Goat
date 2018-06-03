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
        /// Adds a new state
        /// </summary>
        /// <typeparam name="TS">Type of the state</typeparam>
        public void AddState<TS>() where TS:State<T>, new()
        {
            _states[typeof(TS)] = new TS().SetState(this, _owner);
        }

        /// <summary>
        /// Sets the initial values to a given state and adds to the list of states
        /// </summary>
        /// <param name="state">The state to add</param>
        public void AddState(State<T> state)
        {
            state.SetState(this, _owner);
            _states[state.GetType()] = state;
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
        /// Returns a State given the type
        /// </summary>
        /// <typeparam name="TS">Type of the state to get</typeparam>
        /// <returns>The state of the type</returns>
        public TS GetState<TS>() where TS:State<T>
        {
            return _states[typeof(TS)] as TS;
        }

        /// <summary>
        /// Returns the current state
        /// </summary>
        /// <returns>Current state</returns>
        public State<T> GetCurrentState()
        {
            return _currentState;
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