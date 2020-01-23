using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf
{
    public abstract class Notifier : INotifyPropertyChanged
    {
        //======================================================================
        // Public methods
        //======================================================================
        /// <summary>
        /// Event handler for property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //======================================================================
        // Protected methods
        //======================================================================
        /// <summary>
        /// Invoker for property change event
        /// </summary>
        /// <param name="propertyName">Name of the changed property. Gets supplied by runtime</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Template method to set properties in inheriting classes
        /// </summary>
        /// <typeparam name="T">property type</typeparam>
        /// <param name="storage">(Private) variable that stores the property value</param>
        /// <param name="value">(New) value to set</param>
        /// <param name="propertyName">Name of the changed property. Gets supplied by runtime</param>
        /// <returns></returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
