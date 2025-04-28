using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica_Proiect
{
    public partial class Form2 : Form
    {
        String perspectiva;
        public Form2(string perspectiva)
        {
            InitializeComponent();
            this.perspectiva = perspectiva;
        }
    }
}
