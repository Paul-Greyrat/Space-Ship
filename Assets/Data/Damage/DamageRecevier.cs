using Unity.Hierarchy;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageRecevier : GreyMonoBehaviour
{
    [Header("damege recevier")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected bool ISDead = false;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.27f;
        Debug.Log(transform.name + " Loaded SphereCollier");
    }

    protected virtual void Reborn()
    {
        this.hp = this.hpMax;
    }

    protected virtual void Add(int add)
    {
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.IsDead()) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.ISDead = true;
        this.OnDead();
    }

    protected virtual void OnDead()
    {
        //For Override
    }
}
