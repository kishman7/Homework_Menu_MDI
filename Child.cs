using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDemo
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }
        public RichTextBox RichTextBoxChild => richTextBox1; //властивість, яка посилається на richTextBox1 в дочірній формі
    }
}
