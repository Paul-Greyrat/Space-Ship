using Unity.Hierarchy;
using UnityEngine;

public class BulletCtrl : GreyMonoBehaviour
{
    [SerializeField] protected DamegeSender damegeSender;
    public DamegeSender DamegeSender { get => this.damegeSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => this.bulletDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamegeSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamegeSender()
    {
        if (this.damegeSender != null) return;
        this.damegeSender = GetComponentInChildren<DamegeSender>();
        Debug.Log(transform.name + " Loaded Model: ", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + " Loaded BulletDespawn:", gameObject);
   }
}