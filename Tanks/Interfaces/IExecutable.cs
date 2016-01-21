using System.Drawing;

namespace Tanks
{
    public delegate IPositionable GetUnitPosition(Point swapPosition);
    public enum CommandResult
    {
        Moved,
        MoveFail,
        Turned,
        Fire,
        TankKill,
        FireFail,
        ProjectileMoved,
        CanMove,
        CantMove,
        EnemyVisible,
        EnemyNotVisible,
        Unknown
    }
    public interface IExecutable
    {
        CommandResult NextComand();
    }
}