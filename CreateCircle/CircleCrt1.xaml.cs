using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;


namespace CreateCircle
{
    /// <summary>
    /// Interaction logic for CircleCrt1.xaml
    /// </summary>
    public partial class CircleCrt1 : UserControl
    {
        public CircleCrt1()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Content.ToString()=="Circle")
            {
                int x = Convert.ToInt32(txtX.Text);
                int y = Convert.ToInt32(txtY.Text);
                int r = Convert.ToInt32(txtRd.Text);
                Class2 cl = new Class2();
                cl.CreateCircle(r, x, y);
                txtX.Text = string.Empty;
                txtY.Text = string.Empty;
                txtRd.Text = string.Empty;
                Application.UpdateScreen();
            }
            if (btn.Content.ToString()=="Draw Line")
            {
                double x = Convert.ToDouble(txtstX.Text);
                double y = Convert.ToDouble(txtstY.Text);
                double ex = Convert.ToDouble(txtenX.Text);
                double ey = Convert.ToDouble(txtenY.Text);
                Class2 cl = new Class2();
                cl.CreateLine(x, y, ex, ey);
                txtstX.Text = string.Empty;
                txtstY.Text = string.Empty;
                txtenX.Text = string.Empty;
                txtenY.Text = string.Empty;
                Application.UpdateScreen();
               
            }
            if (btn.Content.ToString() == "Rectangle")
            {
                int x = Convert.ToInt32(txtRX.Text);
                int y = Convert.ToInt32(txtRY.Text);
                int h = Convert.ToInt32(txtH.Text);
                int w = Convert.ToInt32(txtW.Text);
                Class2 cl = new Class2();
                cl.CreateRec(h, w, x, y);
                txtRX.Text = string.Empty;
                txtRY.Text = string.Empty;
                txtH.Text = string.Empty;
                txtW.Text = string.Empty;
                Application.UpdateScreen();
            }







        }

        

        private void Layer_Click(object sender, RoutedEventArgs e)
        {

            Class2.Add_Layer(txt_Layer.Text);
            txt_Layer.Text = string.Empty;
        }
    }
}
