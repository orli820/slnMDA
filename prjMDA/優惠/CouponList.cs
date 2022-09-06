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
    public partial class CouponList : Form
    {
        public CouponList()
        {
            InitializeComponent();
            var q = from a in db.優惠總表Coupon
                    select a.優惠名稱Coupon_Name;
            comboBox5.DataSource = q.ToList();            

            var q1 = (from a in db.優惠明細CouponLists
                     select a.是否使用優惠OX_CouponUsing).Distinct();
            comboBox3.DataSource = q1.ToList();           

            var q2 = (from a in db.優惠總表Coupon
                     orderby a.優惠截止日期CouponDueDate ascending
                     select a.優惠截止日期CouponDueDate).Distinct();
            comboBox2.DataSource = q2.ToList();
            comboBox1.Text = "false";
        }
        優惠總表Coupon 優惠總表Coupon = new 優惠總表Coupon();
        MDAEntities1 db = new MDAEntities1();
        優惠明細CouponLists 優惠明細CouponLists = new 優惠明細CouponLists();
        會員Members 會員Members = new 會員Members();
       
        void viewcoupon()
        {
            var q = from a in db.優惠總表Coupon.AsEnumerable()
                    select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{a.優惠折扣CouponDiscount.ToString("C0")}", a.優惠截止日期CouponDueDate, a.優惠所需紅利BonusCost };
            dataGridViewCoupon.DataSource = q.ToList();
        }
        void viewmember()
        {
            var q = from a in db.會員Members
                    select new { a.會員編號Member_ID,a.會員電話Cellphone,a.電子信箱Email,a.紅利點數Bonus };
            dataGridViewMember.DataSource = q.ToList();
        }
       

        private void dataGridViewCoupon_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCoupon_ID.Text = dataGridViewCoupon.CurrentRow.Cells["優惠編號Coupon_ID"].Value.ToString();
            comboBox5.Text = dataGridViewCoupon.CurrentRow.Cells["優惠名稱Coupon_Name"].Value.ToString();            
            
        }

        private void dataGridViewMember_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtmemberid.Text = dataGridViewMember.CurrentRow.Cells["會員編號Member_ID"].Value.ToString();
            txtCoupon_ID.Text = "";            
        }

        private void btnLanguageAdd_Click(object sender, EventArgs e)
        {
            if (txtmemberid.Text== "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            優惠明細CouponLists.會員編號Member_ID= int.Parse(txtmemberid.Text);
            優惠明細CouponLists.優惠編號Coupon_ID = int.Parse(txtCoupon_ID.Text);
            string result = comboBox1.Text;
            優惠明細CouponLists.是否使用優惠OX_CouponUsing =Convert.ToBoolean (result);
            this.db.優惠明細CouponLists.Add(優惠明細CouponLists);
            this.db.SaveChanges();
            labChage.Text = "新增成功";
            showviewcplist();
            clearall();

        }

        void showviewcplist()
        {
            var q = db.優惠明細CouponLists.Select(p => new { p.會員編號Member_ID, p.會員Members.會員電話Cellphone, p.會員Members.電子信箱Email, p.優惠編號Coupon_ID, p.優惠總表Coupon.優惠名稱Coupon_Name ,p.是否使用優惠OX_CouponUsing});                
            dataGridViewcplist.DataSource = q.ToList();
        }

        void clearall()
        {
            txtmemberid.Text = "";
            txtCoupon_ID.Text = "";
            comboBox1.Text = "";
        }

        void clearsearch()
        {
            txtsearchmember.Text = "";
            txtsearchcoupon.Text = "";
            comboBox2.Text = "";
            txtseachcouponlist.Text = "";
            comboBox3.Text = "";
        }

        private void btnLanguageUpDate_Click(object sender, EventArgs e)
        {
            if (txtmemberid.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            var q = (from a in db.優惠明細CouponLists.AsEnumerable()
                     where a.會員編號Member_ID == int.Parse(dataGridViewcplist.CurrentRow.Cells["會員編號Member_ID"].Value.ToString())
                     select a).FirstOrDefault();
            q.會員編號Member_ID = int.Parse(txtmemberid.Text);
            q.優惠編號Coupon_ID = int.Parse(txtCoupon_ID.Text);
            q.是否使用優惠OX_CouponUsing = Convert.ToBoolean(comboBox1.Text.ToString());
            this.db.SaveChanges();
            labChage.Text = "修改成功";
            showviewcplist();
            clearall();

        }

        private void dataGridViewcplist_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtmemberid.Text = dataGridViewcplist.CurrentRow.Cells["會員編號Member_ID"].Value.ToString();
            txtCoupon_ID.Text = dataGridViewcplist.CurrentRow.Cells["優惠編號Coupon_ID"].Value.ToString();
            comboBox1.Text = dataGridViewcplist.CurrentRow.Cells["是否使用優惠OX_CouponUsing"].Value.ToString();            
        }

        private void btnviewBonus_Click_1(object sender, EventArgs e)
        {
            showviewcplist();
            viewcoupon();
            viewmember();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtseachcouponlist.Text == "")
            {
                MessageBox.Show("請輸入關鍵字");
                return;
            }
            if (txtseachcouponlist.Text != "")
            {
                var q = from a in db.優惠明細CouponLists
                        where a.會員編號Member_ID.ToString()==txtseachcouponlist.Text    
                        select new { a.會員編號Member_ID, a.優惠編號Coupon_ID, a.是否使用優惠OX_CouponUsing };
                dataGridViewcplist.DataSource = q.ToList();
            }
            clearsearch();
        }

               
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCoupon_ID.Text = (comboBox5.SelectedIndex + 1).ToString();
        }

        private void CouponList_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtsearchmember.Text == "")
            {
                MessageBox.Show("請輸入會員編號或會員電話或會員電子信箱");
                return;
            }
            if (txtsearchmember.Text != "")
            {
                var q = from a in db.會員Members.AsEnumerable()
                        where ((a.會員編號Member_ID.ToString())==txtsearchmember.Text)
                        || (a.會員電話Cellphone.Contains(txtsearchmember.Text))
                        || ((a.電子信箱Email).Contains(txtsearchmember.Text))
                        || ((a.紅利點數Bonus.ToString()).Contains(txtsearchmember.Text))
                        select new { a.會員編號Member_ID, a.會員電話Cellphone, a.電子信箱Email, a.紅利點數Bonus };
                dataGridViewMember.DataSource = q.ToList();
            }
            clearsearch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                var q = from a in db.優惠總表Coupon.AsEnumerable()
                        where a.優惠截止日期CouponDueDate <= Convert.ToDateTime(comboBox2.Text)
                        select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{ a.優惠折扣CouponDiscount.ToString("C0")}", a.優惠截止日期CouponDueDate, a.優惠所需紅利BonusCost };
                dataGridViewCoupon.DataSource = q.ToList();
                
            }
            if (txtsearchcoupon.Text != "")
            {
                var q1 = from a in db.優惠總表Coupon.AsEnumerable()
                         where a.優惠編號Coupon_ID.ToString().Contains(txtsearchcoupon.Text)
                         || a.優惠名稱Coupon_Name.Contains(txtsearchcoupon.Text)
                         || a.優惠代碼Coupon_Code.Contains(txtsearchcoupon.Text)
                         || a.優惠折扣CouponDiscount.ToString().Contains(txtsearchcoupon.Text)
                         || a.優惠所需紅利BonusCost.ToString().Contains(txtsearchcoupon.Text)
                         || a.優惠截止日期CouponDueDate.ToString().Contains(txtsearchcoupon.Text)
                         select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{ a.優惠折扣CouponDiscount.ToString("C0")}", a.優惠截止日期CouponDueDate, a.優惠所需紅利BonusCost };
                dataGridViewCoupon.DataSource = q1.ToList();
            }
            clearsearch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("請輸入關鍵字");
                return;
            }
            if (comboBox3.Text != "")
            {
                var q = from a in db.優惠明細CouponLists
                        where a.是否使用優惠OX_CouponUsing.ToString() == comboBox3.Text
                        select new { a.會員編號Member_ID, a.優惠編號Coupon_ID, a.是否使用優惠OX_CouponUsing };
                dataGridViewcplist.DataSource = q.ToList();
            }

            clearsearch();
        }
    }
}
