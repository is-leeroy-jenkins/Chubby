// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="NavigationService.cs" company="Terry D. Eppler">
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
//   NavigationService.cs
// </summary>

namespace Chubby
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="_viewModel">
    /// The type of the view model.
    /// </typeparam>
    public class NavigationService<_viewModel>
        where _viewModel : ViewModelBase
    {
        /// <summary>
        /// The navigation store
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// The set view model
        /// </summary>
        private readonly Func<_viewModel> _setViewModel;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NavigationService{TViewModel}"/> class.
        /// </summary>
        /// <param name="navigationStore">The navigation store.</param>
        /// <param name="setViewModel">The set view model.</param>
        public NavigationService( NavigationStore navigationStore, Func<_viewModel> setViewModel )
        {
            _navigationStore = navigationStore;
            _setViewModel = setViewModel;
        }

        /// <summary>
        /// Navigates this instance.
        /// </summary>
        public void Navigate( )
        {
            _navigationStore.CurrentViewModel = _setViewModel( );
        }
    }
}