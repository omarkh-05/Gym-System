using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxexDataLayer
{
    public class CountryDLL
    {
        static string _connectionString = Settings.connectionstring;

        public static DataTable GetAllNationality()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllNationality", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    EventLog.WriteEntry("Application", "GetAllNationality executed successfully.", EventLogEntryType.Information);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllNationality Error: {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }

        // 2. Get nationality by ID (ترجع true إذا لقت الاسم)

        //=================================================================================================
        //   Stored Procedures في C# هو out السبب الرئيسي لاستخدام 
        //  الـ SP أحيانًا ترجع قيم مفردة عبر OUTPUT parameters(مثلاً @DepartmentID OUTPUT).
        //في C#، نحتاج متغير نمرره للدالة ليستلم هذه القيمة بعد تنفيذ الـ SP.
        //out مناسب لأنه لا يحتاج أن يكون مهيأ مسبقًا، والدالة ستملأه بالقيمة اللي رجعتها قاعدة البيانات.
        //=================================================================================================

        public static bool GetNationalityByID(int id, out string nationalityName)
        {
            nationalityName = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetNationalityByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NationalityID", id);

                    SqlParameter outputParam = new SqlParameter("@NationalityName", SqlDbType.NVarChar, 200)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                    {
                        nationalityName = outputParam.Value.ToString();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetNationalityByID: {ex.Message}", ex);
            }
        }

        // 3. Get nationality by Name (ترجع true إذا لقت الـ ID)
        public static bool GetNationalityByName(string name, out int id)
        {
            id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetNationalityByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NationalityName", name);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["NationalityID"]);
                            EventLog.WriteEntry("Application", $"GetNationalityByName succeeded. Name={name}, ID={id}", EventLogEntryType.Information);
                            return true;
                        }
                    }

                    EventLog.WriteEntry("Application", $"GetNationalityByName found no record. Name={name}", EventLogEntryType.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetNationalityByName Error (Name={name}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }
    }

    //=================================================================================================
    // هون استخدمنا الداتا ريدر بدل الداتا ادابتر 
    // إذا تبغى بيانات للعرض في GridView/ComboBox أو تعديل البيانات قبل حفظها → DataAdapter + DataTable أفضل.
    // تبغى سرعة وأداء أعلى وقراءة كبيرة للبيانات فقط → DataReader إذا أفضل.
    // big data (DataReader)  /  Small data DGV Combobox... (DataAdapter)
    //=================================================================================================

    public class DepartmentDLL
    {
        static private string _connectionString = Settings.connectionstring;

        // 1. Get all departments
        static public bool GetAllDepartment(out DataTable result)
        {
            result = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetALLDapartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);

                    EventLog.WriteEntry("Application", $"GetAllDepartment executed. Rows={result.Rows.Count}", EventLogEntryType.Information);
                    return result.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllDepartment Error: {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }

        // 2. Get department name by ID
        static public bool GetDepartmentByID(int id, out string departmentName)
        {
            departmentName = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetDapartmentID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentID", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            departmentName = reader["DepartmentName"].ToString();
                            EventLog.WriteEntry("Application", $"GetDepartmentByID succeeded. ID={id}, Name={departmentName}", EventLogEntryType.Information);
                            return true;
                        }
                    }
                }

                EventLog.WriteEntry("Application", $"GetDepartmentByID not found. ID={id}", EventLogEntryType.Warning);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetDepartmentByID Error (ID={id}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }

        // 3. Get department ID by Name
        static public bool GetDepartmentByName(string name, out int id)
        {
            id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetDapartmentName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentName", name);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["DepartmentID"]);
                            EventLog.WriteEntry("Application", $"GetDepartmentByName succeeded. Name={name}, ID={id}", EventLogEntryType.Information);
                            return true;
                        }
                    }
                }

                EventLog.WriteEntry("Application", $"GetDepartmentByName not found. Name={name}", EventLogEntryType.Warning);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetDepartmentByName Error (Name={name}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }
    }


    public class SubInfoDLL
    {
        static private string _connectionString = Settings.connectionstring;

        // Get all subscriptions
        static public bool GetAllSubscriptions(out DataTable dt)
        {
            dt = new DataTable();
            dt.Columns.Add("SubTimeID", typeof(byte));
            dt.Columns.Add("SubTimeChosen", typeof(string));
            dt.Columns.Add("StartTime", typeof(TimeSpan));
            dt.Columns.Add("EndTime", typeof(TimeSpan));
            dt.Columns.Add("DepartmentName", typeof(string));
            dt.Columns.Add("Fees", typeof(decimal));
            dt.Columns.Add("MinAge", typeof(byte));
            dt.Columns.Add("SubscriptionDuration", typeof(byte));

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllSubsicriptionInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            EventLog.WriteEntry("Application", "GetAllSubscriptions returned no rows.", EventLogEntryType.Warning);
                            return false;
                        }

                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["SubTimeID"],
                                reader["SubTimeChosen"].ToString(),
                                reader["StartTime"] != DBNull.Value ? reader["StartTime"] : null,
                                reader["EndTime"] != DBNull.Value ? reader["EndTime"] : null,
                                reader["DepartmentName"].ToString(),
                                Convert.ToDecimal(reader["Fees"]),
                                Convert.ToByte(reader["MinAge"]),
                                Convert.ToByte(reader["SubscriptionDuration"])
                            );
                        }
                    }
                }

                EventLog.WriteEntry("Application", $"GetAllSubscriptions executed. Rows={dt.Rows.Count}", EventLogEntryType.Information);
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetAllSubscriptions Error: {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }

        // Get subscription by SubTimeID
        static public bool GetSubscriptionBySubTimeID(short subTimeID, out DataRow result)
        {
            result = null;
            try
            {
                if (!GetAllSubscriptions(out DataTable dt)) return false;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["SubTimeID"] != DBNull.Value && Convert.ToInt16(row["SubTimeID"]) == subTimeID)
                    {
                        result = row;
                        EventLog.WriteEntry("Application", $"GetSubscriptionBySubTimeID succeeded. SubTimeID={subTimeID}", EventLogEntryType.Information);
                        return true;
                    }
                }

                EventLog.WriteEntry("Application", $"GetSubscriptionBySubTimeID not found. SubTimeID={subTimeID}", EventLogEntryType.Warning);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetSubscriptionBySubTimeID Error (SubTimeID={subTimeID}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }

        // Get subscription by DepartmentName
        static public bool GetSubscriptionByDepartmentName(string departmentName, out DataRow result)
        {
            result = null;
            try
            {
                if (!GetAllSubscriptions(out DataTable dt)) return false;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["DepartmentName"].ToString().Equals(departmentName, StringComparison.OrdinalIgnoreCase))
                    {
                        result = row;
                        EventLog.WriteEntry("Application", $"GetSubscriptionByDepartmentName succeeded. DepartmentName={departmentName}", EventLogEntryType.Information);
                        return true;
                    }
                }

                EventLog.WriteEntry("Application", $"GetSubscriptionByDepartmentName not found. DepartmentName={departmentName}", EventLogEntryType.Warning);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetSubscriptionByDepartmentName Error (DepartmentName={departmentName}): {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }
    }
}

