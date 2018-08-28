using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renders
{
    /// <summary>
    /// This store each letter for printing 
    /// </summary>
    public class Letter
    {
        public Letter()
        {

        }
        //Constructor to assing 
            public Letter(int r,int c, string l)
        {
            this.Row = r;
            this.Column = c;
            this.Character = l;
        }

        /// <summary>
        /// Positon row in the array
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Positon column in the array
        /// </summary>
        public int Column { get; set; }


        /// <summary>
        /// Caracther
        /// </summary>
        public string Character { get; set; }
    }
}
