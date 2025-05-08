using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance;}

    public static string MeteroritetOne = "Meterorite 1";
    public static string MeteroriteTwo = "Meterorite 2";

    

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("JunkSpawner already exits");
        JunkSpawner.instance = this;
    }
}
