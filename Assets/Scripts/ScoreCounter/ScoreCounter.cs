/// счетчик очков. когда машина пересекает тригер, начисляются очки
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IScore score = collision.GetComponent<IScore>();
        if (score != null)
        {
            Game.EventBus.AddScore.Invoke(score.ScoreValue);
        }
    }
}
