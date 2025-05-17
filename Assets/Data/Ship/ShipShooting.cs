using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float ShootDelay = 0.1f;
    [SerializeField] protected float ShootTimer = 0f;

    [SerializeField] protected Transform bulletPrefab;
    

    private void FixedUpdate()
    {
        this.IsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(!this.isShooting)return;
        this.ShootTimer += Time.deltaTime;
        if(this.ShootTimer < this.ShootDelay) return;
        this.ShootTimer = 0f;

        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        //Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos, rotation);
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManger.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
 