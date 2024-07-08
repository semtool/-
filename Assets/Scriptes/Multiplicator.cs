using System.Collections.Generic;
using UnityEngine;

public class Multiplicator : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private Exploder _exploder;
    private List<Cube> _cubes;
    private float _maxNumber = 0;
    private float _minNumber = 10;
    private float _randomNumber;
    private float _minCoordinateOfPosition = -1;
    private float _maxCoordinateOfPosition = 1;
    private int _minNumberOfObjects = 2;
    private int _maxNumberOfObjects = 6;

    public void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    public void ExplodeCube(float force)
    {
        _exploder.DeleteCube(_cubes, force);
    }

    public void ClonObjects(Cube cube)
    {
        _randomNumber = GetRandomNumber();

        if (_randomNumber <= cube.ChanceToDivide)
        {
            CreateClones(cube);
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

    private void CreateClones(Cube cube)
    {
        int numberOfObjects = GetRandomNumberOfObjects();

        _cubes = new List<Cube>();

        for (int i = 0; i <= numberOfObjects; i++)
        {
            _cubes.Add(cube.CreateClon(GetRandomPosition()));
        }
    }

    private float GetRandomPosition()
    {
        return Random.Range(_minCoordinateOfPosition, _maxCoordinateOfPosition);
    }
}