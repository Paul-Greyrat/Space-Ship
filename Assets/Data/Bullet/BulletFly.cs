using UnityEngine;

public class BulletFly : ParentFly
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.speed = 7;
    }
}
    