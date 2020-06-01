namespace FrameworkGoat
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        void Execute();
        /// <summary>
        /// UnExecutes the command
        /// </summary>
        void UnExecute();
    }
}