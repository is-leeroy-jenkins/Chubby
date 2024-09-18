// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-16-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-16-2024
// ******************************************************************************************
// <copyright file="ProcessViewModel.cs" company="Terry D. Eppler">
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
//   ProcessViewModel.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows.Input;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Chubby.ViewModelBase" />
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class ProcessViewModel : ViewModelBase
    {
        /// <summary>
        /// The selected process
        /// </summary>
        private TcpProcess _selectedProcess;

        /// <summary>
        /// The associated processes count
        /// </summary>
        private int _associatedProcessesCount;

        /// <summary>
        /// The processes
        /// </summary>
        public IEnumerable<TcpProcess> Processes;

        /// <summary>
        /// Gets or sets the associated processes count.
        /// </summary>
        /// <value>
        /// The associated processes count.
        /// </value>
        public int AssociatedProcessesCount
        {
            get
            {
                return _associatedProcessesCount;
            }
            set
            {
                Set( ref _associatedProcessesCount, value );
            }
        }

        /// <summary>
        /// Gets or sets the selected process.
        /// </summary>
        /// <value>
        /// The selected process.
        /// </value>
        public TcpProcess SelectedProcess
        {
            get
            {
                return _selectedProcess;
            }
            set
            {
                Set( ref _selectedProcess, value );
            }
        }

        /// <summary>
        /// Gets the next command.
        /// </summary>
        /// <value>
        /// The next command.
        /// </value>
        public ICommand NextCommand { get; }

        /// <summary>
        /// Gets the previous command.
        /// </summary>
        /// <value>
        /// The previous command.
        /// </value>
        public ICommand PreviousCommand { get; }

        /// <summary>
        /// Gets the associated processes command.
        /// </summary>
        /// <value>
        /// The associated processes command.
        /// </value>
        public ICommand AssociatedProcessesCommand { get; }

        /// <summary>
        /// Gets the close command.
        /// </summary>
        /// <value>
        /// The close command.
        /// </value>
        public ICommand CloseCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessViewModel"/> class.
        /// </summary>
        /// <param name="navigationStore">The navigation store.</param>
        /// <param name="process">The process.</param>
        /// <param name="processes">The processes.</param>
        public ProcessViewModel( NavigationStore navigationStore, TcpProcess process,
            IEnumerable<TcpProcess> processes )
        {
            _selectedProcess = process;
            Processes = processes;
            CloseCommand = new CloseCommand( );
            NextCommand = new MoveCommand( navigationStore, this, true );
            PreviousCommand = new MoveCommand( navigationStore, this, false );
            _associatedProcessesCount = GetAssociatedProcessNumber( SelectedProcess );
            AssociatedProcessesCommand = new NavigateAnalysisCommand( navigationStore, this );
        }

        /// <summary>
        /// Gets the associated process number.
        /// </summary>
        /// <param name="selectedProcess">The selected process.</param>
        /// <returns></returns>
        public int GetAssociatedProcessNumber( TcpProcess selectedProcess )
        {
            var _relatedProcesses = Processes
                .Where( p => p.ProcessName == selectedProcess.ProcessName ).ToList( );

            return _relatedProcesses.Count;
        }
    }
}