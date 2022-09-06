using prjMDA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prjMDA
{
    public partial class MovieCode : Form
    {
        public MovieCode()
        {
            InitializeComponent();
        }
        
        電影語言MovieLanguage 電影語言MovieLanguage = new 電影語言MovieLanguage();
        電影代碼MovieCode 電影代碼MovieCode = new 電影代碼MovieCode();
        MDAEntities1 db = new MDAEntities1();

        private void btnViewMovie_Click(object sender, EventArgs e)
        {
            dataLanguage();
            datamovie();
            showMovieCodeData();
        }
        void dataLanguage()
        {
            var p = from r in db.電影語言MovieLanguage
                    select new { r.語言編號Language_ID, r.語言名稱Language_Name };
            var list = p.ToList();
            this.dataGridViewMovieLanguage.DataSource = list;
        }
        void datamovie()
        {
            var p = from r in db.電影Movies
                    select new { r.電影編號Movie_ID, r.中文標題Title_Cht };
            var list2 = p.ToList();
            this.dataGridmMovie.DataSource = list2;
            dataGridmMovie.Columns[1].Width = 150;
        }
        void showMovieCodeData()
        {
            var p = from r in db.電影代碼MovieCode
                    select new {  r.電影編號Movie_ID, r.電影Movies.中文標題Title_Cht, r.語言編號Language_ID,r.電影語言MovieLanguage.語言名稱Language_Name };
            var list3 = p.ToList();
            this.dataGridmMovieCode.DataSource = list3;
        }

        void nonecode()
        {
            var q = (from m in db.電影Movies
                     where m.電影編號Movie_ID.ToString() == txtMovieId.Text
                     select m).Any();
            var q1 = (from d in db.電影語言MovieLanguage
                      where d.語言編號Language_ID.ToString() == txtLanguageId.Text
                      select d).Any();
            if (!q)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }
            if (!q1)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }

        }
        private void btnAddId_Click(object sender, EventArgs e)
        {
            if (txtMovieId.Text == "" || txtLanguageId.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
                
            var q = (from p in db.電影代碼MovieCode
                     where p.電影編號Movie_ID.ToString() == txtMovieId.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("電影編號重複");
                return;
            }
            var q2 = (from m in db.電影Movies
                     where m.電影編號Movie_ID.ToString() == txtMovieId.Text
                     select m).Any();
            var q1 = (from d in db.電影語言MovieLanguage
                      where d.語言編號Language_ID.ToString() == txtLanguageId.Text
                      select d).Any();
            if (!q2)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }
            if (!q1)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }
            電影代碼MovieCode.電影編號Movie_ID = int.Parse(txtMovieId.Text);
            電影代碼MovieCode.語言編號Language_ID = int.Parse(txtLanguageId.Text);
            this.db.電影代碼MovieCode.Add(電影代碼MovieCode);
            this.db.SaveChanges();
            labMovieCode.Text = "新增成功";
            showMovieCodeData();
        }

        private void btnUpdateId_Click(object sender, EventArgs e)
        {
            if (txtMovieId.Text == "" || txtLanguageId.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            var q2 = (from m in db.電影Movies
                     where m.電影編號Movie_ID.ToString() == txtMovieId.Text
                     select m).Any();
            var q1 = (from d in db.電影語言MovieLanguage
                      where d.語言編號Language_ID.ToString() == txtLanguageId.Text
                      select d).Any();
            if (!q2)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }
            if (!q1)
            {
                MessageBox.Show("請輸入正確資料");
                return;
            }
            var q = (from p in this.db.電影代碼MovieCode.AsEnumerable()
                     where p.電影編號Movie_ID == int.Parse(dataGridmMovieCode.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString())
                     select p).FirstOrDefault();
            q.電影編號Movie_ID = int.Parse(txtMovieId.Text);
            q.語言編號Language_ID = int.Parse(txtLanguageId.Text);
            this.db.SaveChanges();
            showMovieCodeData();
            labMovieCode.Text = "修改成功";
        }

        private void dataGridmMovie_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtLanguageId.Text = "";
            txtMovieId.Text = dataGridmMovie.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txtmoviechi.Text = dataGridmMovie.CurrentRow.Cells["中文標題Title_Cht"].Value.ToString();
        }

        private void dataGridViewMovieLanguage_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtLanguageId.Text = dataGridViewMovieLanguage.CurrentRow.Cells["語言編號Language_ID"].Value.ToString();
        }

        private void dataGridmMovieCode_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMovieId.Text = dataGridmMovieCode.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txtLanguageId.Text = dataGridmMovieCode.CurrentRow.Cells["語言編號Language_ID"].Value.ToString();
            txtmoviechi.Text = dataGridmMovie.Rows[int.Parse(txtMovieId.Text) - 1].Cells["中文標題Title_Cht"].Value.ToString();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtkeyword.Text == "")
            {
                MessageBox.Show("請輸入語言中文");
                return; 
            }
            
            var q = from p in this.db.電影語言MovieLanguage.AsEnumerable()
                    where p.語言名稱Language_Name.Contains(txtkeyword.Text)
                    select new { p.語言編號Language_ID, p.語言名稱Language_Name };
            var list = q.ToList();
            this.dataGridViewMovieLanguage.DataSource = list;
            txtkeyword.Text = "";
        }

        private void MovieCode_Click(object sender, EventArgs e)
        {
            txtmoviechi.Text = "";
            txtMovieId.Text = "";
            txtLanguageId.Text = "";
        }
    }
}
