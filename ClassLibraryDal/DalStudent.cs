using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryModel;

namespace ClassLibraryDal
{
    public class DalStudent
    {
        public static void SaveStudentInformation(ModelStudent ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", ms.FirstName);
            cmd.Parameters.AddWithValue("@EmailAddress", ms.EmailAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteStudentInformation(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StuId", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateStudentInformation(ModelStudent ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StuId", ms.StuId);
            cmd.Parameters.AddWithValue("@FirstName", ms.FirstName);
            cmd.Parameters.AddWithValue("@EmailAddress", ms.EmailAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ModelStudent> GetStudentInformation()
        {
         SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelStudent> listStudent = new List<ModelStudent>();
            while (reader.Read())
            {
                ModelStudent student = new ModelStudent();
                student.StuId = Convert.ToInt32(reader["StuId"]);
                student.FirstName = reader["FirstName"].ToString();
                student.EmailAddress = reader["EmailAddress"].ToString();
                listStudent.Add(student);

            }
            con.Close();
            return listStudent;


            }


        }

    }

