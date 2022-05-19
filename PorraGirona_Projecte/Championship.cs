using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class Championship
    {
        private string name;
        private int id;
        private int division;
        private int clubSlots;

        public Championship() { }

        public string Name 
        {  
            get {  return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Division
        {
            get { return division; }
            set { division = value; }
        }
        public int ClubSlots
        {
            get { return clubSlots; }
            set { clubSlots = value; }
        }
    }
}