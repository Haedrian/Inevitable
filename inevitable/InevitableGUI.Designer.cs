namespace Inevitable
{
    partial class InevitableGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InevitableGUI));
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lbKnownCommands = new System.Windows.Forms.ListBox();
            this.btnDummy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.Green;
            this.txtOutput.Location = new System.Drawing.Point(4, 13);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(474, 462);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "\"Start Easy\" or \"Start Hard\" to begin";
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.Black;
            this.txtInput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.Color.Green;
            this.txtInput.Location = new System.Drawing.Point(4, 481);
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(474, 22);
            this.txtInput.TabIndex = 1;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInput_KeyPress);
            // 
            // lbKnownCommands
            // 
            this.lbKnownCommands.BackColor = System.Drawing.Color.Black;
            this.lbKnownCommands.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKnownCommands.ForeColor = System.Drawing.Color.White;
            this.lbKnownCommands.FormattingEnabled = true;
            this.lbKnownCommands.ItemHeight = 16;
            this.lbKnownCommands.Location = new System.Drawing.Point(499, 13);
            this.lbKnownCommands.Name = "lbKnownCommands";
            this.lbKnownCommands.Size = new System.Drawing.Size(166, 484);
            this.lbKnownCommands.TabIndex = 2;
            // 
            // btnDummy
            // 
            this.btnDummy.Location = new System.Drawing.Point(483, 54);
            this.btnDummy.Name = "btnDummy";
            this.btnDummy.Size = new System.Drawing.Size(10, 18);
            this.btnDummy.TabIndex = 3;
            this.btnDummy.Text = "Dummy Button";
            this.btnDummy.UseVisualStyleBackColor = true;
            this.btnDummy.Visible = false;
            this.btnDummy.Click += new System.EventHandler(this.btnDummy_Click);
            // 
            // InevitableGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(677, 515);
            this.Controls.Add(this.btnDummy);
            this.Controls.Add(this.lbKnownCommands);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InevitableGUI";
            this.Text = "Inevitable Version 0.3.0 with Llatext Version 2.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ListBox lbKnownCommands;
        private System.Windows.Forms.Button btnDummy;
    }
}

