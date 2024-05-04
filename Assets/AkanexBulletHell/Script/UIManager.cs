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
        BulletHitSystem.OnBulletHit += Bullethit;
        GameManager.OnBulletMode += BulletMode;
        GameManager.OnExitBulletMode += BulletFired;
    }

    

    private void OnDisable()
    {
        BulletSpawner.OnBulletFired -= BulletFired;
        BulletHitSystem.OnBulletHit -= Bullethit;
        GameManager.OnBulletMode -= BulletMode;
        GameManager.OnExitBulletMode -= BulletFired;
    }
    private void BulletFired()
    {
        crossHair.SetActive(false);
        
    }
    private void Bullethit()
    {
        crossHair.SetActive(true);
        
    }

    private void BulletMode()
    {
        crossHair.SetActive(true);
    }
}
