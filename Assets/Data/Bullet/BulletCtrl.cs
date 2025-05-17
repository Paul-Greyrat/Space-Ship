using UnityEngine;

public class BulletCtrl : GreyMonoBehaviour
{
    [SerializeField] protected DamegeSender damegeSender;
    public DamegeSender DamegeSender { get => this.damegeSender;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
   }

   protected virtual void LoadModel()
   {
    if (this.damegeSender != null) return;
    this.damegeSender = GetComponentInChildren<DamegeSender>();
    Debug.Log(transform.name + " Loaded Model: ", gameObject);
   }
}