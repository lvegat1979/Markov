using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renders
{
    /// <summary>
    ///  Contains a list of objects (size N), in which one each node has the following form/
    /// </summary>
    public class WValue : IComparable
    {
        /// <summary>
        /// Determines the order in which one the rules should be executed
        /// </summary>
        public int order { get; set; }
        /// <summary>
        /// Determines the index of the rule in "base" list
        /// </summary>
        public int rule { get; set; }
        /// <summary>
        /// Determines wether the execution should continue or be halted
        /// </summary>
        public bool isTermination { get; set; }

        public int CompareTo(object obj)
        {
            return this.order.CompareTo(obj);
        }
    }  
}
