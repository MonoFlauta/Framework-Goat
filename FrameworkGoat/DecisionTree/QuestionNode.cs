using System;

namespace FrameworkGoat
{
    public class QuestionNode : INode
    {
        private readonly Func<bool> _evaluation;
        private readonly INode _affirmativeNode;
        private readonly INode _negativeNode;

        /// <summary>
        /// Creates a Question Node
        /// </summary>
        /// <param name="evaluation">The evaluation Func</param>
        /// <param name="affirmativeNode">The affirmative result node</param>
        /// <param name="negativeNode">The negative result node</param>
        public QuestionNode(Func<bool> evaluation, INode affirmativeNode = null, INode negativeNode = null)
        {
            _evaluation = evaluation;
            _affirmativeNode = affirmativeNode;
            _negativeNode = negativeNode;
        }

        /// <summary>
        /// Evaluates and executes the result
        /// </summary>
        public void Action()
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