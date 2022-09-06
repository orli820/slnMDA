
namespace prjMDA
{
    partial class MovieImages
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbshow = new System.Windows.Forms.PictureBox();
            this.btnADDMOVIE = new System.Windows.Forms.Button();
            this.btnMovieUpDate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewMovieImage = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.labshowpicture = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtkeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbshow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbshow
            // 
            this.ptbshow.BackColor = System.Drawing.Color.White;
            this.ptbshow.Location = new System.Drawing.Point(309, 103);
            this.ptbshow.Margin = new System.Windows.Forms.Padding(4);
            this.ptbshow.Name = "ptbshow";
            this.ptbshow.Size = new System.Drawing.Size(499, 854);
            this.ptbshow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbshow.TabIndex = 2;
            this.ptbshow.TabStop = false;
            this.ptbshow.Click += new System.EventHandler(this.pictureshow_Click);
            // 
            // btnADDMOVIE
            // 
            this.btnADDMOVIE.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnADDMOVIE.Location = new System.Drawing.Point(70, 112);
            this.btnADDMOVIE.Margin = new System.Windows.Forms.Padding(4);
            this.btnADDMOVIE.Name = "btnADDMOVIE";
            this.btnADDMOVIE.Size = new System.Drawing.Size(111, 57);
            this.btnADDMOVIE.TabIndex = 27;
            this.btnADDMOVIE.Text = "新增";
            this.btnADDMOVIE.UseVisualStyleBackColor = true;
            this.btnADDMOVIE.Click += new System.EventHandler(this.btnAddImage);
            // 
            // btnMovieUpDate
            // 
            this.btnMovieUpDate.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMovieUpDate.Location = new System.Drawing.Point(70, 196);
            this.btnMovieUpDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnMovieUpDate.Name = "btnMovieUpDate";
            this.btnMovieUpDate.Size = new System.Drawing.Size(111, 57);
            this.btnMovieUpDate.TabIndex = 28;
            this.btnMovieUpDate.Text = "修改";
            this.btnMovieUpDate.UseVisualStyleBackColor = true;
            this.btnMovieUpDate.Click += new System.EventHandler(this.btnUpdateImage);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridViewMovieImage
            // 
            this.dataGridViewMovieImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovieImage.Location = new System.Drawing.Point(843, 103);
            this.dataGridViewMovieImage.Name = "dataGridViewMovieImage";
            this.dataGridViewMovieImage.RowHeadersWidth = 51;
            this.dataGridViewMovieImage.RowTemplate.Height = 27;
            this.dataGridViewMovieImage.Size = new System.Drawing.Size(380, 854);
            this.dataGridViewMovieImage.TabIndex = 29;
            this.dataGridViewMovieImage.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMovieImage_CellMouseUp);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(39, 315);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 56);
            this.button1.TabIndex = 31;
            this.button1.Text = "檢視圖片庫";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnShowImageData);
            // 
            // labshowpicture
            // 
            this.labshowpicture.AutoSize = true;
            this.labshowpicture.BackColor = System.Drawing.Color.Red;
            this.labshowpicture.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labshowpicture.ForeColor = System.Drawing.Color.Yellow;
            this.labshowpicture.Location = new System.Drawing.Point(323, 39);
            this.labshowpicture.Name = "labshowpicture";
            this.labshowpicture.Size = new System.Drawing.Size(77, 38);
            this.labshowpicture.TabIndex = 32;
            this.labshowpicture.Text = "狀態";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1266, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(621, 854);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(61, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 50);
            this.label2.TabIndex = 35;
            this.label2.Text = "圖片庫";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.txtkeyword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnADDMOVIE);
            this.panel1.Controls.Add(this.btnMovieUpDate);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 1030);
            this.panel1.TabIndex = 36;
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnsearch.Location = new System.Drawing.Point(95, 540);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(74, 43);
            this.btnsearch.TabIndex = 73;
            this.btnsearch.Text = "搜尋";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtkeyword
            // 
            this.txtkeyword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtkeyword.Location = new System.Drawing.Point(74, 498);
            this.txtkeyword.Margin = new System.Windows.Forms.Padding(4);
            this.txtkeyword.Name = "txtkeyword";
            this.txtkeyword.Size = new System.Drawing.Size(127, 34);
            this.txtkeyword.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(445, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "編號：";
            // 
            // MovieImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1026);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewMovieImage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labshowpicture);
            this.Controls.Add(this.ptbshow);
            this.Name = "MovieImages";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.MovieImages_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ptbshow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovieImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbshow;
        private System.Windows.Forms.Button btnADDMOVIE;
        private System.Windows.Forms.Button btnMovieUpDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewMovieImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labshowpicture;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtkeyword;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label1;
    }
}

