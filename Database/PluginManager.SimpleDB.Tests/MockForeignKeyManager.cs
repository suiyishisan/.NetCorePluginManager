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
 *  Product:  PluginManager.DAL.TextFiles.Tests
 *  
 *  File: MockForeignKeyManager.cs
 *
 *  Purpose:  Mock foreign key manager
 *
 *  Date        Name                Reason
 *  02/06/2022  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using PluginManager.SimpleDB;

namespace PluginManager.SimpleDB.Tests
{
    internal class MockForeignKeyManager : IForeignKeyManager
    {
        public List<string> RegisteredTables = new List<string>();

        public void AddRelationShip(string table, string targetTable, string propertyName, string targetPropertyName)
        {
            throw new NotImplementedException();
        }

        public bool ValueExists(string tableName, long id)
        {
            throw new NotImplementedException();
        }

        public void RegisterTable(ITextTable table)
        {
            RegisteredTables.Add(table.TableName);
        }

        public void UnregisterTable(ITextTable table)
        {
            RegisteredTables.Remove(table.TableName);
        }

        public bool ValueInUse(string tableName, string propertyName, long value, out string table, out string property)
        {
            throw new NotImplementedException();
        }
    }
}
