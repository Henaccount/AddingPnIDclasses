using Autodesk.AutoCAD.Runtime;
using Autodesk.ProcessPower.PlantInstance;
using Autodesk.ProcessPower.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CommandClass(typeof(AddingPnIDclasses.Class1))]

namespace AddingPnIDclasses
{
    public class Class1
    {
        [CommandMethod("AddingPnIDclasses", CommandFlags.Session)]
        public static void addclasses()
        {

            // Get project
            //
            var project = PlantApplication.CurrentProject;

            // P&D part
            //
            var part = project.ProjectParts["PnId"];

            // Data links manager
            var dlm = part.DataLinksManager;

            // PnPDatabase
            //
            var db = dlm.GetPnPDatabase();

            // Create new PnPTable with the name, base class, add columns, and add it to db.Tables collection

            PnPTable pidClass = new PnPTable("NewPIDClass2" , db.Tables["HandValves"], false);

            db.Tables.Add(pidClass);

            //see readme:
            
            pidClass.SetTableAttribute("DisplayName", "NewPIDClass2", "PnPClassDisplayName");
            pidClass.SetTableAttribute("BitwiseFlagValue", "3", "PnPClassFlagType");

            pidClass.SetColumnAttribute("ClassName", "VALUE", "NewPIDClass2");
            pidClass.SetColumnAttribute("Description", "VALUE", "NewPIDClass2");
            pidClass.SetColumnAttribute("Normally", "VALUE", "SSPL$NewPIDClass2_Normally");


            // Accept changes to write new class to database
            //
            db.AcceptChanges();



        }

    }
}
