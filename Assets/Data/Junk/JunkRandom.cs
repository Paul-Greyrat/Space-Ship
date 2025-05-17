using Unity.Mathematics;
using UnityEngine;

public class JunkRandom : GreyMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " junkSpawnerCtrl" , gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        quaternion rot = transform.rotation;
        Transform Ojb = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.MeteroritetOne, pos, rot);
        Ojb.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);

    }
}
