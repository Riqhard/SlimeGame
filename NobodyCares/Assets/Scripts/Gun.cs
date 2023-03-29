using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Bullet bullet;
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
            newBullet.SetSpeed(muzzleVelocity);
        }
        
    }
}
