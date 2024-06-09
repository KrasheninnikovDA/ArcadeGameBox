/// отображение состояния батареи
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        Game.EventBus.DischargeBattery.Subscribe(DisplayCapacity);
    }

    private void DisplayCapacity(float CapacityAsPercentage)
    {
        slider.value = CapacityAsPercentage;
    }

    private void OnDisable()
    {
        Game.EventBus.DischargeBattery.Unsubscribe(DisplayCapacity);
    }
}
