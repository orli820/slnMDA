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
    public partial class 導演 : Form
    {
        public 導演()
        {
            InitializeComponent();
        }
        MDAEntities1 dbContext = new MDAEntities1();
        ImageToBinary image = new ImageToBinary();
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var q = from p in dbContext.導演總表Director
                    select p;
            var q1 = from p in dbContext.電影導演MovieDirector
                     select p;

            this.dataGridView1.DataSource= q.ToList();
            this.dataGridView2.DataSource = q1.ToList();
            setGridStyle();

        }
        void Read_RefreshDataGridView()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.導演總表Director.ToList();
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = this.dbContext.電影導演MovieDirector.ToList();
            setGridStyle();
        }
        private void setGridStyle()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 25;
            }
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 70;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Height = 25;
            }
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[3].Width = 70;

        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt中文名字.Text = dataGridView1.CurrentRow.Cells["中文名字Name_Cht"].Value.ToString();
            txt英文名字.Text = dataGridView1.CurrentRow.Cells["英文名字Name_Eng"].Value.ToString();
            txt導演編號.Text = dataGridView1.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
            int x = int.Parse(txt導演編號.Text);

            try
            {

                txt電影導演編號.Text = "";
                txt電影編號.Text = "";
                txt導演編號Mv.Text = dataGridView1.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
                byte[] ByteData = (byte[])dataGridView1.Rows[x - 1].Cells["導演照片Image"].Value;
                MemoryStream memoryStream = new MemoryStream(ByteData);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (txt導演編號.Text == "")
            { return; }
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
                    //pictureBox1.Width = Image.FromFile(open.FileName).Width;
                    //pictureBox1.Height = Image.FromFile(open.FileName).Height;
                    pictureBox1.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txt中文名字.Text == "" || txt英文名字.Text == "")
                return;

            var q = (from p in this.dbContext.導演總表Director.AsEnumerable()
                     where p.中文名字Name_Cht == txt中文名字.Text || p.英文名字Name_Eng == txt英文名字.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("導演名字重複");
                return;
            }
            導演總表Director 導演總表 = new 導演總表Director();
            導演總表.中文名字Name_Cht = txt中文名字.Text;
            導演總表.英文名字Name_Eng = txt英文名字.Text;
            導演總表.導演照片Image = image.ConvertToByte(pictureBox1.Image);

            var q1 = from p in this.dbContext.導演總表Director
                     group p by p.導演編號Director_ID into g
                     select new { Count = g.Count() };

            this.dbContext.導演總表Director.Add(導演總表);
            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();
            txt中文名字.Text = "";
            txt英文名字.Text = "";
            //MessageBox.Show($"導演 第{q1.Count()}筆 新增成功\n中文名字: { txt中文名字.Text} \n英文名字: {txt英文名字.Text}");
        }



        private void btnUppdate_Click(object sender, EventArgs e)
        {
            if(txt導演編號.Text=="")
            { return; }
            var q = (from p in this.dbContext.導演總表Director.AsEnumerable()
                     where p.導演編號Director_ID == int.Parse(txt導演編號.Text)
                     select p).FirstOrDefault();
            if (q == null)
                return;
            if (q.導演照片Image != null)
            {
                q.導演照片Image = null;
                this.dbContext.SaveChanges();
            }
           
            q.中文名字Name_Cht = txt中文名字.Text;
            q.英文名字Name_Eng = txt英文名字.Text;
            q.導演照片Image = image.ConvertToByte(pictureBox1.Image);

            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();

            MessageBox.Show($"導演 第{int.Parse(txt導演編號.Text)}筆 修改成功\n中文名字: { txt中文名字.Text} \n英文名字: {txt英文名字.Text}");

        }


        private void cboOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrder.SelectedItem.ToString() == "圖片空缺") 
            {
                var q = from p in this.dbContext.導演總表Director.AsEnumerable()
                        where p.導演照片Image == null
                        select p;
                this.dataGridView1.DataSource = q.ToList();

                setGridStyle();
            }

        }

        private void btnInsertMv_Click(object sender, EventArgs e)
        {
            if (txt電影編號.Text == "")
            { return; }
            電影導演MovieDirector 電影導演 = new 電影導演MovieDirector();
            //電影導演.電影導演編號MD_ID = int.Parse(txt電影導演編號.Text);
            電影導演.電影編號Movie_ID = int.Parse(txt電影編號.Text);
            電影導演.導演編號Director_ID = int.Parse(txt導演編號Mv.Text);

            var q1 = from p in this.dbContext.電影導演MovieDirector
                     group p by p.電影導演編號MD_ID into g
                     select new { Count = g.Count() };
            this.dbContext.電影導演MovieDirector.Add(電影導演);
            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();

            MessageBox.Show($"導演編號 第{q1.Count()}筆 新增成功\n電影編號: {txt電影編號.Text} \n導演編號 {txt導演編號Mv.Text}");
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt電影編號.Text = dataGridView2.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txt導演編號Mv.Text = dataGridView2.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
            txt電影導演編號.Text = this.dataGridView2.CurrentRow.Cells["電影導演編號MD_ID"].Value.ToString();
            int x = int.Parse(txt電影導演編號.Text);

            try
            {
                txt中文名字.Text = this.dataGridView1.Rows[x].Cells["中文名字Name_Cht"].Value.ToString();
                txt英文名字.Text = this.dataGridView1.Rows[x].Cells["英文名字Name_Eng"].Value.ToString();
                byte[] ByteData = (byte[])dataGridView1.Rows[x].Cells["導演照片Image"].Value;
                if (dataGridView1.Rows[x].Cells["導演照片Image"].Value == null)
                { pictureBox1.Image = null; };
                MemoryStream memoryStream = new MemoryStream(ByteData);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();
            }
            catch { }
        }

        private void btnUppdateMv_Click(object sender, EventArgs e)
        {
            if (txt導演編號Mv.Text == "")
            { return; }
            var q = (from p in this.dbContext.電影導演MovieDirector.AsEnumerable()
                     where p.電影導演編號MD_ID == int.Parse(txt電影導演編號.Text)
                     select p).FirstOrDefault();
            if (q == null)
                return;


            q.電影編號Movie_ID = int.Parse(txt電影編號.Text);
            q.導演編號Director_ID = int.Parse(txt導演編號Mv.Text);

            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();

            MessageBox.Show($"導演編號 第{txt電影導演編號.Text}筆 修改成功\n電影編號: {txt電影編號.Text} \n導演編號 {txt導演編號Mv.Text}");

        }

        private void btn搜尋_Click(object sender, EventArgs e)
        {
            if (txt搜尋.Text=="")
            { return; }
            var q = from p in dbContext.導演總表Director.AsEnumerable()
                    where p.導演編號Director_ID == Convert.ToInt32(txt搜尋.Text)
                    select p;

            this.dataGridView1.DataSource = q.ToList();

            var q1 = from p in dbContext.電影導演MovieDirector.AsEnumerable()
                     where p.導演編號Director_ID == Convert.ToInt32(txt搜尋.Text)
                     select p;

            this.dataGridView2.DataSource = q1.ToList();
            setGridStyle();
        }

    }
}
