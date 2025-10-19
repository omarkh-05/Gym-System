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
    public class CheckinPresenceDLL
    {
        static string _connectionString = Settings.connectionstring;


        //                                Gym   
        public static string RegisterCheckin(string enterId)
        {
            string RegisterMessage = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_RegisterCheckin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnterID", enterId);

                    con.Open();
                    string result = cmd.ExecuteScalar()?.ToString();

                    if (result == "ActiveInserted")
                        RegisterMessage = "تم تسجيل الدخول , مرحبا بك في FIT GYM";

                    else if (result == "NotActive")
                        RegisterMessage =  "هذا الشخص غير فعال";

                    else if(result == "NotAllowedTime")
                        RegisterMessage = "غير مسموح بالدخول في هذا الوقت";

                    else
                        RegisterMessage = "هذا الشخص غير موجود";
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Registring Person Error : {ex.Message}", EventLogEntryType.Error);
            }
          return RegisterMessage;
        }

        public static string RegisterCheckout(string enterId)
        {
            string RegisterMessage = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_RegisterCheckout", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnterID", enterId);

                    con.Open();
                    string result = cmd.ExecuteScalar()?.ToString();

                    if (result == "CheckoutInserted")
                        RegisterMessage = "تم تسجيل الخروج , نراك لاحقا";

                    else if (result == "NotActive")
                        RegisterMessage = "هذا الشخص غير فعال";

                    else if (result == "CheckoutNotAllowedTime")
                        RegisterMessage = "غير مسموح بالخروج في هذا الوقت";

                    else
                        RegisterMessage = "هذا الشخص غير موجود";
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Checkout Error : {ex.Message}", EventLogEntryType.Error);
            }
            return RegisterMessage;
        }

        public static DataTable GetAllCheckinRegister()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllCheckinPresence", con))
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
                EventLog.WriteEntry("Application", $"GetAllCheckinPresence Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }

        public static DataTable GetAllCheckoutRegister()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllCheckoutPresence", con))
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
                EventLog.WriteEntry("Application", $"GetAllCheckoutPresence Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }



        //                              Employee   
        public static string RegisterEmployeeCheckin(string enterId)
        {
            string RegisterMessage = "";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_RegisterEmployeeCheckin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnterID", enterId);

                    con.Open();
                    string result = cmd.ExecuteScalar()?.ToString();

                    if (result == "CheckinInserted")
                        RegisterMessage = "تم تسجيل الدخول بنجاح";
                    else if (result == "CheckinNotAllowedTime")
                        RegisterMessage = "غير مسموح بالدخول في هذا الوقت";
                    else if (result == "NotActive")
                        RegisterMessage = "هذا الموظف غير مفعل";
                    else if (result == "NotEmployee")
                        RegisterMessage = "هذا الرقم ليس لموظف";
                    else
                        RegisterMessage = "الموظف غير موجود";
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"RegisterEmployeeCheckin Error : {ex.Message}", EventLogEntryType.Error);
            }
            return RegisterMessage;
        }

        public static string RegisterEmployeeCheckout(string enterId, out decimal addition)
        {
            string RegisterMessage = "";
            addition = 0m;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_RegisterEmployeeCheckout", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnterID", enterId);

                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            string result = rdr["Result"]?.ToString();
                            if (rdr["Addition"] != DBNull.Value)
                                addition = Convert.ToDecimal(rdr["Addition"]);

                            if (result == "CheckoutInserted")
                                RegisterMessage = $"تم تسجيل الخروج. الإضافي: {addition:F2}";
                            else if (result == "NotActive")
                                RegisterMessage = "هذا الموظف غير مفعل";
                            else if (result == "NotEmployee")
                                RegisterMessage = "هذا الرقم ليس لموظف";
                            else if (result == "PersonNotFound")
                                RegisterMessage = "الموظف غير موجود";
                            else
                                RegisterMessage = "حدث خطأ غير متوقع";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"RegisterEmployeeCheckout Error : {ex.Message}", EventLogEntryType.Error);
            }
            return RegisterMessage;
        }

        public static DataTable GetAllEmployeeCheckinRegister()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllEmployeeCheckinPresence", con))
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
                EventLog.WriteEntry("Application", $"GetAllEmployeeCheckinPresence Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }

        public static DataTable GetAllEmployeeCheckoutRegister()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllEmployeeCheckoutPresence", con))
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
                EventLog.WriteEntry("Application", $"GetAllEmployeeCheckoutPresence Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
    }
}
