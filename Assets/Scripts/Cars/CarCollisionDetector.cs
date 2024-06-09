/// класс - детектор столкновени€ машины. 
/// ѕри стокновении с игроком, игрок вызывает метод Crash у машины, тем самым переключа€ ее состо€ние на CarCrashState
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CarCollisionDetector : MonoBehaviour, ICrashed
{
    [SerializeField] private SwitcherState _switcherState;
    [SerializeField] private StateName stateName;
  
    public void Crash()
    {
        _switcherState.Switch(stateName);
    }
}
