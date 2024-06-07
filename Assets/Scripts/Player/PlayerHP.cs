
using UnityEngine;

public class PlayerHP : MonoBehaviour, ICrashed
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _valueDamag;

    private HPControlMechanics _hpControlMechanics;
    private Variable<int> _currentHP;

    private void Start()
    {
        _currentHP = new(_maxHP);
        _hpControlMechanics = new(_currentHP);
        _hpControlMechanics.TakeDamageAction.Subscribe(PrintHP);
        _hpControlMechanics.DeathAction.Subscribe(Death);
    }

    public void Crash()
    {
        _hpControlMechanics.TakeDamage(_valueDamag);
    }

    private void PrintHP()
    {
        Game.EventBus.TakeDamagEvent.Invoke((float)_currentHP.Value / _maxHP);
    }

    private void Death()
    {
        Game.EventBus.DeadPlayer.Invoke();
    }


}
