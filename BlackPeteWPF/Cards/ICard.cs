using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public interface ICard
    {
        int CardValue { get; }
        string Name { get; }
    }
}
