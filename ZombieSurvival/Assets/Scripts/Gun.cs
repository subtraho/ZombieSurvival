using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireCooldowntime;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunShotSound;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireCooldowntime);
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        gunShotSound.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.takeDamage(damage);
                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 2f);
            }
        }
    }
}
