// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="AnalysisViewModel.cs" company="Terry D. Eppler">
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
//   AnalysisViewModel.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Chubby.ViewModelBase" />
    public class AnalysisViewModel : ViewModelBase
    {
        /// <summary>
        /// The original active process list
        /// </summary>
        private readonly IEnumerable<TcpProcess> _activeProcessList;

        /// <summary>
        /// The selected TCP process
        /// </summary>
        private TcpProcess _tcpProcess;

        /// <summary>
        /// Gets the related processes.
        /// </summary>
        /// <value>
        /// The related processes.
        /// </value>
        public IEnumerable<TcpProcess> RelatedProcesses { get; }

        /// <summary>
        /// Gets the local ports.
        /// </summary>
        /// <value>
        /// The local ports.
        /// </value>
        public IEnumerable<int> LocalPorts
        {
            get
            {
                return RelatedProcesses.Select( p => p.LocalPort );
            }
        }

        /// <summary>
        /// Gets the local i ps.
        /// </summary>
        /// <value>
        /// The local i ps.
        /// </value>
        public IEnumerable<IPAddress> LocalIPs
        {
            get
            {
                return RelatedProcesses.Select( p => p.LocalIp );
            }
        }

        /// <summary>
        /// Gets the remote ports.
        /// </summary>
        /// <value>
        /// The remote ports.
        /// </value>
        public IEnumerable<int> RemotePorts
        {
            get
            {
                return RelatedProcesses.Select( p => p.RemotePort );
            }
        }

        /// <summary>
        /// Gets the remote i ps.
        /// </summary>
        /// <value>
        /// The remote i ps.
        /// </value>
        public IEnumerable<IPAddress> RemoteIPs
        {
            get
            {
                return RelatedProcesses.Select( p => p.RemoteIp );
            }
        }

        /// <summary>
        /// Gets or sets the selected TCP process.
        /// </summary>
        /// <value>
        /// The selected TCP process.
        /// </value>
        public TcpProcess TcpProcess
        {
            get
            {
                return _tcpProcess;
            }
            set
            {
                Set( ref _tcpProcess, value );
            }
        }

        /// <summary>
        /// Gets the process count.
        /// </summary>
        /// <value>
        /// The process count.
        /// </value>
        public int? ProcessCount
        {
            get
            {
                return RelatedProcesses?.Count( );
            }
        }

        /// <summary>
        /// Gets the close command.
        /// </summary>
        /// <value>
        /// The close command.
        /// </value>
        public ICommand CloseCommand { get; }

        /// <summary>
        /// Gets the previous view command.
        /// </summary>
        /// <value>
        /// The previous view command.
        /// </value>
        public ICommand PreviousViewCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisViewModel"/> class.
        /// </summary>
        /// <param name="navigationStore">The navigation store.</param>
        /// <param name="relatedProcesses">The related processes.</param>
        /// <param name="tcpProcesspProcess">The selected TCP process.</param>
        public AnalysisViewModel( NavigationStore navigationStore,
            IEnumerable<TcpProcess> relatedProcesses, TcpProcess tcpProcess )
        {
            _activeProcessList = relatedProcesses;
            _tcpProcess = tcpProcess;
            RelatedProcesses = GetRelatedProcesses( _activeProcessList );
            CloseCommand = new CloseCommand( );
            PreviousViewCommand = new NavigateCommand<ProcessViewModel>(
                new NavigationService<ProcessViewModel>( navigationStore,
                    ( ) => new ProcessViewModel( navigationStore, TcpProcess,
                        _activeProcessList ) ) );
        }

        /// <summary>
        /// Gets the related processes.
        /// </summary>
        /// <param name="relatedProcesses">The related processes.</param>
        /// <returns></returns>
        private IEnumerable<TcpProcess> GetRelatedProcesses(
            IEnumerable<TcpProcess> relatedProcesses )
        {
            return relatedProcesses.Where( p => p.ProcessName == _tcpProcess.ProcessName );
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