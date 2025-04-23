using Unity.Mathematics;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 TagetPositon;
    [SerializeField] protected float speed = 0.1f;

    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving();
        this.lookAtTarget();
    }

    protected virtual void GetTargetPosition (){
        this.TagetPositon = InputManger.Instance.MouseWorldPos;
        this.TagetPositon.z = 0f;
    }

    protected virtual void Moving (){
        Vector3 newPos = Vector3.Lerp(transform.parent.position, TagetPositon, this.speed);
        transform.parent.position = newPos;
    }

    protected virtual void lookAtTarget (){
        Vector3 diff = this.TagetPositon - transform.parent.position;
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0f , 0f, angle));
    }
}
