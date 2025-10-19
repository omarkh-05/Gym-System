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
    public class UserDLL
    {
        private static string connectionString = Settings.connectionstring;

        #region Add New User
        public static short AddNewUser(User user)
        {
            short newId = -1;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SPAddUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeID", user.EmployeeID);
                    cmd.Parameters.AddWithValue("@Username", user.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.Status);
                    cmd.Parameters.AddWithValue("@AddedBy", user.UserAddBy);

                    SqlParameter outputId = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (outputId.Value != DBNull.Value)
                        newId = Convert.ToInt16(outputId.Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"AddNewUser Error: {ex.Message}", EventLogEntryType.Error);
            }

            return newId;
        }
        #endregion

        #region Update User
        public static bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_UpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@Username", user.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.Status);
                    cmd.Parameters.AddWithValue("@AddedBy", user.UserAddBy);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"UpdateUser Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion

        #region Delete User
        public static bool DeleteUser(short userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"DeleteUser Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion

        #region Get User By ID
        public static User GetUserByID(short userID)
        {
            User user = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetUserByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                UserName = reader["UserName"].ToString(),
                                UserID = Convert.ToInt16(reader["UserID"]),
                                Role = reader["Role"].ToString(),
                                Status = Convert.ToBoolean(reader["IsActive"]),
                                AddedBy = Convert.ToByte(reader["AddedBy"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetUserByID Error: {ex.Message}", EventLogEntryType.Error);
            }

            return user;
        }
        #endregion

        public static bool FindUserByEmployeeID(int employeeID)
        {
            bool exists = false;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SP_FindUserByEmployeeID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    conn.Open();

                    object result = cmd.ExecuteScalar(); // يرجع أول قيمة موجودة

                    if (result != null)
                        exists = true;
                }
            }
            catch (Exception ex)
            {
                exists = false;
                EventLog.WriteEntry("Application", $"GetUserByEmployeeID Error (employeeID={employeeID}): {ex.Message}", EventLogEntryType.Error);
            }
            return exists;
        }

        public static User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("sp_GetUserByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", username.Trim());

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt16(reader["UserID"]) : (short)0,
                                UserName = reader["UserName"] as string,
                                PasswordHash = reader["Password"] as string,
                                IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToBoolean(reader["IsActive"]) : false,
                                EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : 0,
                                Role = reader["Role"] as string
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetUserByUsername Error (username={username}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }

            return null;
        }



        public static string GetPasswordHashByUserID(int userId)
        {
            string res = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetPasswordHashByUserID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    res= result?.ToString();
                }
            }catch (Exception ex) 
            {
                if(string.IsNullOrEmpty(res))
                EventLog.WriteEntry("Application", $"User Password Error: {ex.Message}", EventLogEntryType.Error);
            }
            return res;
        }

        #region Get All Users
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllUsers Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
        #endregion

        public static DataTable GetAllUsersView()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllUsersView", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllUsersView Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
    }
}
