
public class EventBus
{
    public AtomickEvent<float> TakeDamagEvent;
    public AtomickEvent<float> DischargeBattery;
    public AtomickEvent<int> AddScore;
    public AtomickAction DeadPlayer;

    public EventBus()
    {
        TakeDamagEvent = new();
        DischargeBattery = new();
        AddScore = new();
        DeadPlayer = new();
    }
}
