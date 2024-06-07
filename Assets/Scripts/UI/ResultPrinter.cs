
using TMPro;
using UnityEngine;

public class ResultPrinter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    private void Start()
    {
        resultText.text = $"�� ������� {Game.ScoreRepository.GetScore} �����";
    }
}
