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
 *  Copyright (c) 2012 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  PluginMiddleware
 *  
 *  File: IShoppingCartProvider.cs
 *
 *  Purpose:  User Account provider
 *
 *  Date        Name                Reason
 *  07/03/2019  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using Middleware.Products;
using Middleware.ShoppingCart;

using SharedPluginFeatures;

using Shared.Classes;

namespace Middleware
{
    public interface IShoppingCartProvider
    {
        ShoppingCartDetail GetDetail(in long shoppingCartId);

        long AddToCart(in UserSession userSession, in ShoppingCartSummary shoppingCart, 
            in Product product, in int count);

        bool ValidateVoucher(in ShoppingCartSummary cartSummary, in string voucher, in long userId);
    }
}
