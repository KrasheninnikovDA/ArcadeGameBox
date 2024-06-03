
using UnityEngine;

public abstract class AbsInput : MonoBehaviour
{
    public abstract float HorizontalMove { get; }
    public abstract bool SignalOfBeginningOfDeceleration { get; }
    public abstract bool SignalForEndOfDeceleration { get; }
    public abstract bool Attack { get; }
}
