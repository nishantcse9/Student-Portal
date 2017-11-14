using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
        findbal();

    }

    protected void BindGrid()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT * from passbook; ";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }
        connection.Open();
        DataSet ds = new DataSet();




        SqlDataAdapter da = new SqlDataAdapter(cmd);

        da.Fill(ds);

        connection.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            table1.DataSource = ds;
            table1.DataBind();
            table1.Visible = true;
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            table1.DataSource = ds;
            table1.DataBind();
            int columncount = table1.Rows[0].Cells.Count;
            table1.Rows[0].Cells.Clear();
            table1.Rows[0].Cells.Add(new TableCell());
            table1.Rows[0].Cells[0].ColumnSpan = columncount;
            table1.Rows[0].Cells[0].Text = "No Records Found";
        }

    }

    protected void findbal()
    {

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT * from passbook; ";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }
        connection.Open();
        DataTable ds = new DataTable();




        SqlDataAdapter da = new SqlDataAdapter(cmd);

        da.Fill(ds);

        connection.Close();

        int balance = 0;
        int temp = 0;

        foreach (DataRow row in ds.Rows)
        {
            if (row["Type"].ToString() == "CREDIT")
            {
                Int32.TryParse(row["Amount"].ToString(), out temp);
                balance += temp;
            }
            else
            {
                Int32.TryParse(row["Amount"].ToString(), out temp);
                balance -= temp;
            }
        }
        label2.Text = "RS " + balance.ToString();


    }


    public void button1Clicked(object sender, EventArgs args)
    {
        button1.Visible = false;
        button2.Visible = true;
        ddl1.Visible = true;
        TextBox1.Visible = true;

    }

    public void button2Clicked(object sender, EventArgs args)
    {


        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();

        string query3 = "select Transaction_Id from passbook;";

        SqlCommand cmd3 = new SqlCommand(query3, connection);
        if (cmd3.Connection.State == ConnectionState.Open)
        {
            cmd3.Connection.Close();
        }
        connection.Open();
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);
        connection.Close();
        int t = 0;
        int temp = 0;

        foreach (DataRow row in dt3.Rows)
        {

            Int32.TryParse(row["Transaction_Id"].ToString(), out t);
            if (t > temp)
                temp = t;
        }
        temp++;

        string query = "insert into passbook values ( @tid,@type,@amt );";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }


        int a=0;
        Int32.TryParse(TextBox1.Text, out a);

        connection.Open();



        string ty="";

        if(int.Parse(ddl1.SelectedValue)==1)
        {
            ty = "CREDIT";
        }
        else if(int.Parse(ddl1.SelectedValue) == 2)
        {
            ty = "DEBIT";
        }
        cmd.Parameters.Add(("@tid"), temp);
        cmd.Parameters.Add(("@type"), ty);
        cmd.Parameters.Add(("@amt"), a);
        



        cmd.ExecuteNonQuery();
        connection.Close();
        BindGrid();
        findbal();



    }
}