using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Llatext;

namespace Inevitable
{
    public partial class InevitableGUI : Form
    {
        public InevitableGUI()
        {
            InitializeComponent();
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if user presses enter
            if (e.KeyChar == (char)13)
            {
                //print it to screen
                Output(">" + txtInput.Text);

                WordProcessor.ProcessTerm(txtInput.Text);
                //clear it
                txtInput.Clear();

                e.Handled = true;
            }
        }

        public static void Output(string text)
        {
            Program.mainForm.txtOutput.AppendText("\r\n" + text);
            WordProcessor.WriteToFile(text); //keep it forever :)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WordProcessor.Init();
            PopulateListBox();
            txtInput.Focus();
            
        }
        /// <summary>
        /// Populates the list box with known phrases
        /// </summary>
        private void PopulateListBox()
        {
            lbKnownCommands.Items.Add("About");
            lbKnownCommands.Items.Add("Examine X");
            lbKnownCommands.Items.Add("Exit");
            lbKnownCommands.Items.Add("Go X");
            lbKnownCommands.Items.Add("Help");
            lbKnownCommands.Items.Add("Inventory");
            lbKnownCommands.Items.Add("Look");
            lbKnownCommands.Items.Add("Load X");
            lbKnownCommands.Items.Add("Open X");
            lbKnownCommands.Items.Add("Start");
            lbKnownCommands.Items.Add("Take X");
            lbKnownCommands.Items.Add("Use X");
            lbKnownCommands.Items.Add("Use X with Y");
            

        }

        private void btnDummy_Click(object sender, EventArgs e)
        {
            //This is a dummy process to stop it beeping every single time you hit enter
        }
    }
}
