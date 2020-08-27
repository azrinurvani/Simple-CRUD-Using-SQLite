using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DBConnectivy
{
    public partial class Form1 : Form
    {
        //connection Object
        SQLiteConnection con = new SQLiteConnection(@"data source =D:\Azri's Project\.NET Core\database\net_db.db;version=3;New=True;Compress=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_click(object sender, EventArgs e)
        {
         
            con.Open();
            //command object
            string query = "SELECT * FROM Student";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            //data table
            DataTable dt = new DataTable();

            //adapter
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            adapter.Fill(dt);
                
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM Student WHERE id=3";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE Student SET " +
                "first_name = 'User',last_name='Test',email='usertest@gmail.com'," +
                "password='password',gender='Female'" +
                "WHERE id = 4";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO Student (id,first_name,last_name,email,gender) VALUES(4,'Test2','User','testuser@gmail.com','Female')";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.ExecuteNonQuery();
      
            con.Close();
        }
    }
}
