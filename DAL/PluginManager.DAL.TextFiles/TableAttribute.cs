﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  .Net Core Plugin Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Service Manager under the GPL, then the GPL applies to all loadable 
 *  Service Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2018 - 2022 Simon Carter.  All Rights Reserved.
 *
 *  Product:  PluginManager.DAL.TextFiles
 *  
 *  File: TableAttribute.cs
 *
 *  Purpose:  TableAttribute for text based storage
 *
 *  Date        Name                Reason
 *  23/05/2022  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.DAL.TextFiles
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName, CompressionType compression = CompressionType.None, CachingStrategy cachingStrategy = CachingStrategy.None)
        {
            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));

            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                if (tableName.Contains(c))
                    throw new ArgumentException($"Tablename contains invalid character: {c}", nameof(tableName));
            }

            TableName = tableName;
            Compression = compression;
            CachingStrategy = cachingStrategy;
        }

        public string TableName { get; }

        public CompressionType Compression { get; }

        public CachingStrategy CachingStrategy { get; }
    }
}
