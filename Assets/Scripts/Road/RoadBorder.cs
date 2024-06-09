/// граница дороги. класс реализует механику наенсения урона игроку если тот выезжает с дороги
using UnityEngine;

public class RoadBorder : MonoBehaviour
{
    [SerializeField] private float _frequencyOfDamage;
    private Timer _timerDamage;

    private ICrashed crashed;

    private void Start()
    {
        _timerDamage = new(_frequencyOfDamage, TimerMode.loop);
        _timerDamage.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        crashed = collision.GetComponent<ICrashed>();
        _timerDamage.ActionStopTimer.Subscribe(TakeDamage);
    }

    private void Update()
    {
        _timerDamage.Update();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _timerDamage.ActionStopTimer.Unsubscribe(TakeDamage);
    }

    private void TakeDamage()
    {
        crashed?.Crash();
    }
}
