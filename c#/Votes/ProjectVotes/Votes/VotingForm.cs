using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Votes
{
    public partial class VotingForm : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VotingSystem.accdb";
        private int loggedInUserID;
        public VotingForm(int userID)
        {
            InitializeComponent();
            loggedInUserID = userID;
        }
        private void VotingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxTopics.SelectedItem == null)
            {
                MessageBox.Show("لطفا موضوع رای گیری را انتخاب کنید");
                return;
            }

            string selectedVote = GetSelectedVote();
            if (string.IsNullOrEmpty(selectedVote))
            {
                MessageBox.Show("لطفا یک گزینه را برای رای انتخاب کنید");
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Votes (UserID, Topic, Vote) VALUES (@UserID, @Topic, @Vote)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", loggedInUserID);
                    command.Parameters.AddWithValue("@Topic", comboBoxTopics.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Vote", selectedVote);
                    command.ExecuteNonQuery();
                    MessageBox.Show("رای با موفقیت انجام شد");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private string GetSelectedVote()
        {
            if (radioOption1.Checked) return radioOption1.Text;
            if (radioOption2.Checked) return radioOption2.Text;
            if (radioOption3.Checked) return radioOption3.Text;
            return null;
        }

    }
}
