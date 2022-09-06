
namespace prjMDA
{
    partial class MovieLanguage
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
            this.btnLanguageAdd = new System.Windows.Forms.Button();
            this.btnLanguageUpDate = new System.Windows.Forms.Button();
            this.dataGridViewMovieLanguage = new System.Windows.Forms.DataGridView();
            this.labChage = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnviewLanguage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieLanguage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLanguageAdd
            // 
            this.btnLanguageAdd.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLanguageAdd.Location = new System.Drawing.Point(81, 118);
            this.btnLanguageAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnLanguageAdd.Name = "btnLanguageAdd";
            this.btnLanguageAdd.Size = new System.Drawing.Size(100, 50);
            this.btnLanguageAdd.TabIndex = 28;
            this.btnLanguageAdd.Text = "新增";
            this.btnLanguageAdd.UseVisualStyleBackColor = true;
            this.btnLanguageAdd.Click += new System.EventHandler(this.btnLanguageAdd_Click);
            // 
            // btnLanguageUpDate
            // 
            this.btnLanguageUpDate.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLanguageUpDate.Location = new System.Drawing.Point(81, 203);
            this.btnLanguageUpDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnLanguageUpDate.Name = "btnLanguageUpDate";
            this.btnLanguageUpDate.Size = new System.Drawing.Size(100, 50);
            this.btnLanguageUpDate.TabIndex = 29;
            this.btnLanguageUpDate.Text = "修改";
            this.btnLanguageUpDate.UseVisualStyleBackColor = true;
            this.btnLanguageUpDate.Click += new System.EventHandler(this.btnLanguageUpDate_Click);
            // 
            // dataGridViewMovieLanguage
            // 
            this.dataGridViewMovieLanguage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovieLanguage.Location = new System.Drawing.Point(956, 12);
            this.dataGridViewMovieLanguage.Name = "dataGridViewMovieLanguage";
            this.dataGridViewMovieLanguage.RowHeadersWidth = 51;
            this.dataGridViewMovieLanguage.RowTemplate.Height = 27;
            this.dataGridViewMovieLanguage.Size = new System.Drawing.Size(437, 818);
            this.dataGridViewMovieLanguage.TabIndex = 30;
            this.dataGridViewMovieLanguage.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMovieLanguage_CellMouseUp);
            // 
            // labChage
            // 
            this.labChage.AutoSize = true;
            this.labChage.BackColor = System.Drawing.Color.Red;
            this.labChage.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labChage.ForeColor = System.Drawing.Color.Yellow;
            this.labChage.Location = new System.Drawing.Point(394, 73);
            this.labChage.Name = "labChage";
            this.labChage.Size = new System.Drawing.Size(77, 38);
            this.labChage.TabIndex = 55;
            this.labChage.Text = "狀態";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLanguage.Location = new System.Drawing.Point(640, 181);
            this.txtLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(241, 34);
            this.txtLanguage.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(365, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 25);
            this.label6.TabIndex = 53;
            this.label6.Text = "語言名稱Language_Name";
            // 
            // btnviewLanguage
            // 
            this.btnviewLanguage.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnviewLanguage.Location = new System.Drawing.Point(90, 389);
            this.btnviewLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.btnviewLanguage.Name = "btnviewLanguage";
            this.btnviewLanguage.Size = new System.Drawing.Size(74, 43);
            this.btnviewLanguage.TabIndex = 56;
            this.btnviewLanguage.Text = "檢視";
            this.btnviewLanguage.UseVisualStyleBackColor = true;
            this.btnviewLanguage.Click += new System.EventHandler(this.btnviewLanguage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(48, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 50);
            this.label2.TabIndex = 57;
            this.label2.Text = "電影語言";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnviewLanguage);
            this.panel1.Controls.Add(this.btnLanguageAdd);
            this.panel1.Controls.Add(this.btnLanguageUpDate);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 713);
            this.panel1.TabIndex = 58;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(640, 139);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 34);
            this.textBox1.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(365, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "語言編號Language_ID";
            // 
            // MovieLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 894);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labChage);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewMovieLanguage);
            this.Name = "MovieLanguage";
            this.Text = "Language";
            this.Click += new System.EventHandler(this.MovieLanguage_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieLanguage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLanguageAdd;
        private System.Windows.Forms.Button btnLanguageUpDate;
        private System.Windows.Forms.DataGridView dataGridViewMovieLanguage;
        private System.Windows.Forms.Label labChage;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnviewLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}