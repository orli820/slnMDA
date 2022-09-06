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
    public partial class MovieImages : Form
    {
        電影圖片總表MovieImages 電影圖片總表MovieImages = new 電影圖片總表MovieImages();
        ImageToBinary picTool = new ImageToBinary();
        MDAEntities1 db = new MDAEntities1();

        public MovieImages()
        {
            InitializeComponent();
            if (電影圖片總表MovieImages.圖片Image != null)
                ptbshow.Image = picTool.ConvertToImage(電影圖片總表MovieImages.圖片Image);
        }
        
       void openimage()
        {
            labshowpicture.Text = "";
            //PictureBox pic = sender as PictureBox;
            //pic.Image = null;
            ptbshow.Image = null;
            openFileDialog1.FileName = "*.png;*.jpg;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptbshow.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void pictureshow_Click(object sender, EventArgs e)
        {
            openimage();
        }
        bool insertflag = false;
        bool uppdateflag = false;
        private void btnAddImage(object sender, EventArgs e)
        {

            if (insertflag == false)
            { 
                openimage();
                insertflag = true;
                return;
            }
            if (insertflag == true)
            {
                電影圖片總表MovieImages.圖片Image = picTool.ConvertToByte(this.ptbshow.Image);
                this.db.電影圖片總表MovieImages.Add(電影圖片總表MovieImages);
                this.db.SaveChanges();
                ptbshow.Image = null;
                labshowpicture.Text = "新增成功";
                showdataMovieImage();
                insertflag = false;
                return;
            }
            if (ptbshow.Image == null)
            {
                MessageBox.Show("請輸入資料");
                return;
            }


            //if (ptbshow.Image==null)
            //{
            //    openimage();                
            //}
            //else
            //{
            //    電影圖片總表MovieImages.圖片Image = picTool.ConvertToByte(this.ptbshow.Image);
            //    this.db.電影圖片總表MovieImages.Add(電影圖片總表MovieImages);
            //    this.db.SaveChanges();
            //    ptbshow.Image = null;
            //    labshowpicture.Text = "新增成功";
            //    showdataMovieImage();
            //}            
        }

        private void btnUpdateImage(object sender, EventArgs e)
        {
            if (ptbshow.Image == null)
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            if (uppdateflag == false)
            {
                openimage();
                uppdateflag = true;
            }
            else 
            {
                var q = (from p in this.db.電影圖片總表MovieImages.AsEnumerable()
                         where p.圖片編號Image_ID == int.Parse(dataGridViewMovieImage.CurrentRow.Cells["圖片編號Image_ID"].Value.ToString())
                         select p).FirstOrDefault();
                q.圖片Image = picTool.ConvertToByte(this.ptbshow.Image);
                this.db.SaveChanges();
                showdataMovieImage();
                ptbshow.Image = null;
                labshowpicture.Text = "修改成功";
                uppdateflag = false;
            }






            //if (ptbshow.Image == null)
            //{
            //    MessageBox.Show("請輸入資料");
            //    return;
            //}
            //var q = (from p in this.db.電影圖片總表MovieImages.AsEnumerable()
            //         where p.圖片編號Image_ID == int.Parse(dataGridViewMovieImage.CurrentRow.Cells["圖片編號Image_ID"].Value.ToString())
            //         select p).FirstOrDefault();
            //q.圖片Image = picTool.ConvertToByte(this.ptbshow.Image);
            //this.db.SaveChanges();
            //showdataMovieImage();
            //ptbshow.Image = null;
            //labshowpicture.Text = "修改成功";            
        }

        private void btnShowImageData(object sender, EventArgs e)
        {
            showdataMovieImage();
        }

        void showdataMovieImage()
        {
            insertflag = false;
            uppdateflag = false;
            var q = from p in db.電影圖片總表MovieImages
                    select new { p.圖片編號Image_ID, p.圖片Image };
            var list = q.ToList();
            this.dataGridViewMovieImage.DataSource = list;
            this.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                UserControl1 us = new UserControl1();
                us.Desc = "編號：" + list[i].圖片編號Image_ID.ToString();
                us.Bytes = list[i].圖片Image;
                this.flowLayoutPanel1.Controls.Add(us);
                Application.DoEvents();
            }
        }

        private void dataGridViewMovieImage_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            uppdateflag = false;
            insertflag = false;
            showpic();
            label1.Text = "編號：" + dataGridViewMovieImage.CurrentRow.Cells["圖片編號Image_ID"].Value.ToString();
            
        }

      void showpic()
        {
            byte[] ByteData = (byte[])dataGridViewMovieImage.CurrentRow.Cells["圖片Image"].Value;
            MemoryStream ms = new MemoryStream(ByteData);
            ptbshow.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtkeyword.Text == "")
            {
                MessageBox.Show("請輸入圖片編號");
                return; }
            var q = from p in this.db.電影圖片總表MovieImages.AsEnumerable()
                    where int.Parse(txtkeyword.Text) ==p.圖片編號Image_ID
                    select new { p.圖片編號Image_ID, p.圖片Image };
            dataGridViewMovieImage.DataSource = q.ToList();
            showpic();


        }

        private void MovieImages_Click(object sender, EventArgs e)
        {
            insertflag = false;
            uppdateflag = false;
            ptbshow.Image = null;
            label1.Text = "";
        }
    }
       
}
