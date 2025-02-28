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
 *  Product:  AspNetCore.PluginManager.Tests
 *  
 *  File: MockSession.cs
 *
 *  Purpose:  Mock IProductProvider class
 *
 *  Date        Name                Reason
 *  14/11/2021  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Middleware;
using Middleware.Products;

namespace AspNetCore.PluginManager.Tests.Shared
{
    [ExcludeFromCodeCoverage]
    public sealed class MockProductProvider : IProductProvider
    {
        #region IProductProvider Members

        #region Product Groups

        public ProductGroup ProductGroupGet(in int id)
        {
            if (ReturnNullForProductGroupGet)
                return null;

            int groupId = id;
            return ProductGroupsGet().FirstOrDefault(pg => pg.Id == groupId);
        }

        public List<ProductGroup> ProductGroupsGet()
        {
            if (ReturnNullForProductGroupGet)
                return new List<ProductGroup>();

            return new List<ProductGroup>()
            {
                new ProductGroup(1, "Main Products", true, 1, "Checkout our main products", String.Empty),
                new ProductGroup(2, "Other Products", true, 2, "Checkout our other products", String.Empty),
                new ProductGroup(3, "Remote", true, 3, "Remote Products", "http://hereorthere.com")
            };
        }

        public bool ProductGroupDelete(in int id, out string errorMessage)
        {
            errorMessage = ProductDeleteError;

            return String.IsNullOrEmpty(ProductDeleteError);
        }

        #endregion Product Groups

        #region Products

        public List<Product> GetProducts(in int page, in int pageSize)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            List<Product> products = new List<Product>()
            {
                new Product(1, 1, "Product A & - &", "This is product a", "1 year guarantee", "", new string[] { "ProdA_1" }, 0, "ProdA", false, false),
                new Product(2, 1, "Product B", "This is product b", "1 year guarantee", "", new string[] { "ProdB_1" }, 0, "ProdB", true, false),
                new Product(3, 1, "Product C", "This is product c", "1 year guarantee", "E7Voso411Vs", new string[] { "ProdC_1" }, 1.99m, "ProdC", true, true, false, true),
                new Product(4, 2, "Product D", "This is product d", "1 year guarantee", "", new string[] { "ProdD_1" }, 22.99m, "ProdD", false, true, true, true),
                new Product(5, 2, "Product E", "This is product e", "1 year guarantee", "pCvZtjoRq1I", new string[] { "ProdE_1" }, 0, "SKUE", false, false),


                new Product(6, 2, "Product F", "This is product f", "1 year guarantee", "pCvZtjoRq1I", new string[] { "ProdF_1" }, 0, "ProdF", false, false, true, true),
                new Product(7, 2, "Product G", "This is product g", "1 year guarantee", "", new string[] { "ProdG_1" }, 15.95m, "SKUG", false, false, true, false),
                new Product(8, 2, "Product H", "This is product description h", "1 year guarantee", "", new string[] { "ProdH_1" }, 1.99m, "SKUH", false, false, false, true),
                new Product(9, 2, "Product I", "This is product description i", "1 year guarantee", "", new string[] { "ProdI_1" }, 0, "ProdI", false, false, false, true)
            };

            products[0].SetCurrentStockLevel(5);

            List<Product> Result = new List<Product>();

            int start = (page * pageSize) - pageSize;
            int end = (start + pageSize);

            decimal pageCount = (decimal)products.Count / pageSize;

            int pages = (int)Math.Truncate(pageCount);

            if (pageCount - pages > 0)
                pages++;

            if (page > pages)
                return Result;

            if (end > products.Count)
                end = products.Count;

            for (int i = start; i < end; i++)
            {
                Result.Add(products[i]);
            }

            return Result;
        }

        public List<Product> GetProducts(in ProductGroup productGroup, in int page, in int pageSize)
        {
            ProductGroup prodGroup = productGroup;
            return GetProducts(page, pageSize).Where(p => p.ProductGroupId == prodGroup.Id).ToList();
        }

        public Product GetProduct(in int id)
        {
            int prodId = id;
            return GetProducts(1, 10000).FirstOrDefault(p => p.Id == prodId);
        }

        public bool ProductGroupSave(in int id, in string description, in bool showOnWebsite, in int sortOrder, in string tagLine, in string url, out string errorMessage)
        {
            errorMessage = ProductGroupSaveError;

            return String.IsNullOrEmpty(ProductGroupSaveError);
        }

        public bool ProductSave(in int id, in int productGroupId, in string name, in string description, in string features, in string videoLink, in bool newProduct, 
            in bool bestSeller, in decimal retailPrice, in string sku, in bool isDownload, in bool allowBackOrder, out string errorMessage)
        {
            errorMessage = ProductSaveError;

            return String.IsNullOrEmpty(ProductSaveError);
        }

        public bool ProductDelete(in int id, out string errorMessage)
        {
            errorMessage = ProductDeleteError;

            return String.IsNullOrEmpty(ProductDeleteError);
        }

        public int ProductCount => 9;

        #endregion Products

        #endregion IProductProvider Members

        public bool ReturnNullForProductGroupGet { get; set; }

        public string ProductSaveError { get; set; }

        public string ProductDeleteError { get; set; }

        public string ProductGroupSaveError { get; set; }
    }
}
