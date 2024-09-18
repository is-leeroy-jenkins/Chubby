﻿// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="CommandBase.cs" company="Terry D. Eppler">
// 
//    Chubby is a WPF-based desktop application that  offers real-time
//    tracking of processes, network traffic, process trees, remote IP connections,
//    packet dissection, and more. The application is designed
//    using the MVVM (Model-View-ViewModel) architecture, ensuring clean code
//    separation and easy maintainability.
// 
//     Copyright ©  2020 Terry D. Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   CommandBase.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Windows.Input;

    public abstract class CommandBase : ICommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Occurs when changes occur that affect whether
        /// or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        /// <summary>
        /// Defines the method that determines whether the
        /// command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.
        /// If the command does not require data to be passed,
        /// this object can be set to <see langword="null" />.
        /// </param>
        /// <returns>
        ///   <see langword="true" /> if this command can
        /// be executed; otherwise, <see langword="false" />.
        /// </returns>
        public virtual bool CanExecute( object parameter )
        {
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.
        /// If the command does not require data to be passed,
        /// this object can be set to <see langword="null" />.
        /// </param>
        public abstract void Execute( object parameter );

        /// <summary>
        /// Called when [can execute changed].
        /// </summary>
        public void OnCanExecuteChanged( )
        {
            CanExecuteChanged?.Invoke( this, EventArgs.Empty );
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private static void Fail(Exception _ex)
        {
            var _error = new ErrorWindow(_ex);
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}