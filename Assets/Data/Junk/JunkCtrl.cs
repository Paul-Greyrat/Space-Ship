using UnityEngine;

public class JunkCtrl : GreyMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => this.model;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
   }

   protected virtual void LoadModel()
   {
    if (this.model != null) return;
    this.model = transform.Find("Model");
    Debug.Log(transform.name + " Loaded Model: ", gameObject);
   }

}