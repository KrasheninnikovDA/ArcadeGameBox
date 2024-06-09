/// отображение состояния ХП
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        Game.EventBus.TakeDamagEvent.Subscribe(DisplayHP);
    }

    private void DisplayHP(float remainingHealthAsPercentage)
    {
        slider.value = remainingHealthAsPercentage;
    }

    private void OnDisable()
    {
        Game.EventBus.TakeDamagEvent.Unsubscribe(DisplayHP);
    }
}
