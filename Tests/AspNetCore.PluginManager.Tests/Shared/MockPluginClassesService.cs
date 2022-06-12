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
 *  Copyright (c) 2018 - 2021 Simon Carter.  All Rights Reserved.
 *
 *  Product:  AspNetCore.PluginManager.Tests
 *  
 *  File: MockPluginClassesService.cs
 *
 *  Purpose:  Test IPluginClassesService implementation
 *
 *  Date        Name                Reason
 *  29/03/2021  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using PluginManager.Abstractions;

namespace AspNetCore.PluginManager.Tests.Shared
{
    [ExcludeFromCodeCoverage]
    public class MockPluginClassesService : IPluginClassesService
    {
        private readonly List<object> _items;

        public MockPluginClassesService()
        {

        }

        public MockPluginClassesService(List<object> items)
        {
            _items = items ?? new List<object>();
        }

        public List<T> GetPluginClasses<T>()
        {
            List<T> Result = new List<T>();

            if (_items != null)
            {
                foreach (object item in _items)
                {
                    if (item.GetType().IsAssignableTo(typeof(T)))
                        Result.Add((T)item);
                }
            }

            return Result;
        }

        public List<Type> GetPluginClassTypes<T>()
        {
            throw new NotImplementedException();
        }
    }
}
