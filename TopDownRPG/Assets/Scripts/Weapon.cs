using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public float weaponDemage;
    public float weaponSpeed;
    public float weaponRange;
    public float weaponLife;
    public Sprite weaponIcon;
    public string weaponName;
    public int weaponValue;
    public GameObject weaponProject;
    public AudioClip weaponSound;
    public float weaponSoundPitch;
}
