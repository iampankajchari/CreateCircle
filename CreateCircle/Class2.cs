using System;
using System.Collections.Generic;
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
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.PlottingServices;

namespace CreateCircle
{
    class Class2
    {

        public void CreateCircle(int r, int x, int y)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //Star transction
            using (Transaction trn = db.TransactionManager.StartTransaction())
            {
               
                BlockTable blkt = trn.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkrec = trn.GetObject(blkt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                
                //Create circle
                Circle cir = new Circle();
                cir.SetDatabaseDefaults();
                cir.Radius = r;
                cir.Center = new Point3d(x, y, 0);

               db.Lunits = (int)DistanceUnitFormat.Architectural;
               
                blkrec.AppendEntity(cir);
               
                trn.AddNewlyCreatedDBObject(cir, true);
                
                trn.Commit();
            }

        }

        public void CreateRec(int h, int b, int x, int y)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //Star transction
            using (Transaction trn = db.TransactionManager.StartTransaction())
            {
                BlockTable blkt = trn.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkrec = trn.GetObject(blkt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                Line l = new Line();
                Line l1 = new Line();
                l.StartPoint = new Point3d(x, y, 0);

                l.EndPoint = new Point3d(x + h, y, 0);

                l1.StartPoint = l.EndPoint;

                l1.EndPoint = new Point3d(x + h, y + b, 0);

                Line l2 = new Line();

                l2.StartPoint = l1.EndPoint;

                l2.EndPoint = new Point3d(x, y + b, 0);

                Line l3 = new Line();

                l3.StartPoint = l2.EndPoint;

                l3.EndPoint = l.StartPoint;
                
                db.Lunits = (int)DistanceUnitFormat.Architectural;

                blkrec.Units = UnitsValue.Centimeters;
                blkrec.BlockScaling = BlockScaling.Uniform;

                blkrec.AppendEntity(l);
                blkrec.AppendEntity(l1);
                blkrec.AppendEntity(l2);
                blkrec.AppendEntity(l3);


                trn.AddNewlyCreatedDBObject(l, true);
                trn.AddNewlyCreatedDBObject(l1, true);
                trn.AddNewlyCreatedDBObject(l2, true);
                trn.AddNewlyCreatedDBObject(l3, true);
                trn.Commit();
            }

        }

        public void CreateLine(double stptx,double stpty, double enptx, double enpty)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //Star transction
            using (Transaction trn = db.TransactionManager.StartTransaction())
            {
                BlockTable blkt = trn.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkrec = trn.GetObject(blkt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;




                Line l = new Line();
                
                l.StartPoint = new Point3d(stptx,stpty,0);

                l.EndPoint = new Point3d(enptx,enpty,0);


                db.Lunits = (int)DistanceUnitFormat.Architectural;

                blkrec.Units = UnitsValue.Centimeters;
                blkrec.BlockScaling = BlockScaling.Uniform;

                blkrec.AppendEntity(l);
               


                trn.AddNewlyCreatedDBObject(l, true);
                
                trn.Commit();
            }

        }

        public static void Add_Layer(string layer)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using( Transaction trn = db.TransactionManager.StartTransaction())
            {
                LayerTable lytab = trn.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (lytab.Has(layer))
                {
                    CircleCrt1 circleCrt1 = new CircleCrt1();
                    circleCrt1.lbl_lyr.Content = "Layer already exits";
                    doc.Editor.WriteMessage("Layer already exits");
                    
                    trn.Abort();
                }
                else
                {
                    CircleCrt1 circleCrt1 = new CircleCrt1();
                    circleCrt1.lbl_lyr.Content = "Layer Created";
                    lytab.UpgradeOpen();
                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = layer;
                    lytab.Add(ltr);
                    trn.AddNewlyCreatedDBObject(ltr, true);
                    
                    db.Clayer = lytab[layer];
                    doc.Editor.WriteMessage(layer);
                    trn.Commit();
                    

                }
            }
        }
        
    }
}
