using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace CreateCircle
{
    public class Class1
    {
        [CommandMethod("CRT")]
        public void ini()
        {
            CircleCrt1 crt = new CircleCrt1();
        }
        


        public  void CreateCircle(int r, int x, int y)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //Star transction
            using(Transaction trn = db.TransactionManager.StartTransaction())
            {
                BlockTable blkt = trn.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blkrec = trn.GetObject(blkt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                //Create circle
                Circle cir = new Circle();
                cir.Radius = r;
                cir.Center = new Point3d(x, y, 0);
                

                

                blkrec.AppendEntity(cir);
                trn.AddNewlyCreatedDBObject(cir, true);
                trn.Commit();
            }
        }
    }
}

