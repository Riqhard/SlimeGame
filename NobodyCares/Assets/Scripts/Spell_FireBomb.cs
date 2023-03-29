using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_FireBomb : Spell
{
    [Header("FIRE BOMB")]
    public Transform wandTipPoint;
    public Bullet bullet;

    public float muzzleVelocity = 35f;

    float nextShotTime;
    public void Start()
    {

        Transform rotationPoint = GetComponentInParent<FollowMouse>().transform;

        wandTipPoint = rotationPoint.GetComponentInChildren<TheWandTip>().transform;
    }

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + spellCD / 1000;
            Bullet newBullet = Instantiate(bullet, wandTipPoint.position, wandTipPoint.rotation) as Bullet;
            newBullet.SetSpeed(muzzleVelocity);
            newBullet.SetDmg(spellDmg);
            newBullet.SetAOE(spellAOE);
        }

    }
}
