using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float dislimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponents()
    {
        this.LoadCamera();   
    }

    protected virtual void LoadCamera()
    {
        if(this.mainCamera != null) return;
        this.mainCamera = Camera.main.transform;
        if(this.mainCamera == null) Debug.LogError("Main Camera not found");
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, this.mainCamera.position);
        if (this.distance > this.dislimit) return true;
        return false;
    }
}
