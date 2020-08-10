using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Person
/// </summary>
public class DBPerson
{
    public DBPerson()
    {
    }

    public string GetPersonFull(string Username)
    {
        int Account_ID;
        int Person_ID;
        string Fullname;
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand comms = new SqlCommand("sp_GetAccount_ID", con);
        comms.CommandType = System.Data.CommandType.StoredProcedure;
        comms.Parameters.AddWithValue("@Username", Username);
        SqlParameter param = new SqlParameter("@Account_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        comms.Parameters.Add(param);
        comms.ExecuteNonQuery();
        Account_ID = int.Parse(param.Value.ToString());
        comms.Dispose();

        //Code to get Person_ID from Person_ID
        SqlCommand com = new SqlCommand("sp_GetPerson_ID", con);
        com.CommandType = System.Data.CommandType.StoredProcedure;
        com.Parameters.Add("@Account_ID", System.Data.SqlDbType.BigInt).Value = Account_ID;
        SqlParameter PID = new SqlParameter("@Person_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        com.Parameters.Add(PID);
        com.ExecuteNonQuery();
        Person_ID = int.Parse(PID.Value.ToString());
        com.Dispose();

        SqlCommand cmd = new SqlCommand("sp_GetPersonFull", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        SqlParameter Fulln = new SqlParameter("@Fullname", System.Data.SqlDbType.NVarChar)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        cmd.Parameters.AddWithValue("@Person_ID", Person_ID);
        cmd.Parameters.Add(Fulln);
        cmd.ExecuteNonQuery();
        Fullname = Fulln.Value.ToString();
        con.Dispose();
        cmd.Dispose();
        con.Close();

        return Fullname;
     }

    public string InsertPerson(string LN,string GN, string MN, string Username, string Sfx)
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

        SqlCommand cmd = new SqlCommand("sp_InsertPerson", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Last_Name", LN);
        cmd.Parameters.AddWithValue("@Given_Name", GN);
        cmd.Parameters.AddWithValue("@Middle_Name", MN);
        cmd.Parameters.AddWithValue("@Suffix", Sfx);
        cmd.Parameters.AddWithValue("@Account_ID",Account_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Dispose();
        con.Close();
        return "Person Added!";
    }

    public string UpdatePerson(string Last_Name, string Given_Name, string Middle_Name, string Suffix, string Username)
    {
        int Person_ID;
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


        SqlCommand com = new SqlCommand("sp_GetPerson_ID", con);
        com.CommandType = System.Data.CommandType.StoredProcedure;
        com.Parameters.Add("@Account_ID", System.Data.SqlDbType.BigInt).Value = Account_ID;
        SqlParameter PID = new SqlParameter("@Person_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        com.Parameters.Add(PID);
        com.ExecuteNonQuery();
        Person_ID = int.Parse(PID.Value.ToString());
        com.Dispose();

        SqlCommand cmd = new SqlCommand("sp_UpdatePerson", con)
        {
            CommandType = System.Data.CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@Last_Name", Last_Name);
        cmd.Parameters.AddWithValue("@Given_Name", Given_Name);
        cmd.Parameters.AddWithValue("@Middle_Name", Middle_Name);
        cmd.Parameters.AddWithValue("@Suffix", Suffix);
        cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
        cmd.Parameters.AddWithValue("@Person_ID", Person_ID);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();

        return "Personal Information Updated!";
    }

    public string DeletePerson (string Username)
    {
        int Person_ID;
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


        SqlCommand com = new SqlCommand("sp_GetPerson_ID", con);
        com.CommandType = System.Data.CommandType.StoredProcedure;
        com.Parameters.Add("@Account_ID", System.Data.SqlDbType.BigInt).Value = Account_ID;
        SqlParameter PID = new SqlParameter("@Person_ID", System.Data.SqlDbType.BigInt)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        com.Parameters.Add(PID);
        com.ExecuteNonQuery();
        Person_ID = int.Parse(PID.Value.ToString());
        com.Dispose();

        SqlCommand cmd = new SqlCommand("sp_DeletePerson", con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Person_ID",Person_ID);
        cmd.ExecuteNonQuery();
        con.Close();
        cmd.Dispose();

        return "Person Deleted!";
    }




}