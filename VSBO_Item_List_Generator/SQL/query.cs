using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VSBO_Item_List_Generator.SQL
{
    class query
    {
        public string listOfStrores()
        {
            return File.ReadAllText(Environment.CurrentDirectory + @"\SQL\ListOfStores.sql");
        }

        public string listOfItems()
        {
            return File.ReadAllText(Environment.CurrentDirectory + @"\SQL\ListOfItems.sql");
        }
    }
}
