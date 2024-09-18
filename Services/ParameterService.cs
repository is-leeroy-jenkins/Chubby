// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-18-2024
// ******************************************************************************************
// <copyright file="ParameterNavigationService.cs" company="Terry D. Eppler">
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
//   ParameterNavigationService.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">The type of the parameter.</typeparam>
    /// <typeparam name="T2">The type of the param2.</typeparam>
    /// <typeparam name="ViewModel">The type of the view model.</typeparam>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class ParameterService<T1, T2, ViewModel>
        where ViewModel : ViewModelBase
    {
        /// <summary>
        /// The navigation store
        /// </summary>
        private NavigationStore _navigationStore;

        /// <summary>
        /// The set view model
        /// </summary>
        private Func<T1, T2, ViewModel> _setViewModel;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ParameterService{T1,T2,ViewModel}"/> class.
        /// </summary>
        /// <param name="navigationStore">The navigation store.</param>
        /// <param name="setViewModel">The set view model.</param>
        public ParameterService( NavigationStore navigationStore,
            Func<T1, T2, ViewModel> setViewModel )
        {
            _navigationStore = navigationStore;
            _setViewModel = setViewModel;
        }

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="param2">The param2.</param>
        public void Navigate( T1 param, T2 param2 )
        {
            _navigationStore.CurrentViewModel = _setViewModel( param, param2 );
        }
    }
}