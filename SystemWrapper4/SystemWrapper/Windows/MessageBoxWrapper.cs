using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using SystemInterface.Windows;

namespace SystemWrapper.Windows
{
    /// <summary>
    /// Wrapper for <see cref="T:System.Windows.MessageBox"/> class.
    /// </summary>
    public class MessageBoxWrapper : IMessageBox
    {
        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText)
        {
            return MessageBox.Show(messageBoxText);
        }

        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText, string caption)
        {
            return MessageBox.Show(messageBoxText, caption);
        }

        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return MessageBox.Show(messageBoxText, caption, button);
        }

        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon);
        }

        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
        }

        /// <inheritdoc />
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
        }
    }
}
