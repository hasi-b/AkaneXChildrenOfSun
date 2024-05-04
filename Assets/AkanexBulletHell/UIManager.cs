using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject crossHair;
    private void OnEnable()
    {
        BulletSpawner.OnBulletFired += BulletFired;
        BulletProjectile.OnBulletHit += Bullethit;
    }

    

    private void OnDisable()
    {
        BulletSpawner.OnBulletFired -= BulletFired;
        BulletProjectile.OnBulletHit -= Bullethit;
    }
    private void BulletFired()
    {
        crossHair.SetActive(false);
        
    }
    private void Bullethit()
    {
        crossHair.SetActive(true);
        
    }
}
