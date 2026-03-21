using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sql;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class PersonDLL
    {

        //  private static string connectionString = Settings.connectionstring;
        private static string connectionString = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
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

        public static async Task<Person> GetAuthUserByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string is NULL");

            Person user = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAuthUserByPhoneNumber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 25).Value = phoneNumber;

                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new Person
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]),
                                PasswordHash = reader["PasswordHash"]?.ToString(),
                                RefreshTokenHash = reader["RefreshTokenHash"]?.ToString(),
                                RefreshTokenExpiresAt = reader["RefreshTokenExpiresAt"] as DateTime?,
                                RefreshTokenRevokedAt = reader["RefreshTokenRevokedAt"] as DateTime?,
                                PersonType = reader["PersonType"]?.ToString(),
                                PhoneNo = reader["PhoneNumber"]?.ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAuthUserByPhoneNumber Error: {ex.Message}", EventLogEntryType.Error);
            }

            return user;
        }

        public static async Task<bool> UpdateAuth(Person person)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_UpdatePersonAuth", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@personId", SqlDbType.Int).Value = person.PersonID;
                    cmd.Parameters.Add("@RefreshTokenHash", SqlDbType.NVarChar, 500).Value = (object)person.RefreshTokenHash ?? DBNull.Value;
                    cmd.Parameters.Add("@RefreshTokenExpiresAt", SqlDbType.DateTime2).Value = (object)person.RefreshTokenExpiresAt ?? DBNull.Value;
                    cmd.Parameters.Add("@RefreshTokenRevokedAt", SqlDbType.DateTime2).Value = (object)person.RefreshTokenRevokedAt ?? DBNull.Value;

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"UpdateAuth Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }

        public static async Task<int> RegisterPerson(Person person)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_RegisterPerson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 70).Value = person.Name;
                    cmd.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = (object)person.DateOfBirth ?? DBNull.Value;
                    cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 10).Value = person.Gender;
                    cmd.Parameters.Add("@nationalNo", SqlDbType.NVarChar, 25).Value = person.NationalNo;
                    cmd.Parameters.Add("@phoneNo", SqlDbType.NVarChar, 20).Value = person.PhoneNo;
                    cmd.Parameters.Add("@nationalityID", SqlDbType.Int).Value = person.NationalityID;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar, 200).Value = person.Address;
                    cmd.Parameters.Add("@hasDisease", SqlDbType.Bit).Value = person.HasDisease;
                    cmd.Parameters.Add("@personType", SqlDbType.NVarChar).Value = person.PersonType;
                    cmd.Parameters.Add("@passwordHash", SqlDbType.NVarChar, 500).Value = person.PasswordHash;

                    await con.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();

                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"RegisterPerson Error: {ex.Message}", EventLogEntryType.Error);
                return -1;
            }
        }
    }
}
