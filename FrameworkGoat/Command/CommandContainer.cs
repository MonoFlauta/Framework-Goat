using System.Collections.Generic;

namespace FrameworkGoat
{
    public class CommandContainer<T1, T2> where T2 : ICommand
    {
        private readonly Dictionary<T1, T2> _commands;

        /// <summary>
        /// Creates a Command Container
        /// </summary>
        public CommandContainer()
        {
            _commands = new Dictionary<T1, T2>();
        }

        /// <summary>
        /// Adds a command given a key and a command
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="command">Command</param>
        public void AddCommand(T1 key, T2 command)
        {
            _commands.Add(key, command);
        }

        /// <summary>
        /// Adds a command given a key and type of the command
        /// </summary>
        /// <typeparam name="T">Type of the command</typeparam>
        /// <param name="key">Key</param>
        public void AddCommand<T>(T1 key) where T : T2, new()
        {
            _commands.Add(key, new T());
        }

        /// <summary>
        /// Removes a command
        /// </summary>
        /// <param name="key">Key</param>
        public void RemoveCommand(T1 key)
        {
            _commands.Remove(key);
        }

        /// <summary>
        /// Clears the command container
        /// </summary>
        public void ClearCommandContainer()
        {
            _commands.Clear();
        }

        /// <summary>
        /// Gets a command by its key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Command</returns>
        public ICommand GetCommand(T1 key)
        {
            return _commands[key];
        }

        /// <summary>
        /// Executes a command
        /// </summary>
        /// <param name="key">Key</param>
        public void ExecuteCommand(T1 key)
        {
            _commands[key].Execute();
        }

        /// <summary>
        /// UnExecutes a command
        /// </summary>
        /// <param name="key">Key</param>
        public void UnExecuteCommand(T1 key)
        {
            _commands[key].UnExecute();
        }
    }
}