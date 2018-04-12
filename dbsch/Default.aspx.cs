using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // connection string
        string DBName = "DB405530038" , Server = "140.123.174.54", Username = "DB405530038", Password = "johnson7511333@yahoo.com.tw";
        string TableName = "Info", FieldName = "ID";
        string strConn = "Data Source = " + Server +
                        "; Initial Catalog = " + DBName +
                        "; User ID = "+ Username +
                        "; Password = "+ Password +";";
        string strSQL = " ";
        //建立連接
        SqlConnection myConn = new SqlConnection(strConn);
        //打開連接
        myConn.Open();
        if (TextBox1.Text != "") strSQL = @"SELECT * FROM " + TableName + " WHERE [" + FieldName + "] = '" + TextBox1.Text + "'";
        //set SQL command string
        // prepare connection and SQL statement
        SqlCommand myCommand = new SqlCommand(strSQL, myConn);
        SqlDataReader myDataReader = myCommand.ExecuteReader();
        Label2.Text = "";
        while (myDataReader.Read())
            if (myDataReader[FieldName].ToString() != ""){
                String text = String.Format("學號: {0}, 姓名: {1}, 系所代碼: {2}", myDataReader["ID"].ToString(), myDataReader["Name"].ToString(), myDataReader["Department"].ToString());
                Label2.Text += text;
                Label2.Text += "<br/>";          
            }
        if (Label2.Text == "") Label2.Text = "No Result ! <br/>";
        if (TextBox1.Text == "") Label2.Text = "Please enter the ID !<br/>";
    }
}