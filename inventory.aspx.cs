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
            
        }

    }



    public void button1Clicked(object sender, EventArgs args)
    {
        Button2.Visible = true;
        table1.Visible = true;
       

        BindGrid();



    }


    protected void BindGrid()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
       
        string query = String.Format("SELECT Product_id, Item, Quantity from {0} ", ddl1.SelectedItem.ToString()); 
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



   



    protected void BindData()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();
        string query = "SELECT category FROM invent";

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
            ddl1.Items.Add(row["category"].ToString());
        }

    }

    public void button2Clicked(object sender, EventArgs args)
    {

        button1.Visible = false;

        Button2.Visible = false;





        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;

        
        button3.Visible = true;
        button4.Visible = true;

    }


        public void Button3Clicked(object sender, EventArgs args)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = @"Data Source=(localDB)\MSSQLlocalDB;Initial Catalog=portal;Integrated Security=true;";
        connection.Open();

        string query = String.Format("insert into {0} values ( @id,@name,@quan );",ddl1.SelectedValue.ToString());

        SqlCommand cmd = new SqlCommand(query, connection);

        if (cmd.Connection.State == ConnectionState.Open)
        {
            cmd.Connection.Close();
        }
        int q = 0;
        Int32.TryParse(TextBox3.Text, out q);
        connection.Open();
        cmd.Parameters.Add(("@id"), TextBox1.Text);
        cmd.Parameters.Add(("@name"), TextBox2.Text);
        cmd.Parameters.Add(("@quan"),q);
        



        cmd.ExecuteNonQuery();
        connection.Close();
        BindGrid();

    }



    public void Button4Clicked(object sender, EventArgs args)
    {




        button1.Visible = true;



        TextBox1.Visible = false;
        TextBox2.Visible = false;
        TextBox3.Visible = false;
        
        Button2.Visible = false;
        button3.Visible = false;
        button4.Visible = false;
    }
}