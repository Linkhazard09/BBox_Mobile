using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for Account
/// </summary>
public class DBAccount
{   public DBAccount()
    {
    }

    public void GetLogin(string Username, out string Username_Out,out string Password, out string Account_Type)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_GetAccountLogin", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Username", Username);
        SqlParameter User = new SqlParameter("@Username_Out", SqlDbType.NVarChar, 20)
        {
            Direction = ParameterDirection.Output
        };
        SqlParameter Pass = new SqlParameter("@Password", SqlDbType.NVarChar, 20)
        { 
            Direction = ParameterDirection.Output 
        };
        SqlParameter Atype = new SqlParameter("@Account_Type", SqlDbType.NVarChar, 20)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(User);
        cmd.Parameters.Add(Pass);
        cmd.Parameters.Add(Atype);
        cmd.ExecuteNonQuery();
        Username_Out = User.Value.ToString();
        Password = Pass.Value.ToString();
        Account_Type = Atype.Value.ToString();
        cmd.Dispose();
        con.Close();
        con.Dispose();




    }


    public void GetAccount(string Username, out string Account_Type, out string USN)
    {
        int Account_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetAccount_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Username", Username);
        SqlParameter AID = new SqlParameter("@Account_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(AID);
        comms.ExecuteNonQuery();
        Account_ID = int.Parse(AID.Value.ToString());
        comms.Dispose();

        SqlCommand cmd = new SqlCommand("sp_GetAccount", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        SqlParameter Usern = new SqlParameter("@Username", System.Data.SqlDbType.NVarChar)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.Add(Usern);
        SqlParameter AT = new SqlParameter("@Account_Type", System.Data.SqlDbType.NVarChar)
        {
           Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.Add(AT);
        cmd.Parameters.AddWithValue("@Username", Username);
        cmd.ExecuteNonQuery();
        Account_Type = AT.Value.ToString();
        USN = Usern.Value.ToString();
        cmd.Dispose();
        con.Close();
        return;
    }

    public string InsertAccount(string Username,string Password,string Account_Type)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_InsertAccount", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Username", Username);
        cmd.Parameters.AddWithValue("@Password", Password);
        cmd.Parameters.AddWithValue("@Account_Type", Account_Type);
        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();
        return "Account Created!";
    }

    public string UpdateAccount(string Username,string New_Username, string Password, string Account_Type)
    {
        int Account_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetAccount_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Username", Username);
        SqlParameter AID = new SqlParameter("@Account_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(AID);
        comms.ExecuteNonQuery();
        Account_ID = int.Parse(AID.Value.ToString());
        comms.Dispose();

        SqlCommand cmd = new SqlCommand("sp_UpdatePerson", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Username", New_Username);
        cmd.Parameters.AddWithValue("@Password", Password);
        cmd.Parameters.AddWithValue("@Account_Type", Account_Type);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        return "Account Updated!";
    }

    public string DeleteAccount(string Username)
    {
        int Account_ID;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetAccount_ID", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        comms.Parameters.AddWithValue("@Username", Username);
        SqlParameter AID = new SqlParameter("@Account_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(AID);
        comms.ExecuteNonQuery();
        Account_ID = int.Parse(AID.Value.ToString());
        comms.Dispose();

        SqlCommand cmd = new SqlCommand("sp_DeleteAccount", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        return "Account Deleted!";

    }






}