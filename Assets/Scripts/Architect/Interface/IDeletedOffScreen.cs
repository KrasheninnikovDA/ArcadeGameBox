
using UnityEngine;

public interface IDeletedOffScreen
{
    public AtomickAction EndLifeCycle { get; }
    public void SetPointBorderScreen(Vector2 PointBorderScreen);
}
