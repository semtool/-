using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _strikeRadius;
    [SerializeField] private float _strikeForce;

    private Multiplicator _multiplicator;
    private float _delay = 1f;

    public void OnMouseUpAsButton()
    {
        StartCoroutine(DeleteObject());
    }

    private void Awake()
    {
        _multiplicator = GetComponent<Multiplicator>();
    }

    private IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(_cube);
        Explode();
    }

    private void Explode()
    {
        List<Cube> objects = _multiplicator.GetStruckObjects();
        List<Rigidbody> struckObjects = new();

        if (objects != null)
        {
            foreach (Cube element in objects)
            {
                Rigidbody body = element.GetComponent<Rigidbody>();
                body.AddExplosionForce(_strikeForce, transform.position, _strikeRadius);
                struckObjects.Add(body);
            }
        }
    }
}