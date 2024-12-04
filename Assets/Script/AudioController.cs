using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo,  enemyHurt, gunShot, gunShot2, gunPickup, gunSwitch, health, playerHurt, armor, keyGrab, background;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAmmo()
    {
        ammo.Stop();
        ammo.Play();
    }

    public void PlayEnemyHurt()
    {
        enemyHurt.Play();
    }

    public void PlayGunShot()
    {
        gunShot.Play();
    }

    public void PlayHealth()
    {
        health.Stop();
        health.Play();
    }

    public void PlayArmor()
    {
        armor.Stop();
        armor.Play();
    }

    public void PlayKeyGrab()
    {
        keyGrab.Stop();
        keyGrab.Play();
    }

    public void PlayHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }

    public void StopBGM()
    {
        background.Stop();
    }

    public void PlayGunShoot2()
    {
        gunShot2.Play();
    }

    public void PlayGunSwitch()
    {
        gunSwitch.Play();
    }

    public float PlayGunPickUp()
    {
        gunPickup.Play();
        AudioClip clip = gunPickup.clip;
        float duration = clip.length;
        return duration;
    }
}
