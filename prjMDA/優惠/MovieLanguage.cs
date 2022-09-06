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
    public partial class MovieLanguage : Form
    {
        電影語言MovieLanguage 電影語言MovieLanguage = new 電影語言MovieLanguage();
        電影代碼MovieCode 電影代碼MovieCode = new 電影代碼MovieCode();
        MDAEntities1 db = new MDAEntities1();

        public MovieLanguage()
        {
            InitializeComponent();

           
        }

        private void btnLanguageAdd_Click(object sender, EventArgs e)
        {
            if (txtLanguage.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
                
            var q = (from p in this.db.電影語言MovieLanguage
                     where p.語言名稱Language_Name == txtLanguage.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("語言重複");
                return;
            }
            電影語言MovieLanguage.語言名稱Language_Name = txtLanguage.Text;
            this.db.電影語言MovieLanguage.Add(電影語言MovieLanguage);
            this.db.SaveChanges();
            labChage.Text = "新增成功";
            dataLanguage();
        }
        void dataLanguage()
        {
            var p = from r in db.電影語言MovieLanguage
                    select new { r.語言編號Language_ID, r.語言名稱Language_Name };
            var list = p.ToList();
            this.dataGridViewMovieLanguage.DataSource = list;
        }

        private void btnLanguageUpDate_Click(object sender, EventArgs e)
        {
            if (txtLanguage.Text == ""||textBox1.Text=="")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
           
            var q2 = (from p in this.db.電影語言MovieLanguage
                     where p.語言名稱Language_Name == txtLanguage.Text
                     select p).Any();
            if (q2)
            {
                MessageBox.Show("語言重複");
                return;
            }
            var q = (from p in this.db.電影語言MovieLanguage.AsEnumerable()
                     where p.語言編號Language_ID == int.Parse(dataGridViewMovieLanguage.CurrentRow.Cells["語言編號Language_ID"].Value.ToString())
                     select p).FirstOrDefault();
            q.語言名稱Language_Name = txtLanguage.Text;
            this.db.SaveChanges();
            dataLanguage();
            labChage.Text = "修改成功";
        }

        private void btnviewLanguage_Click(object sender, EventArgs e)
        {
            dataLanguage();
        }

        private void dataGridViewMovieLanguage_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridViewMovieLanguage.CurrentRow.Cells["語言編號Language_ID"].Value.ToString();
            txtLanguage.Text = dataGridViewMovieLanguage.CurrentRow.Cells["語言名稱Language_Name"].Value.ToString();
        }

        private void MovieLanguage_Click(object sender, EventArgs e)
        {
            txtLanguage.Text = "";
            textBox1.Text = "";
        }
    }   
}
