using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orus.Interfaces
{
    public interface IInteractable : ICollideable
    {
        void Interact();
    }
}
