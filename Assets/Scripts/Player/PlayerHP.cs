
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Variable<int> _maxHP;

    private HPControlMechanics _hpControlMechanics;

    private void Awake()
    {
        _hpControlMechanics = new(_maxHP);
    }

    public void TakeDamageAction()
    {
        _hpControlMechanics.TakeDamage();
    }
}
