using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    interface ICollectItems
    {
        ICollection<IItem> CollectedItems { get; set; }
        void Collect(IItem item);
    }
}
