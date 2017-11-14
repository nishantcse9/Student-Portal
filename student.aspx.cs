using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

public partial class student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }




    protected void BindData()
    {



        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT * FROM student";
        
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

    public void button1Clicked(object sender, EventArgs args)
    {

        Button1.Visible = false;

       




        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        button2.Visible = true;
        button3.Visible = true;
    }



    public void Button2Clicked(object sender, EventArgs args)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();

        string query = "insert into student values ( @id,@name,@dob,@address );";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }


        connection.Open();
        cmd.Parameters.Add(("@id"), TextBox1.Text);
        cmd.Parameters.Add(("@name"), TextBox2.Text);
        cmd.Parameters.Add(("@dob"), TextBox3.Text);
        cmd.Parameters.Add(("@address"), TextBox4.Text);
        


        cmd.ExecuteNonQuery();
        connection.Close();
        BindData();
        
    }



        public void Button3Clicked(object sender, EventArgs args)
    {




        Button1.Visible = true;



        TextBox1.Visible = false;
        TextBox2.Visible = false ;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        button2.Visible = false;
        button3.Visible = false;
    }

}
