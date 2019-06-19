﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataModels;

namespace DataAccess
{
    public class DataAccessClass
    {
        String connectionString = "Server=localhost;Initial Catalog=assignment;Integrated Security=True";
        SqlConnection conn = null;
        public int SaveUserToDB(User user)
        {
            int added = -1;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand scmd = new SqlCommand("CreateNewUser", conn);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@firstname", user.FirstName);
                scmd.Parameters.AddWithValue("@lastname", user.LastName);
                scmd.Parameters.AddWithValue("@email", user.Email);
                scmd.Parameters.AddWithValue("@password", user.Password);
                added = scmd.ExecuteNonQuery();
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return added;
        }
        public int ActivaeUserToDB(User user)
        {
            int activated = -1;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand scmd = new SqlCommand("ActivateUser", conn);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@email", user.Email);
                activated = scmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return activated;
        }
        public User LoginFromDB(String email, String password)
        {
            User user = new User();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand scmd = new SqlCommand("SELECT * FROM health_users WHERE email = '" + email + "' AND password = '" + password + "'", conn);
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    user.status = 1;
                    user.UserId = Convert.ToInt32(dt.Rows[0]["userid"]);
                    user.FirstName = dt.Rows[0]["firstname"].ToString();
                    user.LastName = dt.Rows[0]["lastname"].ToString();
                    user.Email = dt.Rows[0]["email"].ToString();
                    user.Password = dt.Rows[0]["password"].ToString();
                    user.Address = dt.Rows[0]["address"].ToString();
                    user.Phone = dt.Rows[0]["phone"].ToString();
                    user.Profile = dt.Rows[0]["profile"].ToString();
                }
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return user;
        }
        public User UpdateUserToDB(User user)
        {
            user.status = -1;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand scmd = new SqlCommand("UpdateUserDetails", conn);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@userid", user.UserId);
                scmd.Parameters.AddWithValue("@firstname", user.FirstName);
                scmd.Parameters.AddWithValue("@lastname", user.LastName);
                scmd.Parameters.AddWithValue("@email", user.Email);
                scmd.Parameters.AddWithValue("@phone", user.Phone);
                scmd.Parameters.AddWithValue("@address", user.Address);
                scmd.Parameters.AddWithValue("@profile", user.Profile);
                user.status = scmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return user;
        }
        public User UpdatePasswordToDB(User user)
        {
            user.status = -1;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand scmd = new SqlCommand("ChangePassword", conn);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@userid", user.UserId);
                scmd.Parameters.AddWithValue("@password", user.Password);
                user.status = scmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return user;
        }
    }
}