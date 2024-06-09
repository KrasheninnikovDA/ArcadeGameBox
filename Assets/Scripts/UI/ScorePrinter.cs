/// отображение победных рчков в сцене геймплея
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    [SerializeField] private Sprite[] _spritesNumber;
    [SerializeField] private Image _unitsImage;
    [SerializeField] private Image _dozensImage;
    [SerializeField] private Image _hundredsImage;

    private int _unit;
    private int _dozen;
    private int _hundred;

    private void Start()
    {
        Game.EventBus.AddScore.Subscribe(AddScore);
    }

    private void AddScore(int score)
    {
        _unit += score;
        if (_unit > 9 && (_dozen < 9 || _hundred < 9))
        {
            _dozen += 1;
            _unit %= 10;
            if (_dozen > 9)
            {
                _hundred += 1;
                _dozen %= 10;
            }
        }
        PrintScore();
    }

    private void PrintScore()
    {
        _unitsImage.sprite = _spritesNumber[_unit];
        _dozensImage.sprite = _spritesNumber[_dozen];
        _hundredsImage.sprite = _spritesNumber[_hundred];
    }

    private void OnDisable()
    {
        Game.EventBus.AddScore.Unsubscribe(AddScore);
    }
}
