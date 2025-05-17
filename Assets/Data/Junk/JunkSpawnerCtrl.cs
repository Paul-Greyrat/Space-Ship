using UnityEngine;

public class JunkSpawnerCtrl : GreyMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => this.junkSpawner;}

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => this.spawnPoints;}


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + " JunkSpawner" , gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if( this.spawnPoints != null) return;
        this.spawnPoints = FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + " :LoadSpawnPoints " , gameObject);
    }
}
