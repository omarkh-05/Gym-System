using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SubscribersDLL
    {
        private static string connectionString = Settings.connectionstring;


        #region Add New Subscriber
        public static int AddNewSubscriber(Subscriber subscriber)
        {
            int newId = -1;

            try
            {
                string connect = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("SPAddSubscriber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // معاملات مطابقة للـ SP
                    cmd.Parameters.AddWithValue("@DateOfBirth", subscriber.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Name", subscriber.Name);
                    cmd.Parameters.AddWithValue("@Gender", subscriber.Gender);
                    cmd.Parameters.AddWithValue("@NationalNo", subscriber.NationalNo);
                    cmd.Parameters.AddWithValue("@PhoneNo", subscriber.PhoneNo);
                    cmd.Parameters.AddWithValue("@NationalityID", Convert.ToInt32(subscriber.NationalityID));
                    cmd.Parameters.AddWithValue("@Address", subscriber.Address);
                    cmd.Parameters.AddWithValue("@EnterID", subscriber.EnterID);
                    cmd.Parameters.AddWithValue("@PersonType", subscriber.PersonType);
                    cmd.Parameters.AddWithValue("@HasDisease",Convert.ToBoolean(subscriber.HasDisease));
                    cmd.Parameters.AddWithValue("@SubDate", subscriber.SubDate);
                    cmd.Parameters.AddWithValue("@EndDate", subscriber.EndDate);
                    cmd.Parameters.AddWithValue("@IsPaid", subscriber.IsPaid);
                    cmd.Parameters.AddWithValue("@DepartmentID", subscriber.DepartmentID);
                    cmd.Parameters.AddWithValue("@SubscriptionInfo", subscriber.SubscriptionInfo);
                    cmd.Parameters.AddWithValue("@AddedBy", subscriber.AddedBy);

                    // المعامل Output
                    SqlParameter outputId = new SqlParameter("@SubscriberID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (outputId.Value != DBNull.Value)
                        newId = Convert.ToInt32(outputId.Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"AddNewSubscriber Error: {ex.Message}", EventLogEntryType.Error);
            }

            return newId;
        }
        public static async Task<int> AddNewSubscriberFE(AddSubscriberDTO subscriber)
        {
            int newId = -1;

            try
            {
                string connect = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("SP_AddSubscriberFE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonId", subscriber.PersonId);
                    cmd.Parameters.AddWithValue("@SubDate", subscriber.SubDate);
                    cmd.Parameters.AddWithValue("@EndDate", subscriber.EndDate);
                    cmd.Parameters.AddWithValue("@IsPaid", subscriber.IsPaid);
                    cmd.Parameters.AddWithValue("@DepartmentID", subscriber.DepartmentID);
                    cmd.Parameters.AddWithValue("@SubscriptionInfo", subscriber.SubscriptionInfo);
                    cmd.Parameters.AddWithValue("@AddedBy", 0);

                    // المعامل Output
                    SqlParameter outputId = new SqlParameter("@SubscriberID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                  await  con.OpenAsync();
                   await cmd.ExecuteNonQueryAsync();

                    if (outputId.Value != DBNull.Value)
                        newId = Convert.ToInt32(outputId.Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"SP_AddSubscriberFE Error: {ex.Message}", EventLogEntryType.Error);
            }

            return newId;
        }
        #endregion


        #region Update Subscriber
        public static bool UpdateSubscriber(Subscriber subscriber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSubscriber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubscriberID", subscriber.SubscriberID);
                    cmd.Parameters.AddWithValue("@PersonID", subscriber.PersonID); // <--- هذا مفقود
                    cmd.Parameters.AddWithValue("@DateOfBirth", subscriber.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Name", subscriber.Name);
                    cmd.Parameters.AddWithValue("@Gender", subscriber.Gender);
                    cmd.Parameters.AddWithValue("@NationalNo", subscriber.NationalNo);
                    cmd.Parameters.AddWithValue("@PhoneNo", subscriber.PhoneNo);
                    cmd.Parameters.AddWithValue("@NationalityID", subscriber.NationalityID);
                    cmd.Parameters.AddWithValue("@Address", subscriber.Address);
                    cmd.Parameters.AddWithValue("@EnterID", subscriber.EnterID);
                    cmd.Parameters.AddWithValue("@PersonType", subscriber.PersonType);
                    cmd.Parameters.AddWithValue("@HasDisease", subscriber.HasDisease);
                    cmd.Parameters.AddWithValue("@SubDate", subscriber.SubDate);
                    cmd.Parameters.AddWithValue("@EndDate", subscriber.EndDate);
                    cmd.Parameters.AddWithValue("@IsPaid", subscriber.IsPaid);
                    cmd.Parameters.AddWithValue("@DepartmentID", subscriber.DepartmentID);
                    cmd.Parameters.AddWithValue("@SubscriptionInfo", subscriber.SubscriptionInfo);
                    cmd.Parameters.AddWithValue("@AddedBy", subscriber.AddedBy);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"UpdateSubscriber Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion


        #region Delete Subscriber
        public static bool DeactiveSubscriber(int personID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeactiveSubscriber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", personID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"DeactiveSubscriber Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion


        #region Get Subscriber
        public static Subscriber GetSubscriberByID(int subscriberID)
        {
            Subscriber subscriber = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetSubscriberByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubscriberID", subscriberID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subscriber = new Subscriber
                            {
                                SubscriberID = Convert.ToInt32(reader["SubscriberID"]),
                                PersonID = Convert.ToInt32(reader["PersonID"]), // <--- أضف هذا
                                Name = reader["Name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Gender = reader["Gendor"].ToString(),
                                NationalNo = reader["NationalityNumber"].ToString(),
                                PhoneNo = reader["PhoneNumber"].ToString(),
                                NationalityID = Convert.ToInt32(reader["NationalityID"]),
                                Address = reader["Address"].ToString(),
                                EnterID = reader["EnterID"].ToString(),
                                PersonType = reader["PersonType"].ToString(),
                                HasDisease = Convert.ToBoolean(reader["HasDiseases"]),
                                SubDate = Convert.ToDateTime(reader["SubDate"]),
                                EndDate = Convert.ToDateTime(reader["EndSubDate"]),
                                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
                                SubscriptionInfo = Convert.ToInt16(reader["SubscriptionInfo"]),
                                AddedBy = Convert.ToInt16(reader["AddedBy"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetSubscriberByID Error: {ex.Message}", EventLogEntryType.Error);
            }

            return subscriber;
        }

        public static async Task<SubscriberDTO> GetSubscriberByPersonId(int personId)
        {
             string connectionString = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
        
            SubscriberDTO result = null;

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("GetSubscriberProfileFull", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", personId);

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // 1. Person + Subscriber info
                    if (await reader.ReadAsync())
                    {
                        result = new SubscriberDTO
                        {
                            PersonId = reader["PersonID"] != DBNull.Value ? (int)reader["PersonID"] : 0,
                            Name = reader["Name"]?.ToString(),
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] :default,
                            Gendor = reader["Gendor"]?.ToString(),
                            PhoneNumber = reader["PhoneNumber"]?.ToString(),
                            NationalityNumber = reader["NationalityNumber"]?.ToString(),
                            NationalityID = reader["NationalityID"] != DBNull.Value ? Convert.ToInt32(reader["NationalityID"]) : 0,
                            Address = reader["Address"]?.ToString(),
                            HasDisease = Convert.ToBoolean(reader["HasDiseases"]),

                            // Subscriber fields
                            SubscriberID = reader["SubscriberID"] != DBNull.Value ? (int)reader["SubscriberID"] : 0,
                            IsActive = reader["IsActive"] != DBNull.Value ? (bool)Convert.ToBoolean(reader["IsActive"]) : default,
                            SubDate = reader["SubDate"] != DBNull.Value ? (DateTime)reader["SubDate"] : default,
                            EndSubDate = reader["EndSubDate"] != DBNull.Value ? (DateTime)reader["EndSubDate"] : default,
                            SubTimeChosen = reader["SubTimeChosen"] != DBNull.Value ? reader["SubTimeChosen"].ToString() : null,
                            PackageName = reader["PackageName"] != DBNull.Value ? reader["PackageName"].ToString() : null,
                            SubscriptionDuration = reader["SubscriptionDuration"] != DBNull.Value ? (byte)Convert.ToByte(reader["SubscriptionDuration"]) : default,
                            DepartmentName = reader["DepartmentName"] != DBNull.Value ? reader["DepartmentName"].ToString() : null
                        };
                    }

                    if (result == null)
                        return null;

                    // 2. Attendance (only if subscriber exists)
                    if (result.IsActive)
                    {
                        await reader.NextResultAsync();
                        while (await reader.ReadAsync())
                        {
                            result.Attendance.Add(new AttendanceDTO
                            {
                                CheckinTime = reader["CheckinTime"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CheckinTime"],
                                CheckoutTime = reader["CheckoutTime"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["CheckoutTime"],
                                Status = reader["Status"].ToString()
                            });
                        }

                        // إذا ما في حضور → سجل واحد "No حضور"
                        if (result.Attendance.Count == 0)
                        {
                            result.Attendance.Add(new AttendanceDTO
                            {
                                CheckinTime = null,
                                CheckoutTime = null,
                                Status = "No حضور"
                            });
                        }
                    }
                }
            }

            return result;
        }
        #endregion


        #region Get All Subscribers
        public static DataTable GetAllSubscribers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllSubscribers", con))
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
                EventLog.WriteEntry("Application", $"GetAllSubscribers Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
        #endregion

        public static DataTable GetAllSubscribersView()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllSubscribersView", con))
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
                EventLog.WriteEntry("Application", $"GetAllSubscribersView Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
    }
}
