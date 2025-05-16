using UnityEngine;

public class JunkFly : ParentFly
{

    [SerializeField] protected float minCamPos= -10f;
    [SerializeField] protected float maxCamPos= 10f;

    protected override void ResetValues()
    {
        base.ResetValues();
        this.speed = 0.1f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 ObjPos = transform.parent.position;
        camPos.x = Random.Range(this.minCamPos, this.maxCamPos);
        camPos.y = Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - ObjPos;
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0f , 0f, angle));

    }
}
