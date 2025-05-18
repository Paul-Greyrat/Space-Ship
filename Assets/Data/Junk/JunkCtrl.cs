using Unity.Hierarchy;
using UnityEngine;

public class JunkCtrl : GreyMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => this.model; }
    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => this.junkDespawn; }

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => this.junkSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
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

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = "Junk/" + this.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.LogWarning(transform.name + " Loaded JunkSO: " + resPath, gameObject);
    }

}