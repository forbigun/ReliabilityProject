using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InputBox : Form
    {
        private System.Windows.Forms.Button btOk;
        private Button Cancel_Button;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label lbText;
        public InputBox()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.btOk = new System.Windows.Forms.Button();
            this.Cancel_Button = new Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.lbText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(45, 60);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(90, 30);
            this.btOk.BackColor = Color.DarkSeaGreen;
            this.btOk.ForeColor = Color.White;
            this.btOk.Font = new Font("Tahoma", 12f,FontStyle.Regular);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "OK";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // CancelButton
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(200, 60);
            this.Cancel_Button.Name = "CancelButton";
            this.Cancel_Button.Size = new System.Drawing.Size(90, 30);
            this.Cancel_Button.TabIndex = 0;
            this.Cancel_Button.ForeColor = Color.White;
            this.Cancel_Button.Font = new Font("Tahoma", 12f, FontStyle.Regular);
            this.Cancel_Button.Text = "Отмена";
            this.Cancel_Button.BackColor = Color.IndianRed;
            this.Cancel_Button.Click += (s, e) => { DialogResult = DialogResult.Cancel; };
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(12, 25);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(306, 20);
            this.tbText.TabIndex = 0;
            this.tbText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbText_KeyDown);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(12, 9);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(35, 13);
            this.lbText.TabIndex = 2;
            this.lbText.Text = "label1";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 97);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.Cancel_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            if (e.KeyCode == Keys.Escape)
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public static string ShowDialog(string label, string caption = null, string warning = null)
        {
            var form = new InputBox();
            form.Text = caption ?? label;
            form.lbText.Text = label;
            var res = form.ShowDialog();
            if (res != DialogResult.OK) return null;
            while (string.IsNullOrWhiteSpace(form.tbText.Text) && res == DialogResult.OK)
            {
                MessageBox.Show(warning, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res = form.ShowDialog();
            }
            if (res != DialogResult.Cancel) return form.tbText.Text;
            else return null;
        }
    }
}
