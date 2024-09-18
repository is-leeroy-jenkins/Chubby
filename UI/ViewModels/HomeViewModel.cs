// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="HomeViewModel.cs" company="Terry D. Eppler">
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
//   HomeViewModel.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Chubby.ViewModelBase" />
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class HomeViewModel : ViewModelBase
    {
        /// <summary>
        /// The process count
        /// </summary>
        private int _processCount;

        /// <summary>
        /// The current TCP process
        /// </summary>
        private TcpProcess _currentProcess;

        /// <summary>
        /// The search value
        /// </summary>
        private string _searchValue;

        /// <summary>
        /// Gets or sets the process count.
        /// </summary>
        /// <value>
        /// The process count.
        /// </value>
        public int ProcessCount
        {
            get
            {
                return _processCount;
            }
            set
            {
                Set( ref _processCount, value );
            }
        }

        /// <summary>
        /// Gets or sets the current TCP process.
        /// </summary>
        /// <value>
        /// The current TCP process.
        /// </value>
        public TcpProcess CurrentProcess
        {
            get
            {
                return _currentProcess;
            }
            set
            {
                Set( ref _currentProcess, value );
            }
        }

        /// <summary>
        /// Gets or sets the search value.
        /// </summary>
        /// <value>
        /// The search value.
        /// </value>
        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                Set( ref _searchValue, value );
                UpdateProcessesList( _searchValue );
            }
        }

        /// <summary>
        /// Gets the active TCP processes.
        /// </summary>
        /// <value>
        /// The active TCP processes.
        /// </value>
        public ObservableCollection<TcpProcess> ActiveTcpProcesses { get; }

        /// <summary>
        /// Gets the refresh command.
        /// </summary>
        /// <value>
        /// The refresh command.
        /// </value>
        public ICommand RefreshCommand { get; }

        /// <summary>
        /// Gets the clear command.
        /// </summary>
        /// <value>
        /// The clear command.
        /// </value>
        public ICommand ClearCommand { get; }

        /// <summary>
        /// Gets the details command.
        /// </summary>
        /// <value>
        /// The details command.
        /// </value>
        public ICommand DetailsCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="netstatOutput">The netstat output.</param>
        public HomeViewModel( List<string> netstatOutput )
        {
            ActiveTcpProcesses =
                new ObservableCollection<TcpProcess>( GetActiveProcesses( netstatOutput ) );

            _processCount = ActiveTcpProcesses.Count;
            ClearCommand = new ClearCommand( this );
            RefreshCommand = new RefreshCommand( this );
            DetailsCommand = new DetailsCommand( ActiveTcpProcesses );
        }

        /// <summary>
        /// Gets the active processes.
        /// </summary>
        /// <param name="netstatOutput">The netstat output.</param>
        /// <returns></returns>
        public IEnumerable<TcpProcess> GetActiveProcesses( List<string> netstatOutput )
        {
            if( netstatOutput.Count > 0 )
            {
                foreach( var _line in netstatOutput )
                {
                    var _process = GetTcpProcess( _line );
                    yield return _process;
                }
            }
        }

        /// <summary>
        /// Gets the TCP process.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        private TcpProcess GetTcpProcess( string line )
        {
            var _columns = Regex.Split( line.Trim( ), "\\s+" );
            var _protocol = _columns[ 0 ];
            var _localComm = _columns[ 1 ].Split( ':' );
            var _remoteComm = _columns[ 2 ].Split( ':' );
            var _localIp = IPAddress.Parse( _localComm[ 0 ] );
            var _localPort = int.Parse( _localComm[ 1 ] );
            var _remoteIp = IPAddress.Parse( _remoteComm[ 0 ] );
            var _remotePort = int.Parse( _remoteComm[ 1 ] );
            var _status = _columns[ 3 ];
            var _processId = int.Parse( _columns[ 4 ] );
            string _processName;
            try
            {
                _processName = Process.GetProcessById( _processId ).ProcessName;
            }
            catch( Exception )
            {
                _processName = "Unknown";
            }

            return new TcpProcess( _processName, _processId, _protocol, _localIp,
                _localPort, _remoteIp, _remotePort, _status );
        }

        /// <summary>
        /// Updates the processes list.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        private void UpdateProcessesList( string searchValue )
        {
            if( !string.IsNullOrEmpty( searchValue ) )
            {
                var _processes = ActiveTcpProcesses
                    .Where( p => p.ProcessName.StartsWith( searchValue ) ).ToList( );

                if( _processes.Count > 0 )
                {
                    ActiveTcpProcesses.Clear( );
                    foreach( var _process in _processes )
                    {
                        ActiveTcpProcesses.Add( _process );
                    }
                }
            }
        }
    }
}