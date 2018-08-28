using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renders
{
    /// <summary>
    /// Store the each word in this class
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Name of the word, this contains the same of value plus indentifier
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the word
        /// </summary>
        public string Value { get; set; }
        
       /// <summary>
       /// Constructor
       /// </summary>
       /// <param name="name"></param>
       /// <param name="value"></param>
        public Word(string name,string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
