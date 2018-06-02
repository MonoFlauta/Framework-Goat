namespace FrameworkGoat.Command
{
    public abstract class Command
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        public abstract void Execute();
        /// <summary>
        /// UnExecutes the command
        /// </summary>
        public abstract void UnExecute();
    }
}