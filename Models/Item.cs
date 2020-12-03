using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroTool.Models
{
    /// <summary>
    /// The Item class with its properties
    /// Here is the data stored after api calls
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public Board B_IdId { get; set; }
        public string I_Text { get; set; }
        public int Column { get; set; }
    }
}
