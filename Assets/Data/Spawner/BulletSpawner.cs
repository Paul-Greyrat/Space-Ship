using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance;}

    public static string bulletOne = "Bullet 1";
    public static string bulletTwo = "Bullet 2";

    

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("BulletSpawner already exits");
        BulletSpawner.instance = this;
    }
}
