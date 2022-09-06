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
    public partial class Coupon : Form
    {
        優惠總表Coupon 優惠總表Coupon = new 優惠總表Coupon();
        MDAEntities1 db = new MDAEntities1();
        public Coupon()
        {
            InitializeComponent();
            var q = (from a in db.優惠總表Coupon
                     orderby a.優惠截止日期CouponDueDate ascending
                     select a.優惠截止日期CouponDueDate).Distinct();
            comboBox1.DataSource = q.ToList();

        }

        void showBonus()
        {
            var q = from a in db.優惠總表Coupon.AsEnumerable()
                    select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{ a.優惠折扣CouponDiscount.ToString("C0")}",a.優惠截止日期CouponDueDate,a.優惠所需紅利BonusCost };
            dataGridViewCoupon.DataSource = q.ToList();
        }

        private void btnviewBonus_Click(object sender, EventArgs e)
        {
            showBonus();
        }

        private void btnLanguageAdd_Click(object sender, EventArgs e)
        {
            if (txtBonusName.Text == "")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
                
            var q = (from p in this.db.優惠總表Coupon
                     where p.優惠名稱Coupon_Name == txtBonusName.Text ||p.優惠代碼Coupon_Code== txtCouponCode.Text
                     select p).Any();
            if (q)
            {
                MessageBox.Show("優惠重複");
                return;
            }
            優惠總表Coupon.優惠名稱Coupon_Name = txtBonusName.Text;
            優惠總表Coupon.優惠代碼Coupon_Code = txtCouponCode.Text;
            優惠總表Coupon.優惠折扣CouponDiscount = decimal.Parse(txtDiscount.Text);
            優惠總表Coupon.優惠截止日期CouponDueDate =Convert.ToDateTime(txtDueday.Text);
            優惠總表Coupon.優惠所需紅利BonusCost = int.Parse(txtPoint.Text);

            this.db.優惠總表Coupon.Add(優惠總表Coupon);
            this.db.SaveChanges();
            labChage.Text = "新增成功";
            showBonus();
            addnull();
        }

        void addnull()
        {
            txtBonusName.Text = "";
            txtCouponCode.Text = "";
            txtDiscount.Text = "";
            txtDueday.Text = "";
            txtPoint.Text = "";
        }

        private void btnLanguageUpDate_Click(object sender, EventArgs e)
        {
            if (txtBonusName.Text == "" || txtDueday.Text=="")
            {
                MessageBox.Show("請輸入資料");
                return;
            }
            var q = (from p in this.db.優惠總表Coupon.AsEnumerable()
                     where p.優惠編號Coupon_ID == int.Parse(dataGridViewCoupon.CurrentRow.Cells["優惠編號Coupon_ID"].Value.ToString())
                     select p).FirstOrDefault();
            q.優惠名稱Coupon_Name = txtBonusName.Text;
            q.優惠代碼Coupon_Code = txtCouponCode.Text;
            q.優惠折扣CouponDiscount = decimal.Parse(txtDiscount.Text);
            q.優惠截止日期CouponDueDate = Convert.ToDateTime(txtDueday.Text);
            q.優惠所需紅利BonusCost = int.Parse(txtPoint.Text);
            this.db.SaveChanges();
            showBonus();
            labChage.Text = "修改成功";
            addnull();
        }

        private void dataGridViewCoupon_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtBonusName.Text = dataGridViewCoupon.CurrentRow.Cells["優惠名稱Coupon_Name"].Value.ToString();
            txtCouponCode.Text= dataGridViewCoupon.CurrentRow.Cells["優惠代碼Coupon_Code"].Value.ToString();
            txtDiscount.Text = (dataGridViewCoupon.CurrentRow.Cells["優惠折扣CouponDiscount"].Value).ToString();
            txtDueday.Text =Convert.ToDateTime(dataGridViewCoupon.CurrentRow.Cells["優惠截止日期CouponDueDate"].Value).ToString("yyyy/MM/dd");

            txtPoint.Text = dataGridViewCoupon.CurrentRow.Cells["優惠所需紅利BonusCost"].Value.ToString();
        }

        
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                var q = from a in db.優惠總表Coupon.AsEnumerable()
                        where a.優惠代碼Coupon_Code.Contains(txtsearch.Text)
                        || a.優惠名稱Coupon_Name.Contains(txtsearch.Text)
                        || a.優惠所需紅利BonusCost.ToString().Contains(txtsearch.Text)
                        || a.優惠折扣CouponDiscount.ToString().Contains(txtsearch.Text)
                        || a.優惠編號Coupon_ID.ToString().Contains(txtsearch.Text)
                        || a.優惠截止日期CouponDueDate.ToString().Contains(txtsearch.Text)
                        select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{ a.優惠折扣CouponDiscount.ToString("C0")}", a.優惠截止日期CouponDueDate, a.優惠所需紅利BonusCost };
                dataGridViewCoupon.DataSource = q.ToList();
            }
            else 
            MessageBox.Show("請輸入關鍵字"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from a in db.優惠總表Coupon.AsEnumerable()
                    where a.優惠截止日期CouponDueDate<= Convert.ToDateTime(comboBox1.Text)
                    select new { a.優惠編號Coupon_ID, a.優惠名稱Coupon_Name, a.優惠代碼Coupon_Code, 優惠折扣CouponDiscount = $"{ a.優惠折扣CouponDiscount.ToString("C0")}", a.優惠截止日期CouponDueDate, a.優惠所需紅利BonusCost };
            dataGridViewCoupon.DataSource = q.ToList();

        }

        private void Coupon_Click(object sender, EventArgs e)
        {
            addnull();
        }
    }
}
