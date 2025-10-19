using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Entities;


namespace DataLayer
{

        public class EmployeeDLL
        {
            private static string connectionString = Settings.connectionstring;

            #region Add New Employee
            public static int AddNewEmployee(Employee employee)
            {
                int newId = -1;

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("SPAddEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Person fields
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                        cmd.Parameters.AddWithValue("@NationalNo", employee.NationalNo);
                        cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                        cmd.Parameters.AddWithValue("@NationalityID", employee.NationalityID);
                        cmd.Parameters.AddWithValue("@Address", employee.Address);
                        cmd.Parameters.AddWithValue("@EnterID", employee.EnterID);
                        cmd.Parameters.AddWithValue("@PersonType", employee.PersonType);
                        cmd.Parameters.AddWithValue("@HasDisease", employee.HasDisease);

                        // Employee fields
                        cmd.Parameters.AddWithValue("@JoinningGymDate", employee.JoinningGymDate);
                        cmd.Parameters.AddWithValue("@Rank", employee.EmployeeRank);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@WorkTime", employee.WorkTime);
                        cmd.Parameters.AddWithValue("@EndDurationDate", employee.EndDurationDate);
                        cmd.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                        cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                        cmd.Parameters.AddWithValue("@AddedBy", employee.AddedBy);
                        cmd.Parameters.AddWithValue("@ImagePath", employee.ImagePath);

                    // output param
                    SqlParameter outputId = new SqlParameter("@EmployeeID", SqlDbType.Int)
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
                    EventLog.WriteEntry("Application", $"AddNewEmployee Error: {ex.Message}", EventLogEntryType.Error);
                }

                return newId;
            }
            #endregion

            #region Update Employee
            public static bool UpdateEmployee(Employee employee)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateEmployeeFullInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                        // Person fields
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                        cmd.Parameters.AddWithValue("@NationalNo", employee.NationalNo);
                        cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                        cmd.Parameters.AddWithValue("@NationalityID", employee.NationalityID);
                        cmd.Parameters.AddWithValue("@Address", employee.Address);
                        cmd.Parameters.AddWithValue("@EnterID", employee.EnterID);
                        cmd.Parameters.AddWithValue("@PersonType", employee.PersonType);
                        cmd.Parameters.AddWithValue("@HasDisease", employee.HasDisease);

                        // Employee fields
                        cmd.Parameters.AddWithValue("@Rank", employee.EmployeeRank);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@JoiningGymDate", employee.JoinningGymDate);
                        cmd.Parameters.AddWithValue("@EndDurationDate", employee.EndDurationDate);
                        cmd.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                        cmd.Parameters.AddWithValue("@AddedBy", employee.AddedBy);
                        cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                        cmd.Parameters.AddWithValue("@WorkTime", employee.WorkTime);
                        cmd.Parameters.AddWithValue("@ImagePath", employee.ImagePath);

                    con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Application", $"UpdateEmployee Error: {ex.Message}", EventLogEntryType.Error);
                    return false;
                }
            }
            #endregion

            #region Delete Employee
            public static bool DeleteEmployee(int employeeID)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Application", $"DeleteEmployee Error: {ex.Message}", EventLogEntryType.Error);
                    return false;
                }
            }
            #endregion

            #region Get Employee By ID
            public static Employee GetEmployeeByID(int employeeID)
            {
                Employee employee = null;

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("SP_GetEmployeeByID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                            employee = new Employee
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
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
                                EmployeeRank = Convert.ToByte(reader["Rank"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                JoinningGymDate = Convert.ToDateTime(reader["JoinningGymDate"]),
                                EndDurationDate = Convert.ToDateTime(reader["EndDurationDate"]),
                                EmployeeType = reader["EmployeeType"].ToString(),
                                AddedBy = Convert.ToByte(reader["AddedBy"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                WorkTime = reader["WorkTime"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString()
                            };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Application", $"GetEmployeeByID Error: {ex.Message}", EventLogEntryType.Error);
                }

                return employee;
            }
            #endregion

            #region Get All Employees
            public static DataTable GetAllEmployees()
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", con))
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
                    EventLog.WriteEntry("Application", $"GetAllEmployees Error: {ex.Message}", EventLogEntryType.Error);
                }
                return dt;
            }
        #endregion

          public static DataTable GetAllEmployeesView()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_GetAllEmployeesView", con))
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
                EventLog.WriteEntry("Application", $"GetAllEmployeesView Error: {ex.Message}", EventLogEntryType.Error);
            }
            return dt;
        }
    }
    }
