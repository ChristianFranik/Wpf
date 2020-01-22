using System;
using System.Windows.Input;

namespace Wpf.Command
{
    /// <summary>
    /// General command delegate to handle commands in view model
    /// </summary>
    public class CommandDelegate : ICommand
    {
        //======================================================================
        // Properties
        //======================================================================
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        //======================================================================
        // Constructors
        //======================================================================
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="executeAction">Action to be executed when command is executed</param>
        /// <param name="canExecuteAction">Function to evaluate whether a command can be executed</param>
        public CommandDelegate(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //======================================================================
        // Public methods
        //======================================================================
        /// <summary>
        /// Executes the command (delegate)
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => _executeAction(parameter);
        /// <summary>
        /// Implementation of <c>ICommand.CanExecute</c>. Checks evaluation function.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;
        /// <summary>
        /// Implementation of <c>ICommand.CanExecuteChanged</c>
        /// </summary>
        public event System.EventHandler CanExecuteChanged;
        /// <summary>
        /// Invokes event when condition whether command can execute changes
        /// </summary>
        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
    }
}
