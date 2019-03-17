using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp5
{
    
    public partial class UniFinder : Form
    {
        bool con_status = false;
        string connect_string = "datasource=localhost;port=3306;username=root;password=";

        public UniFinder()
        {

            InitializeComponent();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conDataBase = new MySqlConnection(connect_string);
                MySqlCommand cmdDataBase = new MySqlCommand(" select * from universities.uni_table ;", conDataBase);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                info_grid.DataSource = bSource;
                sda.Update(dbdataset);
                con_status = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("6/7/2018\nCreated by :\nLuis Alvarado\nChang Jin Lee\nJia Yu");
        }

        private void info_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filter_Click(object sender, EventArgs e)
        {
            if (con_status) {
                try
                {
                    string table_command = "";
                    foreach (string s in checkedListBox1.CheckedItems)
                    {
                        table_command = table_command + s + ",";
                    }
                    if (table_command.Length > 0)
                    {
                        table_command = table_command.Remove(table_command.Length - 1);
                        MySqlConnection conDataBase = new MySqlConnection(connect_string);
                        MySqlCommand cmdDataBase = new MySqlCommand(" select " + table_command + " from universities.uni_table ;", conDataBase);
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        sda.SelectCommand = cmdDataBase;
                        DataTable dbdataset = new DataTable();
                        sda.Fill(dbdataset);
                        BindingSource bSource = new BindingSource();
                        bSource.DataSource = dbdataset;
                        info_grid.DataSource = bSource;
                        sda.Update(dbdataset);
                    }
                    else
                    {
                        MessageBox.Show("Please make a selection.");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Please connect to a database.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (con_status)
            {
                info_grid.DataSource = "";
                con_status = false;
                MessageBox.Show("Disconnected.");
            }
            else
            {
                MessageBox.Show("No connection found.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
