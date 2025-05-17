using UnityEngine;

public abstract class JunkAbstract : GreyMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => this.junkCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
   }

   protected virtual void LoadJunkCtrl()
   {
    if (this.junkCtrl != null) return;
    this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    Debug.Log(transform.name + " Loaded Model: ", gameObject);
   }
}
