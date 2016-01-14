namespace Tanks
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public interface IDirectinable
    {
        Direction Direction { get; set; }
    }
}