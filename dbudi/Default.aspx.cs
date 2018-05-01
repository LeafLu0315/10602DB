using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    /* Insert */
    protected void Button1_Click(object sender, EventArgs e) {
        Label4.Text = "Values :( ";
        Label6.Text = ")";
        Label1.Visible = true;
        Label4.Visible = true;
        Label5.Visible = false;
        Label6.Visible = true;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = false;
        Global.act = 1;
    }
    /* Delete */
    protected void Button2_Click(object sender, EventArgs e) {
        Label4.Text = "Condition : ";
        Label1.Visible = true;
        Label4.Visible = true;
        Label5.Visible = false;
        Label6.Visible = false;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = false;
        Global.act = 2;
    }
    /* Update */
    protected void Button3_Click(object sender, EventArgs e) {
        Label4.Text = "SET : ";
        Label1.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = false;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
        Global.act = 3;
        
    }
    /* Submit */
    protected void Button4_Click(object sender, EventArgs e) {
        switch (Global.act) {
            case 1:
                Global.str = "INSERT INTO "+ TextBox1.Text+" VALUES(" + TextBox2.Text + ")";
                break;
            case 2:
                Global.str = "DELETE FROM " + TextBox1.Text;
                if (TextBox2.Text != "") Global.str += " WHERE " + TextBox2.Text;
                break;
            case 3:
                Global.str = "UPDATE " + TextBox1.Text + " SET " + TextBox2.Text;
                if (TextBox3.Text != "") Global.str += " WHERE " + TextBox3.Text;
                break;
            default:
                break;
        }
        if (Global.str != "") {
            Label3.Text = Global.str;
            connectSQL(Global.str);
        }
        else Label3.Text = "NO action can be done <br/>";
    }

    public void connectSQL(string str){
        // connection string
        string DBName = "DB405530038", Server = "140.123.174.54", Username = "DB405530038", Password = "johnson7511333@yahoo.com.tw";
        string TableName = TextBox1.Text;
        string strConn = "Data Source = " + Server +
                        "; Initial Catalog = " + DBName +
                        "; User ID = " + Username +
                        "; Password = " + Password + ";";
        /* 建立連接 */
        SqlConnection myConn = new SqlConnection(strConn);
        /* 打開連接 */
        myConn.Open();
        // prepare connection and SQL statement
        SqlCommand myCommand = new SqlCommand(str, myConn);
        SqlDataReader myDataReader = myCommand.ExecuteReader();
    }

    
}

public class Global {
    public static string str = "";
    public static int act = 0;
}