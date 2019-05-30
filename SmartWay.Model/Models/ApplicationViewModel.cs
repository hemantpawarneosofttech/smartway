using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWay.Model.Models
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ParentModel
    {
        public List<ApplicationViewModel> applicationList { get; set; }
    }

    public class Shapes
    {
        public int id { get; set; }
        public string shapeType { get; set; }
        public string shapeControlName { get; set; }
        public string shapeLabel { get; set; }
        public string linkSource { get; set; }
        public string linkTarget { get; set; }
        public object parent { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsBase { get; set; }
    }
}
