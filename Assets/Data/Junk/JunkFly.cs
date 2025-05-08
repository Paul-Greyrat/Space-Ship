using UnityEngine;

public class JunkFly : ParentFly
{
        protected override void ResetValues()
    {
        base.ResetValues();
        this.speed = 0.1f;
    }
}
