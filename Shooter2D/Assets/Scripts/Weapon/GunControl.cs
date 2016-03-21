using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float shotSpeed;
    public float fireRate;

    private float nextShot;

    void Start()
    {
        nextShot = 0.0f;
    }

    public bool CanShoot()
    {
        return Time.time > nextShot;
    }

    public void Shoot()
    {
        var newShotObject = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        var newShotMover = newShotObject.GetComponent<ShotMover>();

        var velocity = shotSpawn.up * shotSpeed;
        var velocityVector2 = new Vector2(velocity.x, velocity.y);
        newShotMover.SetVelocity(velocityVector2);
        nextShot = Time.time + fireRate;
    }

}
