
public class ScoreRepository 
{
    public int GetScore => _score;
    private int _score;

    public ScoreRepository()
    {
        _score = 0;
    }

    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
    }
}
