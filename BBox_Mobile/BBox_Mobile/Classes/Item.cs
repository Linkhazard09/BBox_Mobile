using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Item
/// </summary>
public class DBItem
{
    public DBItem()
    {
    }

    public void GetItem(string Item_Name, out int Item_Stock, out string Branch_Name, out string Item_N) // The Item_N is for output purposes only
    {
        int Item_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetItem_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Item_Name", Item_Name);
        SqlParameter IID = new SqlParameter("@Item_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(IID);
        comms.ExecuteNonQuery();
        Item_ID = int.Parse(IID.Value.ToString());
        comms.Dispose();

        SqlCommand cmd = new SqlCommand("sp_GetItem", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
        SqlParameter IS = new SqlParameter("@Item_Stock", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.Add(IS);
        SqlParameter BN = new SqlParameter("@Branch_Name", System.Data.SqlDbType.NVarChar)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.Add(BN);
        SqlParameter IN = new SqlParameter("@Item_Name", System.Data.SqlDbType.NVarChar)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.Add(IN);
        cmd.ExecuteNonQuery();
        Item_Stock = int.Parse(IS.Value.ToString());
        Branch_Name = BN.Value.ToString();
        Item_N = IN.Value.ToString();
        cmd.Dispose();
        con.Close();

        return;
    }

    public string UpdateItem(string Item_Name, int Item_Stock, string Branch_Name, string NewName)
    {
        int Item_ID;
        int Branch_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetItem_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Item_Name", Item_Name);
        SqlParameter IID = new SqlParameter("@Item_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(IID);
        comms.ExecuteNonQuery();
        Item_ID = int.Parse(IID.Value.ToString());
        comms.Dispose();

        SqlCommand com = new SqlCommand("sp_GetBranch_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        com.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        SqlParameter BID = new SqlParameter("@Branch_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        com.Parameters.Add(BID);
        com.ExecuteNonQuery();
        Branch_ID = int.Parse(BID.Value.ToString());
        com.Dispose();

        SqlCommand cmd = new SqlCommand("sp_UpdateItem", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Item_Name", NewName);
        cmd.Parameters.AddWithValue("@Item_Stock", Item_Stock);
        cmd.Parameters.AddWithValue("@Branch_ID", Branch_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();


        return "Item Updated!";
    }


    public string InsertItem(string Item_Name, string Item_Stock, string Branch_Name)
    {
        int Branch_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand com = new SqlCommand("sp_GetBranch_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        com.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        SqlParameter BID = new SqlParameter("@Branch_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        com.Parameters.Add(BID);
        com.ExecuteNonQuery();
        Branch_ID = int.Parse(BID.Value.ToString());
        com.Dispose();

        SqlCommand cmd = new SqlCommand("@sp_InsertItem", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Item_Name", Item_Name);
        cmd.Parameters.AddWithValue("@Item_Stock", Item_Stock);
        cmd.Parameters.AddWithValue("@Branch_ID", Branch_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();

        return "Item Created";

    }

    public string DeleteItem(string Item_Name)
    {
        int Item_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetItem_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Item_Name", Item_Name);
        SqlParameter IID = new SqlParameter("@Item_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(IID);
        comms.ExecuteNonQuery();
        Item_ID = int.Parse(IID.Value.ToString());
        comms.Dispose();

        SqlCommand cmd = new SqlCommand("sp_DeleteItem", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();

        return "Item Deleted!";

    }







}