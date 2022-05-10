using Auttobattler.Backend.RunLogic;
using Auttobattler.Backend.RunLogic.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Backend.RunLogic.GenericGrid
{
    public class GridView<T>
    {
        public SlotView<T> front;
        public SlotView<T> back;

    }
}
