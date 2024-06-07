
public static class Game 
{
    public static bool IsInit { private set; get; }
    public static SceneManagerExpansion SceneManagerExpansion;
    public static EventBus EventBus;
    public static ScoreRepository ScoreRepository;

    public static void Init(SceneManagerExpansion sceneManager)
    {
        IsInit = true;
        SceneManagerExpansion = sceneManager;
        EventBus = new();
        ScoreRepository = new();
    }

}
