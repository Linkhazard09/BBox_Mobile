using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Receipt
/// </summary>
public class DBReceipt
{
    public DBReceipt()
    {
    }

    public void GetReceipt(string Date, string Time, out int Item_Amount, out int Transaction_Total, out string Username, out int Change)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_GetReceipt", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Date", Date);
        cmd.Parameters.AddWithValue("@Time", Time);
        SqlParameter IA = new SqlParameter("@Item_Amount", System.Data.SqlDbType.BigInt)
        { Direction = System.Data.ParameterDirection.Output };
        SqlParameter TT = new SqlParameter("@Transaction_Total", System.Data.SqlDbType.BigInt)
        { Direction = System.Data.ParameterDirection.Output };
        SqlParameter UN = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar)
        { Direction = System.Data.ParameterDirection.Output };
        SqlParameter Ch = new SqlParameter("@Change", System.Data.SqlDbType.BigInt)
        { Direction = System.Data.ParameterDirection.Output };
        cmd.Parameters.Add(IA);
        cmd.Parameters.Add(TT);
        cmd.Parameters.Add(UN);
        cmd.Parameters.Add(Ch);
        cmd.ExecuteNonQuery();
        Item_Amount = int.Parse(IA.Value.ToString());
        Transaction_Total = int.Parse(TT.Value.ToString());
        Username = UN.Value.ToString();
        Change = int.Parse(Ch.Value.ToString());
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return;
    }

    public string InsertReceipt(string Date, string Time, int Item_Amount, int Transaction_Total, string Username, int Change)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_InsertReceipt", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Date", Date);
        cmd.Parameters.AddWithValue("@Time", Time);
        cmd.Parameters.AddWithValue("@Item_Amount", Item_Amount);
        cmd.Parameters.AddWithValue("@Transaction_Total", Transaction_Total);
        cmd.Parameters.AddWithValue("@Username", Username);
        cmd.Parameters.AddWithValue("@Change", Change);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return "Receipt Recorded!";
    }

   public string DeleteReceipt(string Date, string Time)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_DeleteReceipt", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Date", Date);
        cmd.Parameters.AddWithValue("@Time", Time);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return "Receipt Deleted!";
    }




}