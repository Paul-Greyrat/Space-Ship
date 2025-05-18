using Unity.Mathematics;
using UnityEngine;

public class JunkSpawnerRandom : GreyMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float RandomDelay = 1f;
    [SerializeField] protected float RandomTimer = 0f;
    [SerializeField] protected float RandomLimit = 9f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void Update()
    {
        this.JunkSpawning();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " junkSpawnerCtrl", gameObject);
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;
        this.RandomTimer += Time.deltaTime;
        if (this.RandomTimer < this.RandomDelay) return;
        this.RandomTimer = 0f;

        Transform randPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        quaternion rot = transform.rotation;
        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform Ojb = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        Ojb.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawndCount;
        return currentJunk >= this.RandomLimit;
    }
}
