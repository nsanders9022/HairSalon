using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Stylist
    {
        private int _id;
        private string _name;
        private int _experience;

        public Stylist(string Name, int Experience, int Id = 0)
        {
            _id = Id;
            _name = Name;
            _experience = Experience;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId() == newStylist.GetId();
                bool nameEquality = this.GetName() == newStylist.GetName();
                bool experienceEquality = this.GetExperience() == newStylist.GetExperience();
                return (idEquality && nameEquality && experienceEquality);
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

       public int GetExperience()
       {
           return _experience;
       }

       public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, experience) OUTPUT INSERTED.id VALUES (@Name, @Experience);", conn);

            SqlParameter nameParameter = new SqlParameter("@Name", this.GetName());

            cmd.Parameters.Add(nameParameter);

            SqlParameter experienceParameter = new SqlParameter("@Experience", this.GetExperience());

            cmd.Parameters.Add(experienceParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> AllStylists = new List<Stylist>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                int stylistExperience = rdr.GetInt32(2);

                Stylist newStylist = new Stylist(stylistName, stylistExperience, stylistId);
                AllStylists.Add(newStylist);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return AllStylists;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId", conn);
            SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetId());
            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                string clientHairStyle = rdr.GetString(2);
                int clientStylistId = rdr.GetInt32(4);
                Client newClient = new Client(clientName, clientHairStyle, clientStylistId, clientId);
                clients.Add(newClient);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return clients;
        }


       public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
