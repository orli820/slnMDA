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

namespace prjMDA.電影
{
    public partial class 電影圖片 : Form
    {
        public 電影圖片()
        {
            InitializeComponent();
        }
        電影圖片總表MovieImages 電影圖片總表MovieImages = new 電影圖片總表MovieImages();
        電影圖片MovieIImagesList 電影圖片ImagesList = new 電影圖片MovieIImagesList();
        ImageToBinary image = new ImageToBinary();
        MDAEntities1 dbContext = new MDAEntities1();
        
        bool Insertflag = false;
        bool Uppdateflag = false;
        void Read_RefreshDataGridView()
        {
            lab配對電影編號.Text = "沒圖片的電影";
            lab配對圖片.Text = "孤單的圖片";
            Insertflag = false;
            Uppdateflag = false;
            var q = from p in dbContext.電影圖片總表MovieImages
                    orderby p.圖片編號Image_ID
                    select new
                    {
                        圖片ID = p.圖片編號Image_ID,
                        圖片 = p.圖片Image,
                    };
            var q1 = from p in dbContext.電影圖片總表MovieImages
                     from r in dbContext.電影圖片MovieIImagesList
                     select new
                     {
                         圖片ID = r.圖片編號Image_ID,
                         圖片 = p.圖片Image,
                     };
            var q2 = from p in dbContext.電影圖片MovieIImagesList
                     select new
                     {
                         電影編號 = p.電影編號Movie_ID,
                         中文標題 = p.電影Movies.中文標題Title_Cht,
                     };
            var q3 = dbContext.電影Movies.Select(p => new { 電影編號 = p.電影編號Movie_ID, 中文標題 = p.中文標題Title_Cht }).Except(q2);
            //所有的電影(電影編號) - q2包含有圖片的電影(電影編號) = 目前還沒收入圖片的電影(電影編號)
            var q4 = from p in dbContext.電影圖片總表MovieImages
                     from r in dbContext.電影圖片MovieIImagesList
                     from s in dbContext.電影Movies
                     orderby r.電影編號Movie_ID
                     where r.電影編號Movie_ID == s.電影編號Movie_ID && r.電影編號Movie_ID==s.電影編號Movie_ID&&r.圖片編號Image_ID==p.圖片編號Image_ID
                     select new
                     {
                         電影圖片編號ID = r.電影圖片編號MI_ID,
                         電影編號 = r.電影編號Movie_ID,
                         中文標題 = s.中文標題Title_Cht,
                         圖片ID = r.圖片編號Image_ID,
                         圖片 = p.圖片Image,
                     };
            //var q4 = from r in dbContext.電影圖片MovieIImagesList
            //         select r;

            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = q.Except(q1).OrderBy(p => p.圖片ID).ToList();
            this.dataGridView3.DataSource = q3.ToList();
            this.dataGridView4.DataSource = q4.ToList();

            lab圖片圖表總數.Text = $"筆數 : {q.Count()}";
            lab未分配圖片筆數.Text = $"筆數 : {q.Except(q1).Count()}";
            lab未分配圖片電影筆數 .Text= $"筆數 : {q3.Count()}";
            lab加入圖片電影筆數.Text = $"筆數 : {q4.Count()}";
            setGridStyle();
        }
        private void setGridStyle()
        {
            if (dataGridView2.DataSource != null)
            {
                dataGridView2.RowHeadersWidth = 4;
                //dataGridView2.Columns[0].Width = 65;
                //dataGridView2.Columns[1].Width = 80;
            }
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.RowHeadersWidth = 4;
                //dataGridView1.Columns[0].Width = 65;
                //dataGridView1.Columns[1].Width = 50;
            }
            if (dataGridView3.DataSource != null)
            {
                dataGridView3.RowHeadersWidth = 4;
                //dataGridView3.Columns[0].Width = 80;
                //dataGridView3.Columns[1].Width = 140;
            }
            if (dataGridView4.DataSource != null)
            {
                dataGridView4.RowHeadersWidth = 4;
                dataGridView4.Columns[0].Width = 120;
                dataGridView4.Columns[1].Width = 80;
                dataGridView4.Columns[2].Width = 200;
                dataGridView4.Columns[3].Width = 80;
                dataGridView4.Columns[4].Width = 120;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Read_RefreshDataGridView();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x= Convert.ToInt32(dataGridView1.CurrentRow.Cells["圖片ID"].Value);
            byte[] ByteData = (byte[])dataGridView1.CurrentRow.Cells["圖片"].Value;
            lab.Text = $"點選圖片ID: {x}";
            txt圖片編號.Text = x.ToString();
            MemoryStream ms = new MemoryStream(ByteData);
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void btn新增圖片_Click(object sender, EventArgs e)
        {
            lab.Text = "狀態";
            txt圖片編號.Text = "";
            if (Insertflag == false) 
            {
                pictureBox1.Image = null;
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = "*.png;*.jpg;*.gif";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                }
                Insertflag = true;
            }
            else
            {
                電影圖片總表MovieImages.圖片Image = image.ConvertToByte(this.pictureBox1.Image);
                this.dbContext.電影圖片總表MovieImages.Add(電影圖片總表MovieImages);
                this.dbContext.SaveChanges();
                pictureBox1.Image = null;
                int x = this.dbContext.電影圖片總表MovieImages.Count();
                lab.Text = $"新增 第{x}筆 成功";
                this.Read_RefreshDataGridView();
            }

        }

        private void btn修改圖片_Click(object sender, EventArgs e)
        {
            if (txt圖片編號.Text == "")
            { return; }
            lab.Text = "狀態";
            var q = (from p in this.dbContext.電影圖片總表MovieImages.AsEnumerable()
                     where p.圖片編號Image_ID == Convert.ToInt32(txt圖片編號.Text)
                     select p).FirstOrDefault();
            if (q == null)
                return;
            int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells["圖片ID"].Value);
            if (Uppdateflag == false)
            {
                pictureBox1.Image = null;
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = "*.png;*.jpg;*.gif";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(open.FileName);
                }
                Uppdateflag = true;
            }
            else
            {
                q.圖片Image = image.ConvertToByte(pictureBox1.Image);
                this.dbContext.SaveChanges();
                pictureBox1.Image = null;
                lab.Text = $"圖片ID:{x} 修改成功";
                Read_RefreshDataGridView();
            }

        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x = Convert.ToInt32(dataGridView2.CurrentRow.Cells["圖片ID"].Value);
            byte[] ByteData = (byte[])dataGridView2.CurrentRow.Cells["圖片"].Value;
            lab.Text = $"點選圖片ID: {x}";
            lab配對圖片.Text=$"配對圖片ID: {x}";
            txt圖片編號.Text = x.ToString();
            MemoryStream ms = new MemoryStream(ByteData);
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close();
        }


        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            int x = Convert.ToInt32(this.dataGridView3.CurrentRow.Cells["電影編號"].Value);
            lab電影中文名稱.Text = this.dataGridView3.CurrentRow.Cells["中文標題"].Value.ToString();
            lab配對電影編號.Text = $"配對電影編號: {x}";
            txt電影編號.Text = x.ToString();
        }

        private void dataGridView4_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Insertflag) { return; };
            if (Uppdateflag) { return; };
            int x = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells["電影編號"].Value);
            byte[] ByteData = (byte[])dataGridView4.CurrentRow.Cells["圖片"].Value;
            lab.Text = $"點選圖片ID: {x}";
            txt圖片編號.Text = this.dataGridView4.CurrentRow.Cells["圖片ID"].Value.ToString();
            MemoryStream ms = new MemoryStream(ByteData);
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close();

            var q = from p in this.dbContext.電影圖片MovieIImagesList
                    where p.電影編號Movie_ID == x
                    select new
                    {
                        p.圖片編號Image_ID,
                        p.電影圖片總表MovieImages.圖片Image
                    };

            string s = this.dataGridView4.CurrentRow.Cells["中文標題"].Value.ToString();
            var list = q.ToList();
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                UserControl1 us = new UserControl1();
                us.Desc = "編號：" + list[i].圖片編號Image_ID.ToString();
                us.Bytes = list[i].圖片Image;
                this.flowLayoutPanel1.Controls.Add(us);
                Application.DoEvents();
            }
            lab電影圖片.Text = $"電影編號{x} ( {s} ) 目前有 {list.Count} 張圖片";
        }

        private void btn圖片配對電影_Click(object sender, EventArgs e)
        {
            if (txt圖片編號.Text == "" || txt電影編號.Text == "")
            { return; }

            var q = dbContext.電影圖片MovieIImagesList.AsEnumerable().Where(p => p.圖片編號Image_ID == Convert.ToInt32(txt圖片編號.Text)).Select(p=>p.電影編號Movie_ID).Any();
            if (q)
            { 
                MessageBox.Show($"配對失敗\n電影編號 :{txt電影編號.Text} 已有 圖片編號 :{txt圖片編號.Text} 的圖片"); 
                return; 
            }

            電影圖片ImagesList.圖片編號Image_ID = Convert.ToInt32(txt圖片編號.Text);
            電影圖片ImagesList.電影編號Movie_ID = Convert.ToInt32(txt電影編號.Text);
            this.dbContext.電影圖片MovieIImagesList.Add(電影圖片ImagesList);
            this.dbContext.SaveChanges();
            lab配對內容.Text = $"配對成功 圖片編號 :{txt圖片編號.Text} 加入 電影編號 :{txt電影編號.Text}";
            lab配對圖片.Text = "尚未分配圖片";
            lab配對電影編號.Text = "尚未分配圖片的電影";

            Read_RefreshDataGridView();
        }

        private void btn搜尋_Click(object sender, EventArgs e)
        {
            if (txt搜尋.Text == "")
            { return; }
            var q = from p in dbContext.電影圖片總表MovieImages.AsEnumerable()
                    where p.圖片編號Image_ID == Convert.ToInt32(txt搜尋.Text)
                    select new
                    {
                        圖片ID = p.圖片編號Image_ID,
                        圖片 = p.圖片Image,
                    };

            this.dataGridView1.DataSource = q.ToList();

            var q4 = from p in dbContext.電影圖片總表MovieImages.AsEnumerable()
                     from r in dbContext.電影圖片MovieIImagesList
                     from s in dbContext.電影Movies
                     where p.圖片編號Image_ID == Convert.ToInt32(txt搜尋.Text) && p.圖片編號Image_ID == r.圖片編號Image_ID && r.電影編號Movie_ID == s.電影編號Movie_ID
                     select new 
                     {
                         電影圖片編號ID = r.電影圖片編號MI_ID,
                         電影編號 = r.電影編號Movie_ID,
                         中文標題 = s.中文標題Title_Cht,
                         圖片ID = r.圖片編號Image_ID,
                         圖片 = p.圖片Image,
                     };
            this.dataGridView4.DataSource = q4.ToList();
            setGridStyle();
        }

    }
}
