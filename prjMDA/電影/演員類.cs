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
    public partial class 演員類 : Form
    {
        public 演員類()
        {
            InitializeComponent();
        }
        MDAEntities1 dbContext = new MDAEntities1();
        ImageToBinary image = new ImageToBinary();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txt中文名字.Text == "" || txt英文名字.Text == "")
                return;
            var q = (from p in this.dbContext.演員總表Actors.AsEnumerable()
                     where p.中文名字Name_Cht == txt中文名字.Text || p.英文名字Name_Eng == txt英文名字.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("演員名字重複");
                return;
            }

            演員總表Actors 演員總表 = new 演員總表Actors();
            演員總表.中文名字Name_Cht = txt中文名字.Text;
            演員總表.英文名字Name_Eng = txt英文名字.Text;
            演員總表.演員照片Image = image.ConvertToByte(pictureBox1.Image);

            var q1 = from p in this.dbContext.演員總表Actors
                     group p by p.演員編號Actors_ID into g
                     select new { Count = g.Count() };

            this.dbContext.演員總表Actors.Add(演員總表);
            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView(); 
            txt中文名字.Text = "";
            txt英文名字.Text = "";
            //MessageBox.Show($"演員 第{q1.Count()}筆 新增成功\n中文名字: { txt中文名字.Text} \n英文名字: {txt英文名字.Text}");
        }
        void Read_RefreshDataGridView()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dbContext.演員總表Actors.ToList();
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = this.dbContext.電影主演Cast.ToList();
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var q = from p in dbContext.演員總表Actors
                    select p;
            var q1 = from p in dbContext.電影主演Cast
                     select p;

            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = q1.ToList();
            Read_RefreshDataGridView();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt中文名字.Text = dataGridView1.CurrentRow.Cells["中文名字Name_Cht"].Value.ToString();
            txt英文名字.Text = dataGridView1.CurrentRow.Cells["英文名字Name_Eng"].Value.ToString();
            txt演員編號.Text = dataGridView1.CurrentRow.Cells["演員編號Actors_ID"].Value.ToString();
            int x = int.Parse(txt演員編號.Text);

            try
            {
                txt演員編號Mv.Text = x.ToString();
                txt主演編號.Text = "";
                txt電影編號.Text = "";
                txt角色名字.Text = "";
                txt角色說明.Text = "";
                byte[] ByteData = (byte[])dataGridView1.Rows[x - 1].Cells["演員照片Image"].Value;
                MemoryStream memoryStream = new MemoryStream(ByteData);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt電影編號.Text = this.dataGridView2.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txt角色名字.Text = this.dataGridView2.CurrentRow.Cells["角色名字Character_Name"].Value.ToString();
            txt演員編號Mv.Text = this.dataGridView2.CurrentRow.Cells["演員編號Actor_ID"].Value.ToString();
            txt主演編號.Text = this.dataGridView2.CurrentRow.Cells["主演編號MA_ID"].Value.ToString();
            txt角色說明.Text= this.dataGridView2.CurrentRow.Cells["角色說明Character_illustrate"].Value.ToString();
            int x = int.Parse(txt演員編號Mv.Text);

            try
            {
                txt中文名字.Text = this.dataGridView1.Rows[x-1].Cells["中文名字Name_Cht"].Value.ToString();
                txt英文名字.Text = this.dataGridView1.Rows[x-1].Cells["英文名字Name_Eng"].Value.ToString();
                txt演員編號.Text = x.ToString();
                byte[] ByteData = (byte[])dataGridView1.Rows[x-1].Cells["演員照片Image"].Value;
                if (dataGridView1.Rows[x-1].Cells["演員照片Image"].Value == null)
                { pictureBox1.Image = null; };
                MemoryStream memoryStream = new MemoryStream(ByteData);
                pictureBox1.Image = Image.FromStream(memoryStream);
                memoryStream.Close();
            }
            catch { }
        }
        private void btnUppdate_Click(object sender, EventArgs e)
        {
            if (txt演員編號.Text == "")
            { return; }
            var q = (from p in this.dbContext.演員總表Actors.AsEnumerable()
                     where p.演員編號Actors_ID == int.Parse(txt演員編號.Text)
                     select p).FirstOrDefault();
            if (q == null)
                return;
            if (q.演員照片Image != null)
            {
                q.演員照片Image = null;
                this.dbContext.SaveChanges();
            }

            q.中文名字Name_Cht = txt中文名字.Text;
            q.英文名字Name_Eng = txt英文名字.Text;
            q.演員照片Image = image.ConvertToByte(pictureBox1.Image);

            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();
            MessageBox.Show($"演員 第{int.Parse(txt演員編號.Text)}筆 修改成功\n中文名字: { txt中文名字.Text} \n英文名字: {txt英文名字.Text}");

        }

        private void btnInsertMv_Click(object sender, EventArgs e)
        {
            if (txt主演編號.Text == "" || txt電影編號.Text == "" || txt演員編號Mv.Text == "" )
                return;

            var q1 = from p in this.dbContext.電影主演Cast
                     group p by p.演員編號Actor_ID into g
                     select new { Count = g.Count() };
            電影主演Cast 電影主演 = new 電影主演Cast();
            電影主演.電影編號Movie_ID = int.Parse(txt電影編號.Text);
            電影主演.演員編號Actor_ID = int.Parse(txt演員編號.Text);
            電影主演.角色名字Character_Name = txt角色名字.Text;
            電影主演.角色說明Character_illustrate = txt角色說明.Text;

            this.dbContext.電影主演Cast.Add(電影主演);
            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();

            MessageBox.Show($"電影主演 第{q1.Count()}筆 新增成功\n電影編號: {txt電影編號.Text} \n演員編號: {txt演員編號.Text}\n角色名字: {txt角色名字.Text}");
        }

        private void cboOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrder.SelectedItem.ToString() == "圖片空缺")
            {
                var q = from p in this.dbContext.演員總表Actors.AsEnumerable()
                        where p.演員照片Image == null
                        select p;
                this.dataGridView1.DataSource = q.ToList();

                Read_RefreshDataGridView();
            }
        }

        private void btnUppdateMv_Click(object sender, EventArgs e)
        {
            var q = (from p in this.dbContext.電影主演Cast.AsEnumerable()
                     where p.演員編號Actor_ID == int.Parse(txt演員編號Mv.Text)
                     select p).FirstOrDefault();
            if (q == null)
                return;

            q.演員編號Actor_ID = int.Parse(txt演員編號.Text);
            q.角色名字Character_Name = txt角色名字.Text;
            q.角色說明Character_illustrate = txt角色說明.Text;

            this.dbContext.SaveChanges();
            this.Read_RefreshDataGridView();

            MessageBox.Show($"電影主演 第{int.Parse(txt演員編號.Text)}筆 修改成功\n演員編號: { txt演員編號.Text}\n角色名字: { txt角色名字.Text}");
        }

        private void btn搜尋_Click(object sender, EventArgs e)
        {
            if (txt搜尋.Text == "")
            { return; }
            var q = from p in dbContext.演員總表Actors.AsEnumerable()
                    where p.演員編號Actors_ID == Convert.ToInt32(txt搜尋.Text)
                    select p;

            this.dataGridView1.DataSource= q.ToList();

            var q1 = from p in dbContext.電影主演Cast.AsEnumerable()
                    where p.演員編號Actor_ID == Convert.ToInt32(txt搜尋.Text)
                    select p;

            this.dataGridView2.DataSource = q1.ToList();
            setGridStyle();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (txt演員編號.Text == "")
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
    }
}
