using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeGenerator.Common;

namespace CodeGenerator
{
    public partial class MainForm : Form
    {
        string outPutFileLocation = string.Empty;
        public MainForm()
        {
            InitializeComponent();
            setLoginTextBox("desable");
            cbDal.Enabled = false;
            cbWcf.Enabled = false;
        }

        private void setLoginTextBox(string status)
        {
            if (status == "desable")
            {
                txtLoginName.Enabled = false;
                txtLoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                txtPassword.Enabled = false;
                txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            }
            else
            {
                txtLoginName.Enabled = true;
                txtLoginName.BackColor = System.Drawing.Color.White;
                txtPassword.Enabled = true;
                txtPassword.BackColor = System.Drawing.Color.White;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnProjectLocation_Click(object sender, EventArgs e)
        {
            fdProjectLocation.ShowDialog();
            outPutFileLocation = fdProjectLocation.SelectedPath;
        }

        private void rdoSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            setLoginTextBox("enable");
        }

        private void rdoWidows_CheckedChanged(object sender, EventArgs e)
        {
            setLoginTextBox("desable");
        }

        private void showMessage(string message, string type)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = (type == "Error") ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (outPutFileLocation == string.Empty)
                {
                    showMessage("Please select output directory", "Error");
                    return;
                }

                if (txtProjectName.Text == string.Empty)
                {
                    showMessage("Please enter the project name", "Error");
                    return;
                }

                if (cbDal.Checked !=true && cbWebApi.Checked !=true && cbWcf.Checked !=true)
	{
		 showMessage("Please select any project type", "Error");
                    return;
	}
                if (txtServerName.Text == string.Empty && txtDataBaseName.Text == string.Empty)
                {

                    showMessage("Please enter server name and database name", "Error");
                    return;               
                }
                var connectionString = string.Empty;

                // Build the connection string
                if (rdoWidows.Checked)
                {
                    connectionString = "Server=" + txtServerName.Text + "; Database=" + txtDataBaseName.Text + "; Integrated Security=SSPI;";
                }
                else
                {
                    if (txtLoginName.Text == string.Empty && txtPassword.Text == string.Empty)
                    {
                        showMessage("Please enter the sql cridentical", "Error");
                        return;
                    }
                    connectionString = "Server=" + txtServerName.Text + "; Database=" + txtDataBaseName.Text + "; User ID=" + txtLoginName.Text + "; Password=" + txtPassword.Text + ";";
                }
                var projectName = txtProjectName.Text;
                var nameSpace = txtNameSpaceName.Text == string.Empty ? projectName : txtNameSpaceName.Text;
                CSGenerator.Generate(outPutFileLocation, connectionString, projectName, nameSpace, cbWebApi.Checked, cbWcf.Checked, cbDal.Checked);
                progressBar.Value = 100;
            }
            catch (Exception ex)
            {

                showMessage(ex.Message, "Error");
            }
        }
    }
}
