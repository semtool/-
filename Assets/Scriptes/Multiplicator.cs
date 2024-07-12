using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]

public class Multiplicator : MonoBehaviour
{
    private Cube _cube;
    private List<Cube> _cubes;
    private float _minProbabilityToDivide = 0;
    private float _maxProbabilityToDivide = 10;
    private int _minNumberOfObjects = 2;
    private int _maxNumberOfObjects = 6;

    public List<Cube> Cubes => _cubes;

    public void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private int GetRandomNumberOfObjects()
    {
        return Random.Range(_minNumberOfObjects, _maxNumberOfObjects);
    }

    private float GetProbabilityToDivide()
    {
        return Random.Range(_minProbabilityToDivide, _maxProbabilityToDivide);
    }

    public void ClonObjects()
    {
        if (GetProbabilityToDivide() <= _cube.ChanceToDivide)
        {
            CreateClones();
        }
    }

    private void CreateClones()
    {
        int numberOfObjects = GetRandomNumberOfObjects();

        _cubes = new List<Cube>();

        for (int i = 0; i <= numberOfObjects; i++)
        {
            _cubes.Add(_cube.Initialize());
        }
    }
}