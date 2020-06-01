using System;

namespace FrameworkGoat
{
    public class ActionNode : INode
    {
        private readonly Action _action;

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
        public void Action()
        {
            _action();
        }
    }
}