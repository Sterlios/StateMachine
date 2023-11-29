using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Scalable : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    private void Start()
    {
        _direction = _direction.normalized;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        bool isWorking = true;

        while (isWorking)
        {
            transform.localScale += _speed * Time.deltaTime * _direction;

            yield return null;
        }
    }
}
