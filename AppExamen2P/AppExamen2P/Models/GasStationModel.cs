using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen2P.Models
{
    [Table("GasStation")]
    public class GasStationModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public double GreenGasPrice { get; set; }
        public double RedGasPrice { get; set; }
        public double DieselPrice { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageBase64 { get; set; }



    }
}
