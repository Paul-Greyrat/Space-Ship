using UnityEngine;

public class ParentFly : GreyMonoBehaviour
{
    [SerializeField] protected float speed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
        
    }
}
