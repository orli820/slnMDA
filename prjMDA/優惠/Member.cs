using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMDA
{
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            string[] firstname = { "趙", "錢", "孫", "李", "周", "吳", "鄭", "王", "馮", "陳", "褚", "衛", "蔣", "沈", "韓", "楊" };
            string[] lastname = { "家豪", "志明", "俊傑", "建宏", "俊宏", "志豪", "志偉", "文雄", "金龍", "志強", "淑芬", "淑惠", "美玲", "雅婷", "美惠", "麗華", "淑娟", "淑貞", "怡君", "淑華" };
            string[] company = { "gmail", "hotmail", "outlook", "yahoo" };
            string[] place = { "台北", "台中", "新北", "新竹", "苗栗", "嘉義", "台南", "雲林", "宜蘭", "花蓮", "屏東", "高雄" };
            string phone = "";
            string email = "";
            string password = "";
            string fname = "";
            string lname = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =.; Initial Catalog = MDA; Integrated Security = True";
            con.Open();

            for (int j = 0; j < 5; j++)
            {

                fname = firstname[rnd.Next(0, firstname.Length)];
                lname = lastname[rnd.Next(0, lastname.Length)];
                phone = "";
                for (int i = 0; i < 8; i++)
                {
                    phone += rnd.Next(0, 9).ToString();
                }
                phone = "09" + phone;

                email = "";
                for (int i = 0; i < rnd.Next(7, 12); i++)
                {
                    email += (char)rnd.Next(97, 122);
                }
                email = email + "@" + company[rnd.Next(0, company.Length)] + ".com.tw";
                password = "";
                for (int i = 0; i < rnd.Next(7, 12); i++)
                {
                    password += (char)rnd.Next(97, 122);
                }

                string sql = "INSERT INTO 會員Members(";
                sql += "會員電話Cellphone,";
                sql += "密碼Password,";  //要新增欄位加這順位第二
                sql += "姓氏F_Name,";
                sql += "名字L_Name,";
                sql += "暱稱Nickname,";
                //sql += "生日BirthDate,";
                //sql += "性別Gender,";
                sql += "電子信箱EMail,";  //要新增欄位加這倒數第二
                sql += "地址Address,";
                sql += "紅利點數Bonus,";
                sql += "正式會員Formal,";
                sql += "會員權限Permission";
                //sql += "會員照片Image";
                sql += ") VALUES (";
                sql += "'" + phone + "',";
                sql += "'" + password + "',";
                sql += "'" + fname + "',";
                sql += "'" + lname + "',";
                sql += "'0',";
                //sql += "'0',";
                //sql += "'0',";
                sql += "'" + email + "',";
                sql += "'" + place[rnd.Next(0, place.Length)] + "',";
                sql += "'0',";
                sql += "'0',";
                sql += "'0')";
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =sql ;
              cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        
    }
}
  

