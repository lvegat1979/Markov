using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renders
{
    /// <summary>
    /// Class to render the rules that come from json.
    /// </summary>
    public class Base: IWord
        
    {
        /// <summary>
        /// found word that will be replaced
        /// /// </summary>
        public string source { get; set; }
        /// <summary>
        /// Word with which will be replaced
        /// </summary>
        public string replacement { get; set; }

        public string Read()
        {
            throw new NotImplementedException();
        }
    }
}
