using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(subscription.DepartmentName) ? DBNull.Value : (object)subscription.DepartmentName;
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
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(subscription.DepartmentName) ? DBNull.Value : (object)subscription.DepartmentName;
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

        #region Get Subscription By ID
        public static SubscriptionInfo GetSubscriptionByID(byte subTimeID)
        {
            SubscriptionInfo subscription = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_SubscriptionsGetById", con))
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
                                DepartmentName = reader["DepartmentName"].ToString(),
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
        #endregion
    }
}
