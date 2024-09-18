// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 09-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        09-15-2024
// ******************************************************************************************
// <copyright file="PathBase.cs" company="Terry D. Eppler">
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
//   PathBase.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Security.AccessControl;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "ReplaceAutoPropertyWithComputedProperty" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class PathBase
    {
        /// <summary>
        /// The has extension
        /// </summary>
        private protected bool _hasExtension;

        /// <summary>
        /// Gets or sets a value indicating
        /// whether this instance has parent.
        /// </summary>
        /// <value>
        /// <c>true</c>
        /// if this instance has parent;
        /// otherwise,
        /// <c>false</c>.
        /// </value>
        private protected bool _hasParent;

        /// <summary>
        /// The directory separator
        /// </summary>
        private protected char _folderSeparator;

        /// <summary>
        /// The path separator
        /// </summary>
        private protected char _pathSeparator;

        /// <summary>
        /// The drive separator
        /// </summary>
        private protected char _driveSeparator;

        /// <summary>
        /// The drive 
        /// </summary>
        private protected string _drive;

        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        private protected string _input;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected string _fileName;

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        private protected string _fullPath;

        /// <summary>
        /// Gets or sets the absolute path.
        /// </summary>
        /// <value>
        /// The absolute path.
        /// </value>
        private protected string _absolutePath;

        /// <summary>
        /// The relative path
        /// </summary>
        private protected string _relativePath;

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        private protected DateTime _modified;

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        private protected DateTime _created;

        /// <summary>
        /// The is rooted
        /// </summary>
        private protected bool _isRooted;

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        private protected long _length;

        /// <summary>
        /// 
        /// </summary>
        private protected string _fileExtension;

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        private protected FileAttributes _fileAttributes;

        /// <summary>
        /// Gets or sets the file security.
        /// </summary>
        /// <value>
        /// The file security.
        /// </value>
        private protected FileSecurity _fileSecurity;

        /// <summary>
        /// The invalid path chars
        /// </summary>
        private protected char[ ] _invalidPathChars;

        /// <summary>
        /// The invalid name chars
        /// </summary>
        private protected char[ ] _invalidNameChars;

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private protected static void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}