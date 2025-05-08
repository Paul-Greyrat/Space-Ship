using Unity.Mathematics;
using UnityEngine;

public class JunkRandom : GreyMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " LoadJunkCtrl" , gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        quaternion rot = transform.rotation;
        Transform Ojb = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.MeteroritetOne, pos, rot);
        Ojb.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);

    }
}
