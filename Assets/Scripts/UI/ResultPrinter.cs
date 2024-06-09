/// выводит информацию о колчиестве победных очков на последней сцене
using TMPro;
using UnityEngine;

public class ResultPrinter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    private void Start()
    {
        resultText.text = $"Вы набрали {Game.ScoreRepository.GetScore} очков";
    }
}
