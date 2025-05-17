using UnityEngine;

public class DamageRecevier : GreyMonoBehaviour
{
    [SerializeField] protected float hp = 1;
    [SerializeField] protected float hpMax = 10;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.hp = this.hpMax;
    }

    protected virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
    }

    protected virtual bool ISDead()
    {
        return this.hp <= 0;
    }
}
