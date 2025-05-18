using Unity.VisualScripting;
using UnityEngine;

public class DamegeSender : GreyMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageRecevier damageRecevier = obj.GetComponentInChildren<DamageRecevier>();
        if (damageRecevier == null) return;
        this.Send(damageRecevier);
    }

    protected virtual void Send(DamageRecevier damageRecevier)
    {
        damageRecevier.Deduct(this.damage);
    }
}
