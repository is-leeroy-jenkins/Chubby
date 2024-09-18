// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="DetailsCommand.cs" company="Terry D. Eppler">
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
//   DetailsCommand.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chubby.CommandBase" />
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    public class DetailsCommand : CommandBase
    {
        /// <summary>
        /// The processes
        /// </summary>
        private readonly IEnumerable<TcpProcess> _processes;

        /// <summary>
        /// The navgiation store
        /// </summary>
        private NavigationStore _navgiationStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsCommand"/> class.
        /// </summary>
        /// <param name="tCpProcesses">The t cp processes.</param>
        public DetailsCommand( IEnumerable<TcpProcess> tCpProcesses )
        {
            _navgiationStore = new NavigationStore( );
            _processes = tCpProcesses;
        }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether this instance can
        /// execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute
        /// the specified parameter; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanExecute( object parameter )
        {
            return parameter != null;
        }

        /// <inheritdoc />
        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public override void Execute( object parameter )
        {
            _navgiationStore.CurrentViewModel = new ProcessViewModel( _navgiationStore,
                parameter as TcpProcess, _processes );

            var _secondWindow = new SecondWindow( )
            {
                DataContext = new MainViewModel( _navgiationStore )
            };

            _secondWindow.Show( );
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