using System;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Xunit;

namespace Testing.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Serialize()
        {

            IDbConnection conn = new MySqlConnection("Server=localhost;Database=bestbuy;uid=root;Pwd=password;Port=3306;");
            var repo = new ProductRepository(conn);
            var products = repo.GetAllProducts();


            //JsonResult categoryJson = new JsonResult(products);
            using (StreamWriter file = System.IO.File.CreateText("productsFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, products);
            }
        }
    }
}
