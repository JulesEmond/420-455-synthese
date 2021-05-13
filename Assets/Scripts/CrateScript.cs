using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrateScript : MonoBehaviour
{
    [SerializeField] private AudioClip revolverClip;
    [SerializeField] private AudioClip smgClip;
    [SerializeField] private AudioClip sniperClip;
    [SerializeField] private AudioClip lmgClip;

    [SerializeField] private PlayerWeaponScript _playerWeaponScript;
    [SerializeField] private Sprite revolverSprite;
    [SerializeField] private Sprite smgSprite;
    [SerializeField] private Sprite lmgSprite;
    [SerializeField] private Sprite sniperSprite;

    [SerializeField] private GameObject weapon;
    
    private SpriteRenderer _gunRenderer;
    
    private AudioSource[] audios;
    
    
    private AudioSource gunShotClip;
    private AudioSource cockBullet;


    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = weapon.GetComponent<SpriteRenderer>();
        audios = weapon.GetComponents<AudioSource>();

        gunShotClip = audios[0];
        cockBullet = audios[2];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var randomGunId = Random.Range(1, 5);
            Destroy(gameObject);
            switch (randomGunId)
            {
                case 1:
                    _gunRenderer.sprite = revolverSprite;
                    cockBullet.mute = false;
                    gunShotClip.clip = revolverClip;
                    _playerWeaponScript.timeBetweenShots = 30;
                    _playerWeaponScript.waitingTimeForNextBullet = 30;
                    _playerWeaponScript.numberOfBulletsLeft = 6;
                    _playerWeaponScript.totalBullets = 6;
                    _playerWeaponScript.reloading = 0;
                    _playerWeaponScript.reloadTime = 100;
                    _playerWeaponScript.offSetX = 0.87f;
                    _playerWeaponScript.offSetBullet = 0.25f;
                    _playerWeaponScript.bulletDestroyTime = 0.20f;
                    _playerWeaponScript.offSetHipFire = 0f;
                    break;
            
                case  2:
                    _gunRenderer.sprite = smgSprite;
                    cockBullet.mute = true;
                    gunShotClip.clip = smgClip;
                    _playerWeaponScript.timeBetweenShots = 20;
                    _playerWeaponScript.waitingTimeForNextBullet = 20;
                    _playerWeaponScript.numberOfBulletsLeft = 32;
                    _playerWeaponScript.totalBullets = 32;
                    _playerWeaponScript.reloading = 0;
                    _playerWeaponScript.reloadTime = 50;
                    _playerWeaponScript.offSetX = 0.17f;
                    _playerWeaponScript.offSetBullet = 1f;
                    _playerWeaponScript.bulletDestroyTime = 0.15f;
                    _playerWeaponScript.offSetHipFire = 15f;
                    break;
            
                case 3:
                    _gunRenderer.sprite = lmgSprite;
                    cockBullet.mute = true;
                    gunShotClip.clip = lmgClip;
                    _playerWeaponScript.timeBetweenShots = 15;
                    _playerWeaponScript.waitingTimeForNextBullet = 15;
                    _playerWeaponScript.numberOfBulletsLeft = 30;
                    _playerWeaponScript.totalBullets = 30;
                    _playerWeaponScript.reloading = 0;
                    _playerWeaponScript.reloadTime = 300;
                    _playerWeaponScript.offSetX = 0f;
                    _playerWeaponScript.offSetBullet = 1.25f;
                    _playerWeaponScript.bulletDestroyTime = 0.30f;
                    _playerWeaponScript.offSetHipFire = 20f;
                    break;
            
                case  4:
                    _gunRenderer.sprite = sniperSprite;
                    cockBullet.mute = false;
                    gunShotClip.clip = sniperClip;
                    _playerWeaponScript.timeBetweenShots = 40;
                    _playerWeaponScript.waitingTimeForNextBullet = 40;
                    _playerWeaponScript.numberOfBulletsLeft = 10;
                    _playerWeaponScript.totalBullets = 10;
                    _playerWeaponScript.reloading = 0;
                    _playerWeaponScript.reloadTime = 200;
                    _playerWeaponScript.offSetX = 0f;
                    _playerWeaponScript.offSetBullet = 1.25f;
                    _playerWeaponScript.bulletDestroyTime = 0.50f;
                    _playerWeaponScript.offSetHipFire = 0f;
                    break;
            } 
        }
        
    }
}
