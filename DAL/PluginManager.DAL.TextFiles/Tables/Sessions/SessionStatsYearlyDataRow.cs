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
 *  Copyright (c) 2018 - 2023 Simon Carter.  All Rights Reserved.
 *
 *  Product:  PluginManager.DAL.TextFiles
 *  
 *  File: SessionStatsYearlyDataRow.cs
 *
 *  Purpose:  Yearly session statistics
 *
 *  Date        Name                Reason
 *  11/08/2022  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using SimpleDB;

namespace PluginManager.DAL.TextFiles.Tables
{
	[Table(Constants.DomainSessions, Constants.TableNameSessionStatsYearly, CompressionType.Brotli, CachingStrategy.SlidingMemory, WriteStrategy.Lazy)]
	internal class SessionStatsYearlyDataRow : SessionStatsBaseData
	{
		private int _year;
		private bool _isBot;

		[UniqueIndex("YearlySessionData")]
		public bool IsBot
		{
			get => _isBot;

			set
			{
				if (value == _isBot)
					return;

				_isBot = value;
				Update();
			}
		}

		[UniqueIndex("YearlySessionData")]
		public int Year
		{
			get => _year;

			set
			{
				if (_year == value)
					return;

				_year = value;
				Update();
			}
		}
	}
}
