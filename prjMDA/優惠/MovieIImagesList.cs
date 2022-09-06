using prjMDA;
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
    public partial class MovieIImagesList : Form
    {
        public MovieIImagesList()
        {
            InitializeComponent();
        }

        電影圖片總表MovieImages 電影圖片總表MovieImages = new 電影圖片總表MovieImages();
        電影圖片MovieIImagesList 電影圖片MovieIImagesList = new 電影圖片MovieIImagesList();
        ImageToBinary picTool = new ImageToBinary();
        MDAEntities1 db = new MDAEntities1();
        

        private void button5_Click(object sender, EventArgs e)
        {
            showdataMovieImageList();
            showdataMovie();
            showdataMovieImage();
        }
        void showdataMovieImageList()
        {
            var p = from r in db.電影圖片MovieIImagesList
                    select new { r.電影圖片編號MI_ID,r.電影編號Movie_ID, r.圖片編號Image_ID };
            var list2 = p.ToList();
            this.dataGridViewMovieImageList.DataSource = list2;

        }

        private void dataGridViewMovieImageList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtMovieId.Text = dataGridViewMovieImageList.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txtImageId.Text = dataGridViewMovieImageList.CurrentRow.Cells["圖片編號Image_ID"].Value.ToString();
            txtmoviechi.Text = dataGridViewMovie.Rows[int.Parse(txtMovieId.Text)-1].Cells["中文標題Title_Cht"].Value.ToString();


            byte[] ByteData = (byte[])dataGridViewMovieImage.Rows[int.Parse(txtImageId.Text)-1].Cells["圖片Image"].Value;
            MemoryStream ms = new MemoryStream(ByteData);
            ptbshow.Image = Image.FromStream(ms);
            ms.Close();
        }
                
        void showdataMovie()
        {
            var m = from p in db.電影Movies
                    select new { p.電影編號Movie_ID, p.中文標題Title_Cht,p.英文標題Title_Eng};
            var list1 = m.ToList();
            this.dataGridViewMovie.DataSource = list1;
            dataGridViewMovie.Columns[1].Width = 120;
            dataGridViewMovie.Columns[2].Width = 120;
        }

        private void dataGridViewMovie_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtImageId.Text = "";
            txtMovieId.Text = dataGridViewMovie.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txtmoviechi.Text = dataGridViewMovie.CurrentRow.Cells["中文標題Title_Cht"].Value.ToString();
        }

        void showdataMovieImage()
        {
            var q = from p in db.電影圖片總表MovieImages
                    select new { p.圖片編號Image_ID, p.圖片Image };
            var list = q.ToList();
            this.dataGridViewMovieImage.DataSource = list;           
        }

        private void dataGridViewMovieImage_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
          txtImageId.Text = dataGridViewMovieImage.CurrentRow.Cells["圖片編號Image_ID"].Value.ToString();
            byte[] ByteData = (byte[])dataGridViewMovieImage.CurrentRow.Cells["圖片Image"].Value;
            MemoryStream ms = new MemoryStream(ByteData);
            ptbshow.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtImageId.Text == "" || txtMovieId.Text =="")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            var q1 = (from a in db.電影圖片MovieIImagesList.AsEnumerable() where a.電影編號Movie_ID.ToString() == txtMovieId.Text && a.圖片編號Image_ID.ToString() == txtImageId.Text select a).Any();
            if (q1)
            {
                MessageBox.Show("資料輸入重複");
                return;
            }
            電影圖片MovieIImagesList.電影編號Movie_ID = int.Parse(txtMovieId.Text);
            電影圖片MovieIImagesList.圖片編號Image_ID = int.Parse(txtImageId.Text);
            this.db.電影圖片MovieIImagesList.Add(電影圖片MovieIImagesList);
            this.db.SaveChanges();
            lab.Text = "新增成功";
            showdataMovieImageList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtmoviechi.Text == "" || txtImageId.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            var q1 = (from a in db.電影圖片MovieIImagesList where a.電影編號Movie_ID.ToString() == txtMovieId.Text && a.圖片編號Image_ID.ToString() ==txtImageId.Text select a).Any();
            

            if ( q1)
            {
                MessageBox.Show("資料輸入重複");
                return;
            }
            var q = (from p in this.db.電影圖片MovieIImagesList.AsEnumerable()
                     where p.電影圖片編號MI_ID == int.Parse(dataGridViewMovieImageList.CurrentRow.Cells["電影圖片編號MI_ID"].Value.ToString())
                     select p).FirstOrDefault();


            q.電影編號Movie_ID = int.Parse(txtMovieId.Text);
            q.圖片編號Image_ID = int.Parse(txtImageId.Text);

            this.db.SaveChanges();
            showdataMovieImageList();
            lab.Text = "修改成功";
        }

        private void MovieIImagesList_Click(object sender, EventArgs e)
        {
            txtmoviechi.Text = "";
            txtMovieId.Text = "";
            txtImageId.Text = "";
            ptbshow.Image = null;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtkeyword.Text == "")
            {
                MessageBox.Show("請輸入編號");
                return;
            }

            var q = from p in db.電影圖片MovieIImagesList.AsEnumerable()
                    where p.電影編號Movie_ID.ToString()== txtkeyword.Text
                    select new { p.電影編號Movie_ID, p.圖片編號Image_ID};
            var list = q.ToList();
            this.dataGridViewMovieImageList.DataSource = list;
            txtkeyword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("請輸入關鍵字");
                return;
            }
            var q = from p in db.電影Movies.AsEnumerable()
                    where p.電影編號Movie_ID.ToString() == txtkeyword.Text ||
                    p.中文標題Title_Cht.Contains(textBox1.Text)||
                    p.英文標題Title_Eng.Contains(textBox1.Text)
                    select new { p.電影編號Movie_ID, p.中文標題Title_Cht ,p.英文標題Title_Eng};
            var list = q.ToList();
            this.dataGridViewMovie.DataSource = list;
            dataGridViewMovie.Columns[1].Width = 120;
            dataGridViewMovie.Columns[2].Width = 120;
            textBox1.Text = "";
        }
    }
}
