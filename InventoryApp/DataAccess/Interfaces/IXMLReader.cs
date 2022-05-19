using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryApp.DataAccess.Interfaces
{
    public interface IXMLReader<T>
    {
        public IEnumerable<T> ReadXML(string sorting);

    }
}
