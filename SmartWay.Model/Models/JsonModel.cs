using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWay.Model.Models
{

    public class JsonModel
    {
        public int id { get; set; }
        public string shapeType { get; set; }
        public string shapeControlName { get; set; }
        public string shapeLabel { get; set; }
        public string linkSource { get; set; }
        public string linkTarget { get; set; }
        public string parent { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsBase { get; set; }
        public bool IsApplication { get; set; }

        public int Level { get; set; }


    }
}
