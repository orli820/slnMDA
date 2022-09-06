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
    public partial class Director : Form
    {
        public Director()
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
            var q2 = from p in dbContext.電影Movies
                     select new { p.電影編號Movie_ID, p.中文標題Title_Cht, p.英文標題Title_Eng };
            this.dataGridView1.DataSource= q.ToList();
            this.dataGridView2.DataSource = q1.ToList();
            this.dataGridView3.DataSource = q2.ToList();
            setGridStyle();

        }
        void Read_RefreshDataGridView()
        {
            
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

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Height = 25;
            }
            //dataGridView3.Columns[0].Width = 80;
            //dataGridView3.Columns[1].Width = 100;
            //dataGridView3.Columns[2].Width = 120;
            //dataGridView3.Columns[3].Width = 70;

        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {          
            txt導演編號Mv.Text = dataGridView1.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
            
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
            var q = (from p in dbContext.電影導演MovieDirector
                     where p.電影編號Movie_ID.ToString() == txt電影編號.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("電影編號重複");
                return;
            }
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

            //MessageBox.Show($"導演編號 第{q1.Count()}筆 新增成功\n電影編號: {txt電影編號.Text} \n導演編號 {txt導演編號Mv.Text}");
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt電影編號.Text = dataGridView2.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
            txt導演編號Mv.Text = dataGridView2.CurrentRow.Cells["導演編號Director_ID"].Value.ToString();
            txt電影導演編號.Text = this.dataGridView2.CurrentRow.Cells["電影導演編號MD_ID"].Value.ToString();
            int x = int.Parse(txt電影導演編號.Text);           
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

            //MessageBox.Show($"導演編號 第{txt電影導演編號.Text}筆 修改成功\n電影編號: {txt電影編號.Text} \n導演編號 {txt導演編號Mv.Text}");

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

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt電影編號.Text = dataGridView3.CurrentRow.Cells["電影編號Movie_ID"].Value.ToString();
        }

    
    }
}
