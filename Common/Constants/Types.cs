using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Special types and structures
//


namespace Common
{
    // A SQL pair, of the column and the value it represents. These are useful in arrays for giving data without interest in order.
    public struct SqlPair
    {
        public string Value;
        public string Column;
    }

}
