using Unity.Hierarchy;
using UnityEngine;

public class JunkCtrl : GreyMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => this.model;}
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => this.junkDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.JunkDespawn != null) return;
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + " Loaded JunkDespawn: ", gameObject);
    }

   protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + " Loaded Model: ", gameObject);
    }

}