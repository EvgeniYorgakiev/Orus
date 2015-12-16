using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    public interface IQuest
    {
        bool Completed { get; set; }
        void Update();
    }
}
