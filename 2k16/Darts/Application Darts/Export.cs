using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Windows.Forms;

namespace Application_Darts
{
    public class Export
    {

        public Export()
        {
            ScoreBoard sb = new ScoreBoard(301, new Joueur("Ginette"), new Joueur("Roland"));
            for (int i = 0; i < 10; i++)
            {
                sb.ScoreJoueur1.Ajout(5);
                sb.ScoreJoueur2.Ajout(6);
            }
            Exporter(sb);
        }

        public static void Exporter(ScoreBoard score)
        {
            DateTime date = DateTime.Now;
            DataSet ds = new DataSet();
            ds.Tables.Add(string.Format(date.ToShortDateString(), score.Joueur1.Nom, score.Joueur2.Nom));
            ds.Tables[0].Columns.Add(score.Joueur1.Nom, typeof(System.Int32));
            ds.Tables[0].Columns.Add(score.Joueur2.Nom, typeof(System.Int32));
            for (int i = 0; i < score.ScoreJoueur1.Get().Count; i++)
			{
                ds.Tables[0].Rows.Add(score.ScoreJoueur1.Get()[i], score.ScoreJoueur2.Get()[i]);
			}
            MessageBox.Show(CreateExcelFile.CreateExcelDocument(ds, date.ToShortDateString() + ".xlsx") ? "Yes!" : "Fail");

        }
    }
}
