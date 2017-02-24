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

        [Fact]
        public void StylistName_GetNameBasedOnId_string()
        {
            Stylist newStylist = new Stylist("Claire", 3);
            newStylist.Save();
            Client testClient  = new Client("Marge", "trim", newStylist.GetId());
            testClient.Save();

            string testString = "Claire";
            string resultString = testClient.StylistName();

            Assert.Equal(testString, resultString);
        }

        [Fact]
        public void Update_UpdateName_null()
        {
            Client testClient  = new Client("Rachel", "highlights", 2);
            testClient.Save();

            string newName = "Rach";

            testClient.Update(newName);

            string result = testClient.GetName();

            Assert.Equal(newName, result);
        }

        public void Delete_DeleteClientFromDatabase_null()
        {
            Client testClient1 = new Client("Marge", "trim", 1);
            Client testClient2 = new Client("Hector", "go bald", 4);
            Client testClient3 = new Client("Rachel", "highlights", 2);

            testClient1.Save();
            testClient2.Save();
            testClient3.Save();

            testClient2.Delete();

            List<Client> resultClient = Client.GetAll();
            List<Client> testClientList = new List<Client> {testClient1, testClient3};

            Assert.Equal(resultClient, testClientList);
        }

        [Fact]
        public void Find_FindClientById_true()
        {
           Client testClient = new Client("Hector", "go bald", 4);
           testClient.Save();

           Client foundClient = Client.Find(testClient.GetId());
           Assert.Equal(testClient, foundClient);
        }

        public void Dispose()
        {
            Client.DeleteAll();
        }
    }
}
