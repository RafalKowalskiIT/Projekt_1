using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    public class DataObject
    {
        public DataObject(string name, string surname, string position)
        {
            this.Name = name;
            this.Surname = surname;
            this.Position = position;

        }
        public const string CLUB = "F.C. Barcelona";

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

    }



    public delegate void RankAddedDelegade(object sender, EventArgs args);


}
