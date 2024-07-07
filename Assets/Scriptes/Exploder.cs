using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private float _strikeRadius;
    [SerializeField] private float _strikeForce;

    public void DeleteCube(List<Cube> objects, float force)
    {
        Destroy(_obj);

        if (objects != null)
        {
            ExplodeClonedCubes(objects);
        }
        else
        {
            ExplodeSomeCubes(force);
        }
    }

    private void ExplodeClonedCubes(List<Cube> discardedCubes)
    {
        if (discardedCubes != null)
        {
            foreach (Cube element in discardedCubes)
            {
                Rigidbody body = element.GetComponent<Rigidbody>();
                body.AddExplosionForce(_strikeForce, transform.position, _strikeRadius, 0.5f, ForceMode.Force);
            }
        }
    }

    private void ExplodeSomeCubes(float force)
    {
        foreach (Rigidbody body in GetSomeCubes())
        {
            body.AddExplosionForce(force, transform.position, _strikeRadius);
        }
    }

    private List<Rigidbody> GetSomeCubes()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _strikeRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}