using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CreateCircle
{
    public partial class Form2 : Form
    {
        // Form of insertion of credential of circle 
        public Form2(CircleCrt1 crl)
        {
            InitializeComponent();
            ElementHost em = new ElementHost();
            Form2 form2 = this;
            em.Width = form2.Width;
           
            em.Height = form2.Height;
            this.Controls.Add(em);
            em.Child = crl;
        }

        public class cb
        {
            // Method of drawing of circle 
            [CommandMethod("CRT")]

            public void show()
            {
                CircleCrt1 crl = new CircleCrt1();
                Form2 myform = new Form2(crl);
                Application.ShowModalDialog(myform);


            }
            // Command to draw line 
            [CommandMethod("DRLINE")]
            public void dr()
            {
                Class2 c = new Class2();
                c.CreateLine(0, 0, 100, 100);
            }



        }
    }
}
