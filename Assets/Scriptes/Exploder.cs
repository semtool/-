using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private float _strikeRadius;
    [SerializeField] private float _strikeForce;

    public void DeleteCube(List<Cube> objects)
    {
        Destroy(_obj);
        Explode(objects);
    }

    private void Explode(List<Cube> discarded—ubes)
    {
        List<Rigidbody> struckObjects = new();

        if (discarded—ubes != null)
        {
            foreach (Cube element in discarded—ubes)
            {
                Rigidbody body = element.GetComponent<Rigidbody>();
                body.AddExplosionForce(_strikeForce, transform.position, _strikeRadius);
                struckObjects.Add(body);
            }
        }
    }
}