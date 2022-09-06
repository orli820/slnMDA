
namespace prjMDA
{
    partial class MDAControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labMovie = new System.Windows.Forms.Label();
            this.labEng = new System.Windows.Forms.Label();
            this.labCH = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labMovie
            // 
            this.labMovie.AutoSize = true;
            this.labMovie.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labMovie.Location = new System.Drawing.Point(176, 21);
            this.labMovie.Name = "labMovie";
            this.labMovie.Size = new System.Drawing.Size(61, 20);
            this.labMovie.TabIndex = 7;
            this.labMovie.Text = "labMovie";
            this.labMovie.UseCompatibleTextRendering = true;
            // 
            // labEng
            // 
            this.labEng.AutoSize = true;
            this.labEng.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labEng.Location = new System.Drawing.Point(176, 80);
            this.labEng.Name = "labEng";
            this.labEng.Size = new System.Drawing.Size(47, 20);
            this.labEng.TabIndex = 6;
            this.labEng.Text = "labEng";
            this.labEng.UseCompatibleTextRendering = true;
            // 
            // labCH
            // 
            this.labCH.AutoSize = true;
            this.labCH.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCH.Location = new System.Drawing.Point(176, 52);
            this.labCH.Name = "labCH";
            this.labCH.Size = new System.Drawing.Size(43, 20);
            this.labCH.TabIndex = 5;
            this.labCH.Text = "labCH";
            this.labCH.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MDAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labMovie);
            this.Controls.Add(this.labEng);
            this.Controls.Add(this.labCH);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MDAControl";
            this.Size = new System.Drawing.Size(317, 197);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMovie;
        private System.Windows.Forms.Label labEng;
        private System.Windows.Forms.Label labCH;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
