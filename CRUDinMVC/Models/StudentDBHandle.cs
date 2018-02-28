using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDinMVC.Models
{
    public class StudentDBHandle
    {
        private String _ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["StudentConn"]); 
        public bool CreateStudent(StudentModel smodel)
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_CRUD_Students", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operation", 'C');
                    cmd.Parameters.AddWithValue("@Student_Name", smodel.Name);
                    cmd.Parameters.AddWithValue("@Student_City", smodel.City);
                    cmd.Parameters.AddWithValue("@Student_Address", smodel.Address);

                    con.Open();
                    Int32 result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result >= 1)
                        return true;
                    else
                        return false; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<StudentModel> ReadStudent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("USP_CRUD_Students", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operation", "MR");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    adapter.Fill(dt);
                    con.Close();

                    List<StudentModel> myList = new List<StudentModel>();
                    foreach (DataRow _drow in dt.Rows)
                    {
                        myList.Add(
                            new StudentModel
                            {
                                Id = Convert.ToInt32(_drow["Student_TblRefID"]),
                                Name = Convert.ToString(_drow["Student_Name"]),
                                City = Convert.ToString(_drow["Student_City"]),
                                Address = Convert.ToString(_drow["Student_Address"])
                            }
                            );
                    }

                    return myList;
                }
            }
            catch (Exception ex)
            {
                return new List<StudentModel>();
            }
        }

        public bool UpdateStudent(StudentModel smodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_CRUD_Students", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operation", 'U');
                    cmd.Parameters.AddWithValue("@Student_TblRefID", smodel.Id);
                    cmd.Parameters.AddWithValue("@Student_Name", smodel.Name);
                    cmd.Parameters.AddWithValue("@Student_City", smodel.City);
                    cmd.Parameters.AddWithValue("@Student_Address", smodel.Address);

                    con.Open();
                    Int32 result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletStudent(StudentModel smodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_CRUD_Students", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operation", 'D');
                    cmd.Parameters.AddWithValue("@Student_TblRefID", smodel.Id);

                    con.Open();
                    Int32 result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<SelectListItem> PopulateCity()
        {
            try
            {
                String _ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["StudentConn"]);
                List<SelectListItem> items = new List<SelectListItem>();

                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_R_City", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    adapter.Fill(dt);
                    con.Close();

                    List<StudentModel> myList = new List<StudentModel>();
                    foreach (DataRow _drow in dt.Rows)
                    {
                        items.Add(
                            new SelectListItem
                            {
                                Text = Convert.ToString(_drow["City_Name"]),
                                Value = Convert.ToString(_drow["City_Id"])
                            }
                            );
                    }

                    return items;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}