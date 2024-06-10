using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

internal class DatabaseManager
{
    private readonly string connectionString;

    public DatabaseManager()
    {
        connectionString = "Data Source=DESKTOP-AJ76KB7\\SQLEXPRESS;Initial Catalog=DMS4;Persist Security Info=True;User ID=nurai;Password=123";
    }

    public DataTable ExecuteQuery(string sqlQuery)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                    {
                        dp.Fill(dt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return dt;
    }
}
