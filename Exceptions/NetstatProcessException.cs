// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-18-2024
// ******************************************************************************************
// <copyright file="NetstatProcessException.cs" company="Terry D. Eppler">
// 
//    Chubby is a network toolkit ( iperf, tcp, udp, websocket, mqtt,
//    sniffer, pcap, port scan, listen, ip scan .etc.)
// 
//    Copyright ©  2023 Terry D. Eppler
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
//   NetstatProcessException.cs
// </summary>
// ******************************************************************************************

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Chubby
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class NetstatProcessException : Exception
    {
        /// <summary>
        /// The netstat process
        /// </summary>
        private Process _netstatProcess;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubby.NetstatProcessException" /> class.
        /// </summary>
        /// <param name="netstatProcess">The netstat process.</param>
        public NetstatProcessException( Process netstatProcess )
        {
            _netstatProcess = netstatProcess;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubby.NetstatProcessException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="netstatProcess">The netstat process.</param>
        public NetstatProcessException( string message, Process netstatProcess )
            : base( message )
        {
            _netstatProcess = netstatProcess;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chubby.NetstatProcessException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="netstatProcess">The netstat process.</param>
        public NetstatProcessException( string message, Exception innerException,
            Process netstatProcess )
            : base( message, innerException )
        {
            _netstatProcess = netstatProcess;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Chubby.NetstatProcessException" /> class.
        /// </summary>
        /// <param name="info">The
        /// <see cref="T:System.Runtime.Serialization.SerializationInfo" />
        /// that holds the serialized object data about
        /// the exception being thrown.</param>
        /// <param name="context">The
        /// <see cref="T:System.Runtime.Serialization.StreamingContext" />
        /// that contains contextual information about
        /// the source or destination.</param>
        protected NetstatProcessException( SerializationInfo info, StreamingContext context )
            : base( info, context )
        {
        }
    }
}