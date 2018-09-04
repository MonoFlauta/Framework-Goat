namespace FrameworkGoat
{
    /// <summary>
    /// Unnecessary decision tree container. If you want, you can use it, otherwise, you can use the nodes directly.
    /// </summary>
    public abstract class DecisionTree
    {
        protected Node _startNode;
        
        /// <summary>
        /// Executes the Decision Tree
        /// </summary>
        public void Execute()
        {
            _startNode.Action();
        }

        /// <summary>
        /// Method you should overwrite and create inside the tree
        /// </summary>
        /// <param name="startNode">The start node</param>
        public virtual void CreateDecisionTree(Node startNode)
        {
            _startNode = startNode;
        }
    }
}