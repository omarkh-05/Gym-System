using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PersonDLL
    {
        private static string connectionString = Settings.connectionstring;

        public static Person GetPersonByID(int PersonID)
        {
            Person person = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetPersonByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            person = new Person
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]),
                                Name = reader["Name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Gender = reader["Gendor"].ToString(),
                                NationalNo = reader["NationalityNumber"].ToString(),
                                PhoneNo = reader["PhoneNumber"].ToString(),
                                NationalityID = Convert.ToInt32(reader["NationalityID"]),
                                Address = reader["Address"].ToString(),
                                EnterID = reader["EnterID"].ToString(),
                                PersonType = reader["PersonType"].ToString(),
                                HasDisease = Convert.ToBoolean(reader["HasDiseases"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetPersonID Error: {ex.Message}", EventLogEntryType.Error);
            }
            return person;
        }
    }
}
