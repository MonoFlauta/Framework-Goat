using System;

namespace FrameworkGoat.DecisionTree
{
    public class ActionNode : Node
    {
        private Action _action;

        /// <summary>
        /// Creates an action Node
        /// </summary>
        /// <param name="action">The action to execute</param>
        public ActionNode(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Makes the action
        /// </summary>
        public override void Action()
        {
            _action();
        }
    }
}