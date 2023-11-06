using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;
#pragma warning disable IDE0017
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;
//using System.Drawing;

//using System.Windows.Forms;
//public class MessageBox
//{

//}
namespace St_Fees
{
    public partial class DisplayFees_St : System.Web.UI.Page
    {
        public bool StExst = false;
        public SqlConnection cnn = new SqlConnection("Data Source=196.219.36.20;Initial Catalog=AlssonAtt;Persist Security Info=True;User ID=alssonatt_login;Password=Alsson@2023");

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCY.ReadOnly = true;
            txtCY.MaxLength = 4;
            txtCY.Width = 50;
            //Label1.CssClass = "stt1";
            txtNatID.MaxLength = 14;
            txtFullName.Width = 550;
            txtStID.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtYGP.ReadOnly = true;
            txtStID.ForeColor = Color.Blue;
            txtFullName.ForeColor = Color.Blue;
            txtYGP.ForeColor = Color.Blue;
            System.Text.RegularExpressions.Regex.IsMatch(txtNatID.Text, "[ ^ 0-9]");
            txtNatID.Focus();
            //Here is the connection string of the server
            //Data Source=196.219.36.20;Initial Catalog=AlssonAtt;Persist Security Info=True;
            //User ID=alssonatt_login;Password=Alsson@2023
            //Console.WriteLine(cnn.ConnectionString);
        }
        //private void txtNatID_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtNatID.Text, "  ^ [0-9]"))
        //    {
        //        txtNatID.Text = "";
        //    }
        //}
        //private void txtNatID_KeyPress(object sender, System.Windows.Input.KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }
        //}
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            //if (cnn.State == ConnectionState.Closed) 
            //{
            //    cnn.Open();
            //}
            CreateTbb();
            FillGV();
            AdjGrd();
            txtNatID.Text = "";

        }
        void CreateTbb()
        {
            if (txtNatID.Text == "")
            {
                Response.Write("<script>alert('Please, write national ID!!');</script>");
                return;
            }
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            //string Spp;
            //Spp = "EXECUTE [DropTbb] '" + txtNatID.Text + "'";
            SqlCommand DropSql = new SqlCommand("DropTbb", cnn);
            DropSql.CommandType = CommandType.StoredProcedure;
            DropSql.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            DropSql.ExecuteNonQuery();

            SqlCommand CreateSql = new SqlCommand("CreateTbb", cnn);
            CreateSql.CommandType = CommandType.StoredProcedure;
            CreateSql.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            CreateSql.ExecuteNonQuery();

            SqlCommand AppndRecSql = new SqlCommand("AppendRec", cnn);
            AppndRecSql.CommandType = CommandType.StoredProcedure;
            AppndRecSql.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql.Parameters.AddWithValue("@CYY", txtCY.Text);
            AppndRecSql.Parameters.AddWithValue("@Trmm", 1);
            AppndRecSql.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql.ExecuteNonQuery();
            AppndRecSql.Dispose();

            SqlCommand AppndRecSql_2 = new SqlCommand("AppendRec", cnn);
            AppndRecSql_2.CommandType = CommandType.StoredProcedure;
            AppndRecSql_2.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql_2.Parameters.AddWithValue("@CYY", txtCY.Text);
            AppndRecSql_2.Parameters.AddWithValue("@Trmm", 2);
            AppndRecSql_2.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql_2.ExecuteNonQuery();
            AppndRecSql_2.Dispose();

            SqlCommand AppndRecSql_3 = new SqlCommand("AppendRec", cnn);
            AppndRecSql_3.CommandType = CommandType.StoredProcedure;
            AppndRecSql_3.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql_3.Parameters.AddWithValue("@CYY", txtCY.Text);
            AppndRecSql_3.Parameters.AddWithValue("@Trmm", 3);
            AppndRecSql_3.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql_3.ExecuteNonQuery();
            AppndRecSql_3.Dispose();

            SqlCommand AppndRecSql_4 = new SqlCommand("AppendRec", cnn);
            AppndRecSql_4.CommandType = CommandType.StoredProcedure;
            AppndRecSql_4.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql_4.Parameters.AddWithValue("@CYY", txtCY.Text);
            AppndRecSql_4.Parameters.AddWithValue("@Trmm", 4);
            AppndRecSql_4.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql_4.ExecuteNonQuery();
            AppndRecSql_4.Dispose();
            //START TO FILL THE TOTAL DISCOUNT & TOTAL PAID
            SqlCommand AppndRecSql_5 = new SqlCommand("UpdtDisc", cnn);
            AppndRecSql_5.CommandType = CommandType.StoredProcedure;
            AppndRecSql_5.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql_5.Parameters.AddWithValue("@CYY", txtCY.Text);
            //AppndRecSql_5.Parameters.AddWithValue("@Trmm", 1);
            //AppndRecSql_5.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql_5.ExecuteNonQuery();
            AppndRecSql_5.Dispose();

            SqlCommand AppndRecSql_6 = new SqlCommand("UpdtPaid", cnn);
            AppndRecSql_6.CommandType = CommandType.StoredProcedure;
            AppndRecSql_6.Parameters.AddWithValue("@TbNm", txtNatID.Text);
            AppndRecSql_6.Parameters.AddWithValue("@CYY", txtCY.Text);
            //AppndRecSql_6.Parameters.AddWithValue("@Trmm", 1);
            //AppndRecSql_6.Parameters.AddWithValue("@Typp", 0);
            AppndRecSql_6.ExecuteNonQuery();
            AppndRecSql_6.Dispose();

            string Spp1;
            Spp1 = "UPDATE DBO.[" + txtNatID.Text + "] SET TOTDUE=FEES-TOTDISC";
            SqlCommand rfrshDsc = new SqlCommand(Spp1, cnn);
            rfrshDsc.ExecuteNonQuery();

            Spp1 = "UPDATE DBO.[" + txtNatID.Text + "] SET REM=TOTDUE-TOTPAID";
            SqlCommand rfrshRmm = new SqlCommand(Spp1, cnn);
            rfrshRmm.ExecuteNonQuery();

            cnn.Close();

        }
        void FillGV()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            //get students info using a data reader.
            string sqq;
            sqq = "SELECT DISTINCT S_CODE,FULLNAME,STAGENAME,natid ";
            //sqq = sqq + " FROM ACC.DBO.PAYMENTS.STUDENTS_INFO S INNER JOIN  ACC.DBO.PAYMENTS.STAGES_M SM ";
            //sqq = sqq + " ON S.STAGECODE=SM.STAGECODE AND S.CURYEAR=SM.CURYEAR ";
            sqq += " FROM STINFO ";
            sqq += " WHERE CURYEAR='" + txtCY.Text + "'";
            sqq += " AND NATID='" + txtNatID.Text + "'";
            SqlCommand CMDD = new SqlCommand(sqq, cnn);
            SqlDataReader Rdr = CMDD.ExecuteReader();
            try
            {
                while (Rdr.Read())
                {
                    StExst = true;
                    txtStID.Text = Rdr[0].ToString();
                    txtFullName.Text = Rdr[1].ToString();
                    txtYGP.Text = Rdr[2].ToString();
                }
            }
            catch (SqlException exx)
            {
                //MessageBox.Show(exx.Message);
                Console.WriteLine(exx.ToString());
            }
            //SqlDataAdapter sqlstt = new SqlDataAdapter("Getstinfo", cnn);
            //sqlstt.SelectCommand.CommandType = CommandType.StoredProcedure;
            ////DataTable sqlTbl = new DataTable();
            //sqlstt.SelectCommand.Parameters.AddWithValue("@NATID", txtNatID.Text);
            //sqlstt.SelectCommand.Parameters.AddWithValue("@CY", txtCY.Text);
            ////sqlstt.Fill(sqlTbl);
            ////cnn.Close();
            ////GvGetFees.DataSource = sqlTbl;
            ////GvGetFees.DataBind();
            Rdr.Close();
            if (StExst == false)
            {
                Response.Write("<script>alert('Please, write valid national ID!!');</script>");
                return;
            }
            SqlDataAdapter sqlAda = new SqlDataAdapter("GetFeesData", cnn);
            sqlAda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable sqlTbl = new DataTable();
            sqlAda.SelectCommand.Parameters.AddWithValue("@NATID", txtNatID.Text);
            sqlAda.Fill(sqlTbl);
            GvGetFees.DataSource = sqlTbl;
            GvGetFees.DataBind();
            //AdjGrd();
            cnn.Close();

        }
        protected void AdjGrd()
        {
            for (int i = 0; i <= GvGetFees.Rows.Count - 1; i++)
            {
                //Label lblparent = (Label)GvGetFees.Rows[i].FindControl("Label1");

//                if (i == 0)
//                {
                    for (int ii = 0; ii <= GvGetFees.Columns.Count - 1; ii++)
                    {

                        GvGetFees.Rows[i].Cells[ii].Font.Bold = false;
                        GvGetFees.Rows[i].Cells[ii].Font.Size = 12;
                        //GvGetFees.Rows[i].Cells[ii].BackColor = Color.Black;
                        //GvGetFees.Rows[i].Cells[ii].ForeColor = Color.White;
                    if (i == 0 || i == 2)
                        { 
                        GvGetFees.Rows[i].Cells[ii].BackColor = Color.White;
                        GvGetFees.Rows[i].Cells[ii].ForeColor = Color.Black;
                        }
                        else
                        {
                        GvGetFees.Rows[i].Cells[ii].BackColor = Color.Black ;
                        GvGetFees.Rows[i].Cells[ii].ForeColor = Color.White ;

                        }
                    //switch (ii)
                    //{
                    //    Case 0:
                    //}    
                    if (ii == 0 || ii == 1 || ii == 2)
                        {
                            GvGetFees.Rows[i].Cells[ii].HorizontalAlign  = HorizontalAlign.Left ;
                        }

                        //if (ii == 3 || ii == 4 || ii == 5 || ii == 6 || ii == 7)
                        else 
                        {
                            GvGetFees.Rows[i].Cells[ii].HorizontalAlign = HorizontalAlign.Right;
                        }

                    }
                    //lblparent.ForeColor = Color.Black;
                //}
                //else
                //{
                //    for (int ii = 0; ii <= GvGetFees.Columns.Count - 1; ii++)
                //    {

                //        GvGetFees.Rows[i].Cells[ii].BackColor = Color.White;
                //        GvGetFees.Rows[i].Cells[ii].Font.Bold = false;
                //        GvGetFees.Rows[i].Cells[ii].Font.Size = 8;
                //        GvGetFees.Rows[i].Cells[ii].ForeColor = Color.Black;

                //    }

                //}
            }

        }
    }
}