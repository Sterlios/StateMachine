using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour 
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;

    public Bullet Bullet => _bullet;
    public float Delay => _delay;
    public abstract void Shoot();

}
