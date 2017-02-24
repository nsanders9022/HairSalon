using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


////////////uncomment client.delete all

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

        public void Dispose()
        {
            Stylist.DeleteAll();
            // Client.DeleteAll();
        }
    }
}
