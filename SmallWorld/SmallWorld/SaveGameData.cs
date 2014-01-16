using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld
{

    public class SaveGameData
    {
        public class Data
        {
            public Partie partie;
            public int rectangle;
        }

        /// <summary>
        /// Sauvegarde d'une partie en cours
        /// </summary>
        /// <param name="p"> La partie en cours </param>
        /// <param name="r"> r correspond au nombre de rectangle créer dans l'interface graphique </param>
        public static void WriteXML(Partie p, int r)
        {
            Data overview = new Data();
            overview.partie = p;
            overview.rectangle = r;
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Data));

            System.IO.StreamWriter file = new System.IO.StreamWriter(
                @"SerializationOverview.xml");
            writer.Serialize(file, overview);
            file.Close();
        }


        /// <summary>
        /// Chargement d'une sauvegarde
        /// </summary>
        /// <return> type Data contenant l'ancienne partie </return>
        public static Data ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Data));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"SerializationOverview.xml");
            Data overview = new Data();
            overview = (Data)reader.Deserialize(file);
            return overview;

        }
    }
}
