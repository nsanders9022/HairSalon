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


        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, hair_style, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientHairStyle, @ClientStylistId);", conn);

            SqlParameter nameParameter = new SqlParameter("@ClientName", this.GetName());

            SqlParameter hairStyleParameter = new SqlParameter("@ClientHairStyle", this.GetHairStyle());

            SqlParameter stylistIdParameter = new SqlParameter("@ClientStylistId", this.GetStylistId());

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(hairStyleParameter);
            cmd.Parameters.Add(stylistIdParameter);

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

        public static List<Client> GetAll()
        {
           List<Client> AllClients = new List<Client>{};

           SqlConnection conn = DB.Connection();
           conn.Open();

           SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
           SqlDataReader rdr = cmd.ExecuteReader();

           while(rdr.Read())
           {
               int clientId = rdr.GetInt32(0);
               string clientName = rdr.GetString(1);
               string clientHairStyle = rdr.GetString(2);
               int clientStylistId = rdr.GetInt32(3);
               Client newClient = new Client(clientName, clientHairStyle, clientStylistId, clientId);
               AllClients.Add(newClient);
           }
           if (rdr != null)
           {
               rdr.Close();
           }
           if (conn != null)
           {
               conn.Close();
           }
           return AllClients;
        }

        public string StylistName()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT name FROM stylists WHERE id = @StylistId;", conn);
            SqlParameter stylistIdParameter = new SqlParameter("@StylistId", this.GetStylistId().ToString());
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            string stylistName = "";

            while(rdr.Read())
            {
                stylistName = rdr[0].ToString();
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return stylistName;
        }

        public void Update(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName OUTPUT INSERTED.name WHERE id = @ClientId;", conn);

            SqlParameter newClientNameParameter = new SqlParameter("@NewName", newName);
            cmd.Parameters.Add(newClientNameParameter);

            SqlParameter clientIdParameter = new SqlParameter("@ClientId", this.GetId());
            cmd.Parameters.Add(clientIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._name = rdr.GetString(0);
            }

            if (rdr !=null)
            {
                rdr.Close();
            }

            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);

            SqlParameter clientIdParameter = new SqlParameter("@ClientId", this.GetId());

            cmd.Parameters.Add(clientIdParameter);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Client Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
            SqlParameter clientIdParameter = new SqlParameter("@ClientId", id.ToString());
            cmd.Parameters.Add(clientIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundClientId = 0;
            string foundClientName = null;
            string foundClientHairStyle = null;
            int foundClientStylistId = 0;

            while(rdr.Read())
            {
                foundClientId = rdr.GetInt32(0);
                foundClientName = rdr.GetString(1);
                foundClientHairStyle = rdr.GetString(2);
                foundClientStylistId = rdr.GetInt32(3);
            }

            Client foundClient = new Client(foundClientName, foundClientHairStyle, foundClientStylistId, foundClientId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundClient;
        }


        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
