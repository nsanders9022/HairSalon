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
