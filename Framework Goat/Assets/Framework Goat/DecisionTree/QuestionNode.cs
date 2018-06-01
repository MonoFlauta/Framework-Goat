using System;

namespace FrameworkGoat.DecisionTree
{
    public class QuestionNode : Node
    {
        private Func<bool> _evaluation;
        private Node _affirmativeNode;
        private Node _negativeNode;

        /// <summary>
        /// Creates a Question Node
        /// </summary>
        /// <param name="evaluation">The evaluation Func</param>
        /// <param name="affirmativeNode">The affirmative result node</param>
        /// <param name="negativeNode">The negative result node</param>
        public QuestionNode(Func<bool> evaluation, Node affirmativeNode = null, Node negativeNode = null)
        {
            _evaluation = evaluation;
            _affirmativeNode = affirmativeNode;
            _negativeNode = negativeNode;
        }

        /// <summary>
        /// Evaluates and executes the result
        /// </summary>
        public override void Action()
        {
            if (_evaluation())
            {
                if(_affirmativeNode != null) _affirmativeNode.Action();
            }
            else if(_negativeNode != null)
                _negativeNode.Action();
        }
    }
}