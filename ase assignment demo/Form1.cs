using System.Diagnostics;
using BOOSE;

namespace ase_assignment_demo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

        }
    }
}