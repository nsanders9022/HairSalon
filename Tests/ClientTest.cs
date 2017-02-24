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

        public void Save_TestIfSaved_True()
        {
            //Arrange
            Client client1 = new Client("Marge", "trim", 1);
            client1.Save();

            List<Client> testClientList = new List<Client> {client1};
            List<Client> resultClientList = Client.GetAll();

            //Assert
            Assert.Equal(testClientList, resultClientList);
        }

        public void GetAll_ReturnAllClients_list()
        {
            Client client1 = new Client("Marge", "trim", 1);
            Client client2 = new Client("Hector", "go bald", 4);
            client1.Save();
            client2.Save();

            List<Client> testClientList = new List<Client> {client2, client1};
            List<Client> resultClientList = Client.GetAll();
            
            Assert.Equal(testClientList, resultClientList);
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
