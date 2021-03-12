using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUserCountDto
    {
        [XmlElement("count")]
        public string Count { get; set; }
        [XmlElement("users")]
        public ExportUserDto[] Users { get; set; }

    }

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }

        public ExportProductCountDto SoldProduct { get; set; }

    }

    public class ExportProductCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ExportProductDto[] Products { get; set; }
    }
}
