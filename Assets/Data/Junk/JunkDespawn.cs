using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        this.dislimit = 20f;
    }
}
