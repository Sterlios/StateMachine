using System.Collections;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    private void Start()
    {
        _direction = _direction.normalized;

        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        bool isWorking = true;

        while (isWorking)
        {
            transform.Rotate(_speed * Time.deltaTime * _direction);

            yield return null;
        }
    }
}
