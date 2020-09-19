using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace StillWhat
{
    public partial class Form1 : Form
    {
        string fileName = "";

        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;

        string cs = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Picture Library";
            conn = new SqlConnection();
            cs = ConfigurationManager.
            ConnectionStrings["LibraryConnection"].
            ConnectionString;
            conn.ConnectionString = cs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                set = new DataSet();
                string sql = textBox1.Text;
                if (textBox1.Text == "")
                    sql = "select * from Books";
                else sql = textBox1.Text;
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;

                //SqlCommand updateCommand = new SqlCommand("UpdateBooks", conn);
                //updateCommand.CommandType = CommandType.StoredProcedure;

                //SqlParameterCollection cparams;
                //cparams = updateCommand.Parameters;
                //cparams.Add("@pid", SqlDbType.Int, 0, "id");
                //cparams["@pid"].SourceVersion = DataRowVersion.Original;
                //cparams.Add("@pAuthorId", SqlDbType.Int, 8, "AuthorId");
                //cparams.Add("@pTitle", SqlDbType.VarChar, 100, "Title");
                //cparams.Add("@pPrice", SqlDbType.Int, 8, "PRICE");
                //cparams.Add("@pPages", SqlDbType.Int, 8, "PAGES");
                //cparams.Add("@pExtraInfo", SqlDbType.VarChar, 100, "ExtraInfo");

                //da.UpdateCommand = updateCommand;
                cmd = new SqlCommandBuilder(da);
                da.Fill(set, "mybook");
                dataGridView1.DataSource = set.Tables["mybook"];
            }
            catch (Exception exp)
            {
                MessageBox.Show("Oh shit, here we go again.");
                MessageBox.Show(exp.Message);
            }
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.Update(set, "mybook");
        }

        private void loadPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp;*.gif;*.jpg; *.png";
            ofd.FileName = "";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = ofd.FileName;
                LoadPicture();
            }
        }

        private void LoadPicture()
        {
            try
            {
                byte[] bytes;
                bytes = CreateCopy();
                conn.Open();
                SqlCommand comm = new SqlCommand("insert into Pictures(bookid, name, picture) values (@bookid, @name, @picture); ", conn);
                if (textBox1.Text == null || textBox1.Text.Length == 0) return;
                int index = -1;
                int.TryParse(textBox1.Text, out index);
                if (index == -1) return;
                comm.Parameters.Add("@bookid", SqlDbType.Int).Value = index;
                comm.Parameters.Add("@name", SqlDbType.NVarChar, 255).
                Value = fileName;
                comm.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).
                Value = bytes;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        private byte[] CreateCopy()
        {
            Image img = Image.FromFile(fileName);
            int maxWidth = 300, maxHeight = 300;
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);
            Image mi = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newWidth, newHeight);
            MemoryStream ms = new MemoryStream();
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("select * from Pictures; ", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                set = new DataSet();
                da.Fill(set, "picture");
                dataGridView1.RowTemplate.Height = 300;
                dataGridView1.DataSource = set.Tables["picture"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null || textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id книги!");
                    return;
                }
                int index = -1;
                int.TryParse(textBox1.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id книги в правильном формате!");
                    return;
                }
                da = new SqlDataAdapter("select picture from Pictures where id = @id; ", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = index;
                set = new DataSet();
                da.Fill(set);
                byte[] bytes = (byte[])set.Tables[0].
                Rows[0]["picture"];
                MemoryStream ms =
                new MemoryStream(bytes);
                pictureBox1.Image =Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
