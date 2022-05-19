using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class Club
    {
        private string name;
        private string shortName;
        private int id;
        private Championship championship;
        private string stadium;
        private string locality;

        public Club() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Championship Championship
        {
            get {  return championship; }
            set {  championship = value;}
        }
        public string Stadium
        {
            get { return stadium; }
            set { stadium = value; }
        }
        public string Locality
        {
            get { return locality; }
            set { locality = value; }
        }
    }
}