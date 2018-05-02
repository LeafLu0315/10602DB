using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    /* Search */
    protected void Button1_Click(object sender, EventArgs e) {
        GlobalVar.act = 1;
        Label2.Text = "*SELECT : ";
        Label3.Text = "FROM   : ";
        Label4.Text = "WHERE   : ";
        Label2.Visible = Label3.Visible = Label4.Visible = true;
        TextBox1.Text = TextBox3.Text = "";
        DropDownList1.Visible = TextBox1.Visible = TextBox3.Visible = true;
        Label12.Visible = Label13.Visible = Label5.Visible = Label6.Visible = Label8.Visible = Label9.Visible = false;
        if (GlobalVar.exeution_once == false) CheckBox1.Visible = false;
        if (GlobalVar.check) Label12.Visible = Label13.Visible = Label11.Visible = true;
    }
    /* Update */
    protected void Button2_Click(object sender, EventArgs e) {
        GlobalVar.act = 2;
        Label2.Text = "*SET       : ";
        Label3.Text = "TableName : ";
        Label4.Text = "WHERE      : ";
        Label2.Visible = Label3.Visible = Label4.Visible = true;
        TextBox1.Text = TextBox3.Text = "";
        DropDownList1.Visible = TextBox1.Visible = TextBox3.Visible = true;
        Label12.Visible = Label13.Visible = Label10.Visible = Label5.Visible = Label6.Visible = Label8.Visible = Label9.Visible = false;
        if (GlobalVar.exeution_once == false) CheckBox1.Visible = false;
        if (GlobalVar.check) Label12.Visible = Label13.Visible = Label11.Visible = true;
    }
    /* Insert */
    protected void Button3_Click(object sender, EventArgs e) {
        GlobalVar.act = 3;
        Label3.Text = "TableName : ";
        Label4.Text = "*VALUES    : ";
        Label3.Visible = Label4.Visible = true;
        TextBox3.Text = "";
        DropDownList1.Visible = TextBox3.Visible = true;
        Label12.Visible = Label13.Visible = Label10.Visible = Label2.Visible = Label5.Visible = Label6.Visible = Label8.Visible = Label9.Visible = false;
        TextBox1.Visible = false;
        if (GlobalVar.exeution_once == false) CheckBox1.Visible = false;
        if (GlobalVar.check) Label12.Visible = Label13.Visible = Label11.Visible = true;
    }
    /* Delete */
    protected void Button4_Click(object sender, EventArgs e) {
        GlobalVar.act = 4;
        Label3.Text = "TableName : ";
        Label4.Text = "WHERE      : ";
        Label3.Visible = Label4.Visible = true;
        TextBox3.Text = "";
        DropDownList1.Visible = TextBox3.Visible = true;
        Label12.Visible = Label13.Visible = Label10.Visible = Label2.Visible = Label5.Visible = Label6.Visible = Label8.Visible = Label9.Visible = false;
        TextBox1.Visible = false;
        if (GlobalVar.exeution_once == false) CheckBox1.Visible = false;
        if (GlobalVar.check) Label12.Visible = Label13.Visible = Label11.Visible = true;
    }
    /* Submit */
    protected void Button5_Click(object sender, EventArgs e) {
        GlobalVar.error = false;
        Label12.Visible = Label13.Visible = Label11.Visible = false;
        Label5.Visible = true;
        Label6.Text = "";
        switch (GlobalVar.act) {
            case 1: //Search
                if (TextBox1.Text != "") {
                    GlobalVar.str = "SELECT " + TextBox1.Text + " FROM " + DropDownList1.SelectedValue;
                    if (TextBox3.Text != "") GlobalVar.str += " WHERE " + TextBox3.Text;
                }
                else GlobalVar.error = true;
                break;
            case 2: //Update
                if (TextBox1.Text != "") {
                    GlobalVar.str = "UPDATE " + DropDownList1.SelectedValue + " SET " + TextBox1.Text;
                    if (TextBox3.Text != "") GlobalVar.str += " WHERE " + TextBox3.Text;
                }
                else GlobalVar.error = true;
                break;
            case 3: //Insert
                if (TextBox3.Text != "") GlobalVar.str = "INSERT INTO " + DropDownList1.SelectedValue + " VALUES(" + TextBox3.Text + ")";
                else GlobalVar.error = true;
                break;
            case 4: //Delete
                GlobalVar.str = "DELETE FROM " + DropDownList1.SelectedValue;
                if (TextBox3.Text != "") GlobalVar.str += " WHERE " + TextBox3.Text;
                else GlobalVar.error = true;
                break;
            default:
                GlobalVar.error = true;
                break;
        }
        if (!GlobalVar.error) {
            try {
                connectSQL();
                if (!GlobalVar.error) Label10.Text = "Success! <br/>";
            }
            catch (InvalidCastException ice) {
                Label10.Text = "ERROR <br/>" + ice.ToString();
            }
            Label10.Visible = Label5.Visible = Label6.Visible = true;
        }
        else {
            Label10.Text = "Please input all * information ! <br/>";
            Label10.Visible = Label5.Visible = Label6.Visible = true;
        }
        CheckBox1.Visible = true;
        GlobalVar.exeution_once = true;
        Label11.Text = Label6.Text;
        Label12.Text = Label8.Text;
        Label13.Text = Label9.Text;
    }
    /* Connect to sql*/
    public void connectSQL() {
        // connection string
        string DBName = "DB405530038", Server = "140.123.174.54", Username = "DB405530038", Password = "johnson7511333@yahoo.com.tw";
        string strConn = "Data Source = " + Server +
                        "; Initial Catalog = " + DBName +
                        "; User ID = " + Username +
                        "; Password = " + Password + ";";
        /* 建立連接 */
        SqlConnection myConn = new SqlConnection(strConn);
        /* 打開連接 */
        myConn.Open();
        // prepare connection and SQL statement
        SqlCommand myCommand = new SqlCommand(GlobalVar.str, myConn);
        try {
            SqlDataReader myDataReader = myCommand.ExecuteReader();
            if (GlobalVar.act == 1) {
                Label8.Text = Label9.Text = Label6.Text = "";
                Label8.Visible = Label9.Visible = false;
                List<string> list = new List<string>();
                List<string> value = new List<string>();
                using (myDataReader) {
                    DataTable dt = myDataReader.GetSchemaTable();
                    foreach (DataRow dr in dt.Rows)
                        list.Add(dr.Field<string>("ColumnName"));
                    while (myDataReader.Read())
                        for (int i = 0; i < list.Count; i++) value.Add(myDataReader[list[i]].ToString());
                }
                Label8.Text += DropDownList1.SelectedValue + " Table : ";
                foreach (string s in list) {
                    Label9.Text += s + "\t ";
                }
                for (int i = 0, j = 0; i < value.Count; i++, j++) {
                    if (j >= list.Count) {
                        j = 0;
                        Label6.Text += "<br/>";
                    }
                    Label6.Text += list[j] + " : " + value[i] + " ";
                }
                myDataReader.Close();
            }
            if (Label6.Text == "") Label6.Text = "No Result ! <br/>";
        }
        catch (InvalidCastException ice) {
            Label6.Text = ice.ToString();
            GlobalVar.error = true;
        }
        catch (SqlException se) {
            Label6.Text = se.ToString();
            GlobalVar.error = true;
        }
        myConn.Close();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e) {
        if (CheckBox1.Checked) GlobalVar.check = true;
        else GlobalVar.check = false;
    }
}

public class GlobalVar {
    public static int act = 0;
    public static string str = "";
    public static bool error = false, check = false, exeution_once = false;
}