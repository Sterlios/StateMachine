using System.Collections;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        bool isWorking = true;

        while (isWorking)
        {
            transform.position += transform.forward * Time.deltaTime;

            yield return null;
        }
    }
}
