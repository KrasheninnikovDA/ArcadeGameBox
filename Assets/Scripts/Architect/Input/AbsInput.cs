/// абстракный инпут. Передается в классы требующие пользовательского ввода. 
using UnityEngine;

public abstract class AbsInput : MonoBehaviour
{
    public abstract float HorizontalMove { get; }
    public abstract bool SignalOfBeginningOfDeceleration { get; }
    public abstract bool SignalForEndOfDeceleration { get; }
}
