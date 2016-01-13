using System;
using System.Drawing;

namespace Tanks
{
    //public delegate  ExecuteFunction(GetUnitPosition )
    public delegate ISerializable GetUnitPosition(Point swapPosition);
    public enum CommandResult
    {
        Moved,
        MoveFail,
        Turned,
        Fire,
        TankKill,
        FireFail,
        OK,
        ProjectileDestoyed,
        ProjectileKill
    }
    public interface IExecutable
    {
        CommandResult NextComand(GetUnitPosition getUnitt);
    }
}