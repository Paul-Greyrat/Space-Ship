using UnityEngine;

public class JunkDameRecevier : DamageRecevier
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl => this.junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + " Loaded JunkCtrl:", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
