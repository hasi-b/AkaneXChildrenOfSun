using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnBulletMode;
    public static event Action OnExitBulletMode;
    public static GameManager Instance;
    public int EnemyCount = 0;
    [SerializeField]
    BulletSpawner bulletMode;
    [SerializeField]
    ThirdPersonController thirdPersonController;
    [SerializeField]
    FirstPersonController firstPersonController;
    [SerializeField]
    CinemachineBrain brain;
    [SerializeField]
    CinemachineVirtualCamera firstPersonCamera;
    [SerializeField]
    Camera mainCamera;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        bulletMode.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableBulletMode();
        }
        if (EnemyCount>6)
        {
            ExitbulletMode();   
        }
    }

    void EnableBulletMode()
    {
        OnBulletMode?.Invoke();
        mainCamera.orthographic = false;
        thirdPersonController.enabled = false;
        thirdPersonController.gameObject.SetActive(false);
        firstPersonController.gameObject.transform.position = thirdPersonController.gameObject.transform.position;
        firstPersonController.gameObject.SetActive(true);

        firstPersonCamera.Priority = 12;

        bulletMode.enabled = true;
    }

    void ExitbulletMode()
    {
        OnExitBulletMode?.Invoke();
        mainCamera.orthographic = true;
        firstPersonController.gameObject.SetActive(false);
        thirdPersonController.gameObject.transform.position = firstPersonController.gameObject.transform.position;
        thirdPersonController.enabled = true;
        thirdPersonController.gameObject.SetActive(true);
      
        

        firstPersonCamera.Priority = 10;

        bulletMode.enabled = false;
    }
}
