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
    public partial class MDAControl : UserControl
    {
        public MDAControl()
        {
            InitializeComponent();
        }
        string _Cht;

        public string Cht
        {
            get
            {
                return _Cht;
            }
            set
            {
                _Cht = value;
                this.labCH.Text = _Cht;
            }
        }

        public byte[] Bytes
        {
            set
            {

                if(value!=null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(value);
                    this.pictureBox1.Image = Image.FromStream(ms);
                }
                
            }
        }
        string _Eng;
        public string Eng
        {
            get
            {
                return _Eng;
            }
            set
            {
                _Eng = value;
                this.labEng.Text = _Eng;
            }
        }
        private int _a;
        public int 導演編號
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                this.labMovie.Text = $"導演編號: {_a}";
            }
        }
    }
}
