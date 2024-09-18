// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="TcpProcess.cs" company="Terry D. Eppler">
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
//   TcpProcess.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System.Net;

    /// <summary>
    /// 
    /// </summary>
    public class TcpProcess
    {
        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get; }

        /// <summary>
        /// Gets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        public int ProcessID { get; }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>
        /// The protocol.
        /// </value>
        public string Protocol { get; }

        /// <summary>
        /// Gets the local ip.
        /// </summary>
        /// <value>
        /// The local ip.
        /// </value>
        public IPAddress LocalIp { get; }

        /// <summary>
        /// Gets the local port.
        /// </summary>
        /// <value>
        /// The local port.
        /// </value>
        public int LocalPort { get; }

        /// <summary>
        /// Gets the remote ip.
        /// </summary>
        /// <value>
        /// The remote ip.
        /// </value>
        public IPAddress RemoteIp { get; }

        /// <summary>
        /// Gets the remote port.
        /// </summary>
        /// <value>
        /// The remote port.
        /// </value>
        public int RemotePort { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpProcess"/> class.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="processID">The process identifier.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="localIp">The local ip.</param>
        /// <param name="localPort">The local port.</param>
        /// <param name="remoteIp">The remote ip.</param>
        /// <param name="remotePort">The remote port.</param>
        /// <param name="status">The status.</param>
        public TcpProcess( string processName, int processID, string protocol,
            IPAddress localIp, int localPort, IPAddress remoteIp,
            int remotePort, string status )
        {
            ProcessName = processName;
            ProcessID = processID;
            Protocol = protocol;
            LocalIp = localIp;
            LocalPort = localPort;
            RemoteIp = remoteIp;
            RemotePort = remotePort;
            Status = status;
        }
    }
}