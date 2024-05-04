using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System;

public class BulletSpawner : MonoBehaviour
{
    public static event Action OnBulletFired;
    public static BulletSpawner Instance;
    [SerializeField]
    Transform bulletSpawnLocation;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    CinemachineVirtualCamera bulletCamera;
    
    public static bool shooting = false;
    GameObject bullet;
   
    public FirstPersonController fpsController;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        bulletCamera = bulletPrefab.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !shooting)
        {
            BulletShoot();
        }
       
    }

    void BulletShoot()
    {
        fpsController.enabled = false;
        bullet = Instantiate(bulletPrefab,bulletSpawnLocation.position, bulletSpawnLocation.rotation.normalized);

       // bullet.AddComponent<Rigidbody>().velocity = bulletSpawnLocation.transform.forward * 10f;
        bulletCamera.Priority = 12;
        
        shooting = true;
        OnBulletFired?.Invoke();
    }

  
}
