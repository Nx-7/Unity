using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private GunData gunData; 
    [SerializeField] private Transform muzzle; 
    public ParticleSystem muzzleFlash;
    public GameObject magazine;
    public TrailRenderer bulletTrail;
    [SerializeField] private GameObject bloodPS = null; 
    [SerializeField] private GameObject GroundPS = null; 
    [SerializeField] private GameObject MetalPS = null; 
    [SerializeField] private GameObject StonePS = null; 
    [SerializeField] private GameObject WoodPS = null; 
    public Text ammoText;
    AudioSource shootingSound;


    
    float timeSinceLastShot;

    private void Start(){

        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        shootingSound = GetComponent<AudioSource>();

    }

     private void OnDestroy()
    {
        PlayerShoot.shootInput -= Shoot;
        PlayerShoot.reloadInput -= StartReload;
    }

    public void StartReload() {
        if (gunData != null && !gunData.reloading){
            StartCoroutine(Reload());
        }
    }


    private IEnumerator Reload() {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }



    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot() {

       


        if (gunData.currentAmmo > 0){

            

            if (CanShoot()){

                var bullet = Instantiate(bulletTrail, muzzle.position, Quaternion.identity);
                    bullet.AddPosition(muzzle.position);
                    {
                            bullet.transform.position = transform.position + (transform.forward * 200);
                        }

                shootingSound.Play();

                if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance)){


                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage);

                    if (hitInfo.transform.CompareTag("Enemy")) {
                        SpawnBloodParticles(hitInfo.point);

                        Debug.Log(hitInfo.transform.name);
                    }

                    if (hitInfo.transform.CompareTag("Terrain")){
                        SpawnGroundParticles(hitInfo.point);

                    }

                    if (hitInfo.transform.CompareTag("Metal")){
                        SpawnMetalParticles(hitInfo.point);

                    }

                    if (hitInfo.transform.CompareTag("Stone")){
                        SpawnStoneParticles(hitInfo.point);

                    }

                    if (hitInfo.transform.CompareTag("Wood")){
                        SpawnWoodParticles(hitInfo.point);

                    }
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
                muzzleFlash.Play();
            }

        }
    }

   

    private void Update() {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawLine(muzzle.position, muzzle.forward);
        ammoText.text = gunData.currentAmmo.ToString();
    }


    private void OnGunShot() {

    }

    private void SpawnBloodParticles(Vector3 position){

        GameObject bloodEffect = Instantiate(bloodPS, position, Quaternion.identity);
        Vector3 direction = transform.position - position;
        bloodEffect.transform.rotation = Quaternion.LookRotation(direction);
}

    private void SpawnGroundParticles(Vector3 position){

        GameObject groundEffect = Instantiate(GroundPS, position, Quaternion.identity);
        Vector3 direction = transform.position - position;
        groundEffect.transform.rotation = Quaternion.LookRotation(direction);
}

    private void SpawnMetalParticles(Vector3 position){

        GameObject metalEffect = Instantiate(MetalPS, position, Quaternion.identity);
        Vector3 direction = transform.position - position;
        metalEffect.transform.rotation = Quaternion.LookRotation(direction);
}

 private void SpawnStoneParticles(Vector3 position){

        GameObject stoneEffect = Instantiate(StonePS, position, Quaternion.identity);
        Vector3 direction = transform.position - position;
        stoneEffect.transform.rotation = Quaternion.LookRotation(direction);
}

private void SpawnWoodParticles(Vector3 position){

        GameObject woodEffect = Instantiate(WoodPS, position, Quaternion.identity);
        Vector3 direction = transform.position - position;
        woodEffect.transform.rotation = Quaternion.LookRotation(direction);
}





}
