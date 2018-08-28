using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Renders;

namespace WordMatrixUtils
{
    /// <summary>
    /// Apply the algorithm of marKov.
    /// </summary>
    public class MarkovUitl
    {
        /// <summary>
        /// Apply the rules after processing the json files.
        /// </summary>
        /// <param name="bases">Rules</param>
        /// <param name="orderValues">Rules 2 according Markov  The rule sequence must be in ascending order using each node's "order" valuer</param>
        /// <param name="cyphers">List of string with the encript caracthers</param>
        internal List<string> ApplyRules(List<Base> bases, List<List<WValue>> orderValues, List<string> cyphers)
        {
            List<string> newCyphers = new List<string>();
            int ruleNumber = 0;
            bool found = false;
            string source = string.Empty;
            try
            {
                for (int i = 0; i < orderValues.Count; i++)
                {
                    for (int n = 0; n < orderValues[i].Count; n++)
                    {
                        ruleNumber = orderValues[i][n].rule;//Getting the rule number to find this in the collection of the rules.
                        source = bases[ruleNumber].source;
                        //var found = cyphers[i].Replace(bases[ruleNumber].source, bases[ruleNumber].replacement);
                        found = cyphers[i].IndexOf(source) != -1;

                        //Rules 2 according Markov If none is found, the algorithm stops.
                        if (!found && orderValues[i][n].isTermination) 
                            throw new Exception("Cannot continue this ocurrences was not found and is marked as isTermination true, review the rule number" + orderValues[i][n].rule.ToString()); 

                        var regex = new Regex(Regex.Escape(source));
                        //Rules 3 according Markov = If one (or more) is found, use the first of them to replace the leftmost occurrence of matched text in the string input with its replacement.
                        var newText = regex.Replace(cyphers[i], bases[ruleNumber].replacement, 1);

                        cyphers[i] = newText;
                    }
                    newCyphers.Add(cyphers[i]);
                }
                return newCyphers;

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot process the Markov rules" + ex.Message);
            }
        }

    }
}
