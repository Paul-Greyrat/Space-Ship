using UnityEngine;

public abstract class BulletAbstract : GreyMonoBehaviour
{
    [Header("bullet abstract")]

    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => this.bulletCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameReceiver();
   }

   protected virtual void LoadDameReceiver()
   {
    if (this.bulletCtrl != null) return;
    this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    Debug.Log(transform.name + " Loaded Model: ", gameObject);
   }
}
