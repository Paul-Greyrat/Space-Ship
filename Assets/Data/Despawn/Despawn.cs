using UnityEngine;

public abstract class Despawn : GreyMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Despawnig();
    }

    protected virtual void Despawnig()
    {
        if(!this.CanDespawn()) return;
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();

}
