using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorraGirona_Projecte
{
    public class PollMember
    {
        private bool admin { get; set; }
        private int id;
        private string name { get; set; }
        private string surname { get; set; }
        private string address { get; set; }
        private string nif { get; set; }
        private string email { get; set; }
        private string globalScore { get; set; }

        public PollMember()
        {

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool Admin
        { 
            get {  return admin; } 
            set { admin = value; } 
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string GlobalScore
        {
            get { return globalScore; }
            set { globalScore = value; }
        }

    }
}