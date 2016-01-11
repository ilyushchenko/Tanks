using System;
using System.Drawing;

namespace Tanks
{
    public interface IExecutable
    {
        void NextComand(Func<Point, ISerializable> getUnit, Action<ISerializable> setUnit);
    }
}