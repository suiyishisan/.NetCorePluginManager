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
 *  File: TableDeliveryAddress.cs
 *
 *  Purpose:  Table for delivery addresses
 *
 *  Date        Name                Reason
 *  31/05/2022  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginManager.DAL.TextFiles.Tables
{
    /// <summary>
    /// Delivery address table 
    /// </summary>
    [Table("Address", CompressionType.Brotli)]
    internal class TableAddressRow : BaseRow
    {
        /// <summary>
        /// Id of user owning the address
        /// </summary>
        [ForeignKey("Users")]
        public long UserId { get; set; }

        /// <summary>
        /// Shipping costs for the address.
        /// </summary>
        /// <value>decimal</value>
        public decimal Shipping { get; set; }

        /// <summary>
        /// Business name if applicable.
        /// </summary>
        /// <value>string</value>
        public string BusinessName { get; set; }

        /// <summary>
        /// Address line 1.
        /// </summary>
        /// <value>string</value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2.
        /// </summary>
        /// <value>string</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Address line 3.
        /// </summary>
        /// <value>string</value>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <value>string</value>
        public string City { get; set; }

        /// <summary>
        /// County/state name.
        /// </summary>
        /// <value>string</value>
        public string County { get; set; }

        /// <summary>
        /// Postal or zip code.
        /// </summary>
        /// <value>string</value>
        public string Postcode { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <value>string</value>
        public string Country { get; set; }

        /// <summary>
        /// Postage cost for the address.
        /// </summary>
        /// <value>decimal</value>
        public decimal PostageCost { get; set; }

        /// <summary>
        /// Indicicates whether it's a delivery address or billing address
        /// </summary>
        public bool IsDelivery { get; set; }
    }
}
