﻿// ******************************************************************************************
//     Assembly:                Chubby
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="DictionaryExtensions.cs" company="Terry D. Eppler">
//    Chubby is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   DictionaryExtensions.cs
// </summary>
// ******************************************************************************************

namespace Chubby
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "LoopCanBePartlyConvertedToQuery" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Updates a IDictionary( K, V ) with a TKey and TValue or adds it
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TValue AddOrUpdate<TKey, TValue>( this IDictionary<TKey, TValue> dict,
            TKey key, TValue value )
        {
            try
            {
                if( !dict.ContainsKey( key ) )
                {
                    dict.Add( new KeyValuePair<TKey, TValue>( key, value ) );
                }
                else
                {
                    dict[ key ] = value;
                }

                return dict[ key ];
            }
            catch( Exception ex )
            {
                DictionaryExtensions.Fail( ex );
                return default( TValue );
            }
        }

        /// <summary>
        /// Converts an IDictionary( K, V ) into a NameValueCollection
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns>
        /// NameValueCollection
        /// </returns>
        public static NameValueCollection ToNameValueCollection(
            this IDictionary<string, object> dict )
        {
            try
            {
                var _nvp = new NameValueCollection( );
                foreach( var _kvp in dict )
                {
                    var _value = _kvp.Value.ToString( );
                    _nvp?.Add( _kvp.Key, _value );
                }

                return _nvp.Count > 0
                    ? _nvp
                    : default( NameValueCollection );
            }
            catch( Exception ex )
            {
                DictionaryExtensions.Fail( ex );
                return default( NameValueCollection );
            }
        }

        /// <summary>
        /// Predicates the specified logic.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns></returns>
        public static string ToCriteria( this IDictionary<string, object> dict )
        {
            if( dict?.Any( ) == true )
            {
                try
                {
                    var _criteria = "";
                    var _key = dict.Keys.First( );
                    var _value = dict[ _key ].ToString( );
                    if( !string.IsNullOrEmpty( _key )
                        & ( int.Parse( _value ) > -1 ) )
                    {
                        foreach( var _kvp in dict )
                        {
                            _criteria += $"{_kvp.Key} = '{_kvp.Value}' AND ";
                        }

                        var _sql = _criteria.TrimEnd( " AND ".ToCharArray( ) );
                        _sql += $" WHERE {_key} = {int.Parse( _value )};";
                        return !string.IsNullOrEmpty( _sql )
                            ? _sql
                            : string.Empty;
                    }
                    else if( !string.IsNullOrEmpty( _key ) 
                        & ( int.Parse( _value ) > -1 ) )
                    {
                        foreach( var _kvp in dict )
                        {
                            _criteria += $"{_kvp.Key} = '{_kvp.Value}' AND ";
                        }

                        var _sql = _criteria.TrimEnd( " AND ".ToCharArray( ) );
                        return !string.IsNullOrEmpty( _sql )
                            ? _sql
                            : string.Empty;
                    }
                }
                catch( Exception ex )
                {
                    DictionaryExtensions.Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts an IDictionary( string, object) to a bindinglist.
        /// </summary>
        /// <param name="dictionary">The NVC.</param>
        /// <returns></returns>
        public static BindingList<KeyValuePair<string, object>> ToBindingList(
            this IDictionary<string, object> dictionary )
        {
            try
            {
                var _bindingList = new BindingList<KeyValuePair<string, object>>( );
                foreach( var _kvp in dictionary )
                {
                    _bindingList.Add( _kvp );
                }

                return _bindingList?.Any( ) == true
                    ? _bindingList
                    : default( BindingList<KeyValuePair<string, object>> );
            }
            catch( Exception ex )
            {
                DictionaryExtensions.Fail( ex );
                return default( BindingList<KeyValuePair<string, object>> );
            }
        }

        /// <summary>
        /// Converts an IDcitionary( T, V ) to a SortedList( int, KeyValuePair(string. object)).
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns>
        /// SortedList( T, V )
        /// </returns>
        public static SortedList<int, KeyValuePair<string, object>> ToSortedList(
            this IDictionary<string, object> dict )
        {
            try
            {
                if( dict?.Count > 0 )
                {
                    var _sortedList = new SortedList<int, KeyValuePair<string, object>>( );
                    var _keys = dict?.Keys.ToArray( );
                    var _values = dict?.Values.ToArray( );
                    for( var _i = 0; _i < dict?.Count; _i++ )
                    {
                        if( _values[ _i ] != null
                            && !string.IsNullOrEmpty( _keys[ _i ] ) )
                        {
                            var _kvp =
                                new KeyValuePair<string, object>( _keys[ _i ], _values[ _i ] );

                            _sortedList?.Add( _i, _kvp );
                        }
                    }

                    return _sortedList?.Count > 0
                        ? _sortedList
                        : default( SortedList<int, KeyValuePair<string, object>> );
                }

                return default( SortedList<int, KeyValuePair<string, object>> );
            }
            catch( Exception ex )
            {
                DictionaryExtensions.Fail( ex );
                return default( SortedList<int, KeyValuePair<string, object>> );
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private static void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}