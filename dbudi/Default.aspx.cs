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
        Label1.Text = "Table Name";
        Label4.Text = "Values :( ";
        Label6.Text = ")";
        Label1.Visible = true;
        Label2.Visible = false;
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
        Label1.Text = "Table Name";
        Label4.Text = "Condition : ";
        Label1.Visible = true;
        Label2.Visible = false;
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
        Label1.Text = "Table Name";
        Label4.Text = "SET : ";
        Label1.Visible = true;
        Label2.Visible = false;
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
        Label2.Visible = true;
        Label3.Text = "";
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
            case 4:
                Global.str = "SELECT " + TextBox1.Text + " FROM " + TextBox2.Text;
                if(TextBox3.Text != "") Global.str += " WHERE " +TextBox3.Text;
                break;
            default:
                break;
        }
        if (Global.str != "") {
            try{
                connectSQL(Global.str);
                if(Global.act < 4) Label3.Text = "Success <br/>";
            }
            catch(InvalidCastException ice){
                Label3.Text = ice.ToString();
            }
        }
        else Label3.Text = "NO action can be done <br/>";
    }
    /* Search */
    protected void Button5_Click1(object sender, EventArgs e) {
        Global.act = 4;
        Label1.Visible = true;
        Label1.Text = "SELECT ";
        Label4.Visible = true;
        Label4.Text = "FROM ";
        Label5.Visible = true;
        Label5.Text = "WHERE ";
        Label6.Visible = false;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
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
        try {
            SqlDataReader myDataReader = myCommand.ExecuteReader();
            while (myDataReader.Read())
                if (myDataReader["ID"].ToString() != "") {
                    String text = String.Format("學號: {0}, 姓名: {1}, 系所代碼: {2}", myDataReader["ID"].ToString(), myDataReader["Name"].ToString(), myDataReader["Department"].ToString());
                    Label3.Text += text+"<br/>";
                }
            if(Label3.Text == "") Label3.Text = "No Result ! <br/>";
        }
        catch(InvalidCastException ice) {
            Label3.Text = ice.ToString();
        }
    }
}

public class Global {
    public static string str = "";
    public static int act = 0;
}