using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Branch
/// </summary>
public class DBBranch
{
    public DBBranch()
    {
     
    }

    public void GetBranch(string Branch_Name, out string Branch_Address)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_GetBranch", con);
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        SqlParameter BA = new SqlParameter("@Branch_Address", System.Data.SqlDbType.NVarChar)
        { Direction = System.Data.ParameterDirection.Output };
        cmd.Parameters.Add(BA);
        cmd.ExecuteNonQuery();
        Branch_Address = BA.Value.ToString();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return;


    }

    public string InsertBranch(string Branch_Name, string Branch_Address)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_InsertBranch", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        cmd.Parameters.AddWithValue("@Branch_Address", Branch_Address);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        return "Branch Created";
    }

    public string DeleteBranch(string Branch_Name)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("sp_DeleteBranch", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();

        return "Branch Deleted";
    }

    public string UpdateBranch(string Branch_Name, string New_Name, string Branch_Address)
    {
        SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
        constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
        constring.UserID = "mpaladine15";
        constring.Password = "Hello_World1234";
        constring.InitialCatalog = "131L";
        constring.IntegratedSecurity = false;
        SqlConnection con = new SqlConnection(constring.ConnectionString);
        con.Open();


        SqlCommand cmd = new SqlCommand("sp_UpdateBranch", con)
        { CommandType = System.Data.CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Branch_Name", Branch_Name);
        cmd.Parameters.AddWithValue("@Branch_Address", Branch_Address);
        cmd.Parameters.AddWithValue("@Branch_Name_New", New_Name);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        con.Dispose();
        return "Branch Info Updated";





    }








}