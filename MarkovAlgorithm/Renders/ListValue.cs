using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renders
{
    /// <summary>
    /// Contains a List Of Value
    /// </summary>
    public class ListValue
    {
        public List<List<WValue>> Values { get; set; }

        /// <summary>
        /// Reorder the matrix using order field, when the resolved it create 
        /// </summary>
        /// <returns></returns>
        public List<List<WValue>> GetOrderListDesc()
        {
            List<List<WValue>> tempList = new List<List<WValue>>();

            for (int i = 0; i < this.Values.Count; i++)
            {
                tempList.Add(Values[i].OrderByDescending(x => x.order).ToList());
            }
            
            return tempList;
        }
    }
}
