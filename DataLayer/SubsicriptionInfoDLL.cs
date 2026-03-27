using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Entities;

namespace DataLayer
{
    public class SubsicriptionInfoDLL
    {
        static string  connectionString = Settings.connectionstring;
        public static DataTable GetAllSubsicriptionInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllSubsicriptionInfo", con))
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
                EventLog.WriteEntry("Application", $"GetAllSubsicriptionInfos Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }

        public static async Task<List<SubscriptionsPackages>> GetAllGymSubPackages()
        {
            List<SubscriptionsPackages> packages = new List<SubscriptionsPackages>();

            try
            {
                string connect = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllGymSubInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            SubscriptionsPackages package = new SubscriptionsPackages
                            {
                                SubTimeID = reader.GetByte(reader.GetOrdinal("SubTimeID")),
                                PackageName = reader.GetString(reader.GetOrdinal("PackageName")),
                                Fees = reader.GetDecimal(reader.GetOrdinal("Fees")),
                                SubscriptionDuration = reader.GetByte(reader.GetOrdinal("SubscriptionDuration"))
                            };

                            packages.Add(package);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllSubsicriptionInfos Error: {ex.Message}", EventLogEntryType.Error);
                return null;
            }

            return packages;
        }

        #region Add New Subscription
        public static bool AddSubscription(SubscriptionInfo subscription)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_AddSubscriptions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubTimeID", subscription.SubTimeID);
                    cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = subscription.StartTime.HasValue ? (object)subscription.StartTime.Value : DBNull.Value;
                    cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = subscription.EndTime.HasValue ? (object)subscription.EndTime.Value : DBNull.Value;
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(subscription.PackageName) ? DBNull.Value : (object)subscription.PackageName;
                    cmd.Parameters.AddWithValue("@Fees", subscription.Fees);
                    cmd.Parameters.AddWithValue("@MinAge", subscription.MinAge);
                    cmd.Parameters.AddWithValue("@SubscriptionDuration", subscription.SubscriptionDuration);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"AddSubscription Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion

        #region Update Subscription
        public static bool UpdateSubscription(SubscriptionInfo subscription)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_UpdateSubscriptions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubTimeID", subscription.SubTimeID);
                    cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = subscription.StartTime.HasValue ? (object)subscription.StartTime.Value : DBNull.Value;
                    cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = subscription.EndTime.HasValue ? (object)subscription.EndTime.Value : DBNull.Value;
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(subscription.PackageName) ? DBNull.Value : (object)subscription.PackageName;
                    cmd.Parameters.AddWithValue("@Fees", subscription.Fees);
                    cmd.Parameters.AddWithValue("@MinAge", subscription.MinAge);
                    cmd.Parameters.AddWithValue("@SubscriptionDuration", subscription.SubscriptionDuration);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"UpdateSubscription Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion

        #region Delete Subscription
        public static bool DeleteSubscription(byte subTimeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_DeleteSubscriptions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubTimeID", subTimeID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"DeleteSubscription Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }
        #endregion

        #region Get Subscription By 
        public static SubscriptionInfo GetSubscriptionByID(byte subTimeID)
        {
            SubscriptionInfo subscription = null;

            try
            {
                string connect = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";
                using (SqlConnection con = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("SP_GetSubscriptionsByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubTimeID", subTimeID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subscription = new SubscriptionInfo
                            {
                                SubTimeID = Convert.ToByte(reader["SubTimeID"]),
                                StartTime = reader["StartTime"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)reader["StartTime"],
                                EndTime = reader["EndTime"] == DBNull.Value ? (TimeSpan?)null : (TimeSpan)reader["EndTime"],
                                PackageName = reader["PackageName"].ToString(),
                                Fees = Convert.ToDecimal(reader["Fees"]),
                                MinAge = Convert.ToByte(reader["MinAge"]),
                                SubscriptionDuration = Convert.ToByte(reader["SubscriptionDuration"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetSubscriptionByID Error: {ex.Message}", EventLogEntryType.Error);
            }

            return subscription;
        }

        public static async Task<double> GetPackFeesByPackageName(string packageName)
        {
            double packFees = 0;
            try
            {
                string connect = "Server=.;Database=Gym_System;User Id=sa;Password=123456;TrustServerCertificate=True";

                using (SqlConnection con = new SqlConnection(connect))
                using (SqlCommand cmd = new SqlCommand("SP_GetSubscriptionsByPackageName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@packageName", packageName);

                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            packFees = Convert.ToDouble(reader["Fees"]); // ✅ هون التصحيح
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetPackFeesByPackageName Error: {ex.Message}", EventLogEntryType.Error);
            }

            return packFees;
         }

        #endregion
    }
}
