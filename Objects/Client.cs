using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Client
    {
        private int _id;
        private string _name;
        private string _hairStyle;
        private int _stylistId;

        public Client(string Name, string HairStyle, int StylistId, int Id = 0)
        {
            _name = Name;
            _hairStyle = HairStyle;
            _stylistId = StylistId;
            _id = Id;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = (this.GetId() == newClient.GetId());
                bool nameEquality = (this.GetName() == newClient.GetName());
                bool hairStyleEquality = (this.GetHairStyle() == newClient.GetHairStyle());
                bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());

                return (idEquality && nameEquality && hairStyleEquality && stylistIdEquality);
            }
        }

        public override int GetHashCode()
        {
           return this.GetName().GetHashCode();
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetHairStyle()
        {
            return _hairStyle;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM client;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
