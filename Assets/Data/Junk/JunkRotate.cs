using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotate();
    }

    protected virtual void Rotate()
    {
        Vector3 euler = new Vector3(0f, 0f, 1);
        this.junkCtrl.Model.Rotate(euler * this.speed * Time.fixedDeltaTime);
    }
}
