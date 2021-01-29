using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurRehberi
{
    public static class Connection
    {
        //Burada açtığımız SqlConnection Class'ı sayesinde tekrar tekrar DataBase'mizi yazmak zorunda değiliz;
        public const string sqlConnectionDB = @"Data Source=DESKTOP-SERVET-\SQLEXPRESS;Initial Catalog=TurRehberi;Integrated Security=True";
        //public const string sqlConnectionDB = "Data Source=MHMTENS13\\MHMTENS13;Initial Catalog=TurRehberi;Integrated Security=True";
    }
}
