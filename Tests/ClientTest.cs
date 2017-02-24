using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        public void Equals_TestIfEqual_true()
        {
           {
               //Arrange, Act
               Client client1 = new Client("Marge", "trim", 1);
               Client client2 = new Client("Marge", "trim", 1);

               //Assert
               Assert.Equal(client1, client2);
           }
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
