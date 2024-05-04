using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitSystem : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    public static event Action OnBulletHit;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody.velocity = transform.forward*10f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("true");
            BulletSpawner.shooting = false;
            BulletSpawner.Instance.fpsController.enabled = true;
            BulletSpawner.Instance.fpsController.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y-1f, other.transform.position.z) ;
            GameManager.Instance.EnemyCount++;
            
            OnBulletHit?.Invoke();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }
    }

}
