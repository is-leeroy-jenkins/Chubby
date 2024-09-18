// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-16-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-16-2024
// ******************************************************************************************
// <copyright file="MoveCommand.cs" company="Terry D. Eppler">
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
//   MoveCommand.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chubby.CommandBase" />
    public class MoveCommand : CommandBase
    {
        /// <summary>
        /// The vm
        /// </summary>
        private ProcessViewModel _processViewModel;

        /// <summary>
        /// The navigation store
        /// </summary>
        private NavigationStore _navigationStore;

        /// <summary>
        /// The is next
        /// </summary>
        private bool _isNext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveCommand"/> class.
        /// </summary>
        /// <param name="navigationStore">The navigation store.</param>
        /// <param name="processViewModel">The vm.</param>
        /// <param name="isNext">if set to <c>true</c> [is next].</param>
        public MoveCommand( NavigationStore navigationStore, ProcessViewModel processViewModel,
            bool isNext )
        {
            _navigationStore = navigationStore;
            _processViewModel = processViewModel;
            _isNext = isNext;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public override void Execute( object parameter )
        {
            Move( _isNext );
            _processViewModel.AssociatedProcessesCount =
                _processViewModel.GetAssociatedProcessNumber( _processViewModel.SelectedProcess );

            var _oldVm = _processViewModel;
            _processViewModel = new ProcessViewModel( _navigationStore, _oldVm.SelectedProcess,
                _oldVm.Processes );

            _navigationStore.CurrentViewModel = _processViewModel;
        }

        /// <summary>
        /// Moves the specified is next.
        /// </summary>
        /// <param name="isNext">if set to <c>true</c> [is next].</param>
        private void Move( bool isNext )
        {
            var _selectedProcess = _processViewModel.SelectedProcess;
            var _index = _processViewModel.Processes.ToList( ).IndexOf( _selectedProcess );
            if( isNext )
            {
                if( _index + 1 < _processViewModel.Processes.Count( )
                    && _processViewModel.Processes.ToList( )[ _index + 1 ] != null )
                {
                    _processViewModel.SelectedProcess =
                        _processViewModel.Processes.ToList( )[ _index + 1 ];
                }
                else
                {
                    MessageBox.Show( "There is no More Processes To Browse", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Information );
                }
            }
            else if( !isNext )
            {
                if( _index - 1 >= 0 )
                {
                    _processViewModel.SelectedProcess =
                        _processViewModel.Processes.ToList( )[ _index - 1 ];
                }
                else
                {
                    MessageBox.Show( "There is no More Processes To Browse", "Warning",
                        MessageBoxButton.OK, MessageBoxImage.Information );
                }
            }
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private static void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}