using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace sweet_shop
{
    internal class Login
    {
        public static bool IsValidUser(string user, string pass, out string role)
        {
            bool isValid = false;
            role = null;
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-AJ76KB7\\SQLEXPRESS;Initial Catalog=DMS4;Persist Security Info=True;User ID=nurai;Password=123"))
                {
                    con.Open();
                    string qry = "SELECT role FROM Users WHERE name=@user AND password=@pass";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        isValid = true;
                        role = reader["role"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке пользователя: " + ex.Message);
            }
            return isValid;
        }
    }
}
