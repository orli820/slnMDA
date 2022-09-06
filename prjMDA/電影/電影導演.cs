using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMDA
{
    public partial class 電影導演 : Form
    {
        public 電影導演()
        {
            InitializeComponent();
        }
        MDAEntities dbContext = new MDAEntities();
        ImageToBinary image = new ImageToBinary();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var q = from p in dbContext.導演總表Director
                    select p;

            this.dataGridView1.DataSource= q.ToList();
            setGridStyle();

        }
        private void setGridStyle()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 20;
            }
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 40;

        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt導演編號.Text= dataGridView1.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
            txt中文名字.Text = dataGridView1.CurrentRow.Cells["中文名字Name_Cht"].Value.ToString();
            txt英文名字.Text = dataGridView1.CurrentRow.Cells["英文名字Name_Eng"].Value.ToString();

            try
            {
                byte[] ByteData = (byte[])dataGridView1.CurrentRow.Cells["導演照片Image"].Value;

                if (dataGridView1.CurrentRow.Cells["導演照片Image"].Value == null)
                { pictureBox1.Image = null; };
                MemoryStream memoryStream = new MemoryStream(ByteData);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();

            }
            catch { }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog open = new OpenFileDialog();

            open.InitialDirectory = "c:\\";
            open.Filter = "圖片 files (*.jpeg)|*.txt|All files (*.*)|*.*";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;
                var fileStream = open.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    pictureBox1.Width = Image.FromFile(open.FileName).Width;
                    pictureBox1.Height = Image.FromFile(open.FileName).Height;
                    pictureBox1.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txt中文名字.Text == "" || txt英文名字.Text == "")
                return;

            導演總表Director 導演總表 = new 導演總表Director();
            導演總表.中文名字Name_Cht = txt中文名字.Text;
            導演總表.英文名字Name_Eng = txt英文名字.Text;
            導演總表.導演照片Image = image.ConvertToByte(pictureBox1.Image);

            this.dbContext.導演總表Director.Add(導演總表);
            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();
        }
        void Read_RefreshDataGridView()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.導演總表Director.ToList();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUppdate_Click(object sender, EventArgs e)
        {

        }

    }
}
