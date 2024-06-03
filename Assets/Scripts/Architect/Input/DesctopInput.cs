
using UnityEngine;

public class DesctopInput : AbsInput
{
    public override float HorizontalMove => _horizontalMove;
    public override bool Attack => _attack;
    public override bool SignalOfBeginningOfDeceleration => _signalOfBeginningOfDeceleration;
    public override bool SignalForEndOfDeceleration => _signalOfEndOfDeceleration;

    private float _horizontalMove;
    private bool _signalOfBeginningOfDeceleration;
    private bool _signalOfEndOfDeceleration;
    private bool _attack;

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _attack = Input.GetKeyDown(KeyCode.Space);
        _signalOfBeginningOfDeceleration = Input.GetKeyDown(KeyCode.LeftShift);
        _signalOfEndOfDeceleration = Input.GetKeyUp(KeyCode.LeftShift);
    }
}
