using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Record
/// </summary>
public class DBRecord
{
    public DBRecord()
    {
    }

    public void GetRecord(string Date, string Time, string Branch_Name, out string Item_Name, out int Amount_Purchased, out string Out_Branch_Name)
    {
        int Record_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetRecord_ID", con)
        {
            CommandType= CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Date", Date);
        comms.Parameters.AddWithValue("@Time", Time);
        comms.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        SqlParameter para = new SqlParameter("@Record_ID", SqlDbType.BigInt)
        { 
        Direction = ParameterDirection.Output
        };
        comms.Parameters.Add(para);
        comms.ExecuteNonQuery();
        Record_ID = int.Parse(para.Value.ToString());
        comms.Dispose();



        SqlCommand cmd = new SqlCommand("@sp_GetRecord", con)
        { 
            CommandType = CommandType.StoredProcedure 
        };
        cmd.Parameters.AddWithValue("@Record_ID", Record_ID);
        SqlParameter AP = new SqlParameter("@Amount_Purchased", SqlDbType.BigInt)
        { Direction = ParameterDirection.Output };
        SqlParameter IN = new SqlParameter("@Item_Name", SqlDbType.NVarChar)
        { Direction = ParameterDirection.Output };
        SqlParameter BN = new SqlParameter("@Branch_Name", SqlDbType.NVarChar)
        { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(AP);
        cmd.Parameters.Add(BN);
        cmd.Parameters.Add(IN);
        cmd.ExecuteNonQuery();
        Item_Name = IN.Value.ToString();
        Amount_Purchased = int.Parse(AP.Value.ToString());
        Out_Branch_Name = BN.Value.ToString();
        cmd.Dispose();
        con.Close();
    
    }

    public string InsertRecord(int Amount_Purchased, string Branch_Name, string Date, string Time, string Item_Name)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_InsertRecord", con)
        { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Amount_Purchased", Amount_Purchased);
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        cmd.Parameters.AddWithValue("@Date", Date);
        cmd.Parameters.AddWithValue("@Time", Time);
        cmd.Parameters.AddWithValue("@Item_Name", Item_Name);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return "Record Updated!";
    }

    public string DeleteRecord(string Date, string Time, string Branch_Name)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_DeleteRecord", con)
        { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Date", Date);
        cmd.Parameters.AddWithValue("@Time", Time);
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return "Record Deleted!";












    }





}