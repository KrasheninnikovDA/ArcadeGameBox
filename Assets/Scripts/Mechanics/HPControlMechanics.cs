/// класс - механика, реализует механику урона
/// при нанесении уровна инвокает TakeDamageAction, при снижении хп ниже 0 - DeathAction

public class HPControlMechanics
{
    public AtomickAction TakeDamageAction;
    public AtomickAction DeathAction;

    private Variable<int> _currentHP;
    private bool _isAlive = true;

    public HPControlMechanics(Variable<int> currentHP)
    {
        TakeDamageAction = new();
        DeathAction = new();
        _currentHP = currentHP;
    }

    public void TakeDamage(int damage)
    {
        _currentHP.Value -= damage;
        CheckIsLive();
        TakeDamageAction.Invoke();
    }

    private void CheckIsLive()
    {
        if (_currentHP.Value <= 0)
        {
            SendSignalAboutDeath();
        }
    }

    private void SendSignalAboutDeath()
    {
        if (_isAlive)
        {
            DeathAction.Invoke();
            _isAlive = false;
        }
    }
}
