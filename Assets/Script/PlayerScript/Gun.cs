using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;


    public float bigDamage = 1f;
    public float smallDamage = 0.5f;

    public float fireRate = 1f;
    public float nextTimeToFire;

    public int maxAmmo;
    private int ammo;
    private BoxCollider gunTrigger;

    public EnemyManager enemyManager;
    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;
    public Animator gunAnim;
    public Animator gunAnim2;
    public int gunType;
    public static bool noShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        gunType = 0;
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, verticalRange * 0.5f);
        noShoot = false;

        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    // Update is called once per frame
    void Update()
    {
        if (!noShoot && Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
        if (PlayerInventory.hasShotGun && Input.GetKeyDown(KeyCode.E))
        {
            SwitchGun();
        }
    }

    void Fire()
    {
        if (gunType == 0)
        {
            bigDamage = 1f;
            smallDamage = 0.5f;
            gunAnim2.SetTrigger("Shoot2");
            fireRate = 0.5f;
            AudioController.instance.PlayGunShoot2();
        }
        else
        {
            bigDamage = 2f;
            smallDamage = 0.5f;
            gunAnim.SetTrigger("Shoot");
            fireRate = 1f;
            AudioController.instance.PlayGunShot();
        }

        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;


            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(bigDamage);
                    }

                    AudioController.instance.PlayEnemyHurt();
                }
            }
        }


        nextTimeToFire = Time.time + fireRate;
        ammo = Mathf.Max(0, ammo - ((gunType == 0) ? 1 : 2));
        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (ammo < maxAmmo)
        {
            AudioController.instance.PlayAmmo();
            ammo += amount;
            Destroy(pickup);
        }

        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    public void SwitchGun()
    {
        AudioController.instance.PlayGunSwitch();
        if (gunType == 0)
        {
            gunType = 1;
            CanvasManager.Instance.UpdateShotGun();
        }
        else
        {
            gunType = 0;
            CanvasManager.Instance.UpdatePistol();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

    public int GetAmmo()
    {
        return ammo;
    }


}
