using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RetroTool.Models
{
    /// <summary>
    /// The board class with its properties
    /// Here is the data stored after api calls
    /// </summary>
    public class Board
    {
        public int Id { get; set; }
        public string B_Name { get; set; }
        public Category Category { get; set; }

    }
}
