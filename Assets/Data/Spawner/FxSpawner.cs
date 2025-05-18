using UnityEngine;

public class FxSpawner : Spawner
{
    private static FxSpawner instance;
    public static FxSpawner Instance { get => instance;}

    public static string FxOne = "Fx 1";
    public static string FxTwo = "Fx 2";

    

    protected override void Awake()
    {
        base.Awake();
        if (FxSpawner.instance != null) Debug.LogError("FxSpawner already exits");
        FxSpawner.instance = this;
    }
}
