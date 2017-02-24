using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class HairSalonTest : IDisposable
    {
        public HairSalonTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Equals_TestIfStylistEqual_true()
        {
            {
                //Arrange, Act
                Stylist stylist1 = new Stylist("Tom", 2);
                Stylist stylist2 = new Stylist("Tom", 2);

                //Assert
                Assert.Equal(stylist1, stylist2);
            }
        }

        [Fact]
        public void Save_TestIfSaved_saved()
        {
            //Arrange

            Stylist stylist1 = new Stylist("Sally", 5);
            stylist1.Save();

            List<Stylist> testStylistList = new List<Stylist> {stylist1};
            List<Stylist> resultStylistList = Stylist.GetAll();

            //Assert
            Assert.Equal(testStylistList, resultStylistList);
        }

        [Fact]
        public void GetAll_ReturnAllStylists_list()
        {
            Stylist stylist1 = new Stylist("Hector", 8);
            Stylist stylist2 = new Stylist("Nancy", 1);
            stylist1.Save();
            stylist2.Save();

            List<Stylist> testStylistList = new List<Stylist> {stylist1, stylist2};
            List<Stylist> resultStylistList = Stylist.GetAll();

            Assert.Equal(testStylistList, resultStylistList);
        }

        public void GetClients_RetrievesAllClientsFromStylist_list()
        {
            Stylist testStylist1 = new Stylist("Hector", 8);
            testStylist1.Save();

            Client client1 = new Client("Bertha", "pink dye", testStylist1.GetId());
            Client client2 = new Client("Dave", "dreadlocks", testStylist1.GetId());
            client1.Save();
            client2.Save();

            List<Client> testClientList = new List<Client> {client2, client1};
            List<Client> resultClientList = testStylist1.GetClients();

            Assert.Equal(testClientList, resultClientList);
        }

        [Fact]
       public void Update_UpdateStylistInData_null()
       {
           // Arrange
           string oldName = "Michael";
           Stylist testStylist = new Stylist(oldName, 4);
           testStylist.Save();
           string newName = "Mike";

           // Act
           testStylist.Update(newName);

           string result = testStylist.GetName();

           // Assert
           Assert.Equal(newName, result);
       }

       [Fact]
       public void Delete_DeleteStylistFromDatabase_null()
       {
           //Arrange
           Stylist testStylist1 = new Stylist("Amanda", 1);
           testStylist1.Save();

           Stylist testStylist2 = new Stylist("Jimmy", 4);
           testStylist2.Save();

           Client testClient1 = new Client("Rachel", "highlights", testStylist1.GetId());
           testClient1.Save();
           Client testClient2 = new Client("Kristen", "cut 8 inches off", testStylist2.GetId());
           testClient2.Save();

           //Act
           testStylist1.Delete();

           List<Stylist> resultStylist = Stylist.GetAll();
           List<Stylist> testStylistList = new List<Stylist> {testStylist2};

           List<Client> resultClient = Client.GetAll();
           List<Client> testClientList = new List<Client> {testClient2};

           //Assert
           Assert.Equal(testStylistList, resultStylist);
           Assert.Equal(testClientList, resultClient);

       }

       [Fact]
        public void Find_FindStylistById_stylist()
        {
            Stylist testStylist1 = new Stylist("Amanda", 1);
            testStylist1.Save();

           Stylist foundStylist = Stylist.Find(testStylist1.GetId());
           Assert.Equal(testStylist1, foundStylist);
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}
