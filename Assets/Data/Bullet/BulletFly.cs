using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected int speed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
        
    }
}
