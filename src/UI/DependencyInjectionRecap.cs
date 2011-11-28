using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Core.Domain;


namespace NoDependencyInjection
{
 
    public class ProductsUI
    {
        protected GridView GridView { get; set; }

        public void DisplayProducts()
        {
            var productsBll = new ProductsBll();
            GridView.DataSource = productsBll.GetAllProducts();
        }
    }

    public class ProductsBll
    {
        public List<Product> GetAllProducts()
        {
            var dal = new ProductsDal();
            var sqlDataReader = dal.GetProductsDataReader();
            var productsList = new List<Product>();

            while (sqlDataReader.Read())
            {
                productsList.Add(new Product((int)sqlDataReader["ProductId"]));
            }

            return productsList;
        }
    }


    public class ProductsDal
    {
        public SqlDataReader GetProductsDataReader()
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM Products";
            return sqlCommand.ExecuteReader();
        }
    }
}

namespace WithDependencyInjection
{
    public class ProductsUI
    {
        protected GridView GridView { get; set; }

        public void DisplayProducts()
        {
            var productsBll = BllFactory.GetProductsBll();
            GridView.DataSource = productsBll.GetAllProducts();
        }
    }

    public static class BllFactory
    {
        public static ProductsBll GetProductsBll()
        {
            var productsDal = new ProductsDal();
            var productsBll = new ProductsBll(productsDal);
            return productsBll;
        }
    }

    public class ProductsBll
    {
        private readonly ProductsDal _productsDal;

        public ProductsBll(ProductsDal productsDal)
        {
            _productsDal = productsDal;
        }

        public List<Product> GetAllProducts()
        {
            var sqlDataReader = _productsDal.GetProductsDataReader();
            var productsList = new List<Product>();

            while (sqlDataReader.Read())
            {
                var product = new Product((int)sqlDataReader["ProductId"]);
                productsList.Add(product);
            }

            return productsList;
        }
    }


    public class ProductsDal
    {
        public SqlDataReader GetProductsDataReader()
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM Products";
            return sqlCommand.ExecuteReader();
        }
    }
}