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
        Button2.Visible = false;
        if (!Page.IsPostBack)
        {
            BindData();
            BindData1();
        }

    }



    public void button1Clicked(object sender, EventArgs args)
    {
        Button2.Visible = true;

        Button3.Visible = false;

        ddl2.Visible = false;

        BindGrid();

       

  }


    protected void BindGrid()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT student.id, student.name from student inner join registration on student.id=registration.sid where registration.cid=(select cid from course where cname=@course); ";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add("course", ddl1.SelectedItem.ToString());
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



    protected void BindData1()
    {

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();

        string query = "select name from student";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }


        connection.Open();



        DataTable dt = new DataTable();




        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        connection.Close();
        foreach (DataRow row in dt.Rows)
        {
            ddl2.Items.Add(row["name"].ToString());
        }

        connection.Close();




    }



        protected void BindData()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT cname FROM course";

        SqlCommand cmd = new SqlCommand(query, connection);
        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }
        connection.Open();
        DataTable dt = new DataTable();




        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        connection.Close();
        foreach (DataRow row in dt.Rows)
        {
            ddl1.Items.Add(row["cname"].ToString());
        }

  }

    public void Button2Clicked(object sender, EventArgs args)
    {
        Button3.Visible = true;
        
        ddl2.Visible = true;

        
    }

    public void Button3Clicked(object sender, EventArgs args)
    {

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();

        int s = 4;
        int t = 0;
        int s_id = 0;
        int c_id = 0;


        string query1 = "select id from student where Name=@name;";

        SqlCommand cmd1 = new SqlCommand(query1, connection);

        if (cmd1.Connection.State == ConnectionState.Open)
        {
            cmd1.Connection.Close();
        }




        connection.Open();
        cmd1.Parameters.Add(("@name"), ddl2.SelectedValue.ToString());

        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();

        da1.Fill(dt1);
        connection.Close();

        foreach (DataRow row in dt1.Rows)
        {
            Int32.TryParse(row["id"].ToString(), out s_id);
        }









        string query2 = "select cid from course where cname=@cname;";

        SqlCommand cmd2 = new SqlCommand(query2, connection);

        if (cmd2.Connection.State == ConnectionState.Open)
        {
            cmd2.Connection.Close();
        }




        connection.Open();
        cmd2.Parameters.Add(("@cname"), ddl1.SelectedValue.ToString());
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();

        da2.Fill(dt2);
        connection.Close();

        foreach (DataRow row in dt2.Rows)
        {
            Int32.TryParse(row["cid"].ToString(), out c_id);
        }













        string query3 = "select tid from registration;";

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

        int temp = 0;

        foreach (DataRow row in dt3.Rows)
        {
            
            Int32.TryParse(row["tid"].ToString(), out t);
            if (t > temp)
                temp = t;
     }
        temp++;



        string query = "insert into registration values ( @tid,@sid,@cid,@sem );";

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }

        


        connection.Open();
        cmd.Parameters.Add(("@tid"), temp);
        cmd.Parameters.Add(("@sid"), s_id);
        cmd.Parameters.Add(("@cid"), c_id);
        cmd.Parameters.Add(("@sem"), s);



        cmd.ExecuteNonQuery();
        connection.Close();
        BindGrid();

    }


}



    

