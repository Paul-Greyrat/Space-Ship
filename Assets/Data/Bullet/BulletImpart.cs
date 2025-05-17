using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbstract
{
    [Header("bullet impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null ) return;
        this.sphereCollider = this.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + " Loaded SphereCollider: ", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null ) return;
        this._rigidbody = this.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + " Loaded Rigidbody: ", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.DamegeSender.Send(other.transform);
    }

}
