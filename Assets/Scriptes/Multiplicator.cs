using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]

public class Multiplicator : MonoBehaviour
{
    private Cube _cube;
    private List<Cube> _cubes;
    private float _maxNumber = 0;
    private float _minNumber = 10;
    private float _minCoordinateOfPosition = -1;
    private float _maxCoordinateOfPosition = 1;
    private int _minNumberOfObjects = 2;
    private int _maxNumberOfObjects = 6;

    public List<Cube> Cubes => _cubes;

    public void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void ClonObjects()
    {
        if (GetRandomNumber() <= _cube.ChanceToDivide)
        {
            CreateClones();
        }
    }

    private int GetRandomNumberOfObjects()
    {
        return Random.Range(_minNumberOfObjects, _maxNumberOfObjects);
    }

    private float GetRandomNumber()
    {
        return Random.Range(_minNumber, _maxNumber);
    }

    private void CreateClones()
    {
        int numberOfObjects = GetRandomNumberOfObjects();

        _cubes = new List<Cube>();

        for (int i = 0; i <= numberOfObjects; i++)
        {
            _cubes.Add(CreateClon(GetRandomPosition()));
        }
    }

    private Cube CreateClon(float offset)
    {
        Cube clon = Instantiate(_cube, new Vector3(_cube.transform.position.x + offset, 0.5f, _cube.transform.position.z + offset), Quaternion.identity);
        clon.ChangeScale();
        clon.ChangeColor();
        clon.ReduceChance();
        clon.IncreaseSelfForce();

        return clon;
    }

    private float GetRandomPosition()
    {
        return Random.Range(_minCoordinateOfPosition, _maxCoordinateOfPosition);
    }
}