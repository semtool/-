using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Multiplicator : MonoBehaviour
{
    [SerializeField] private Cube _obj;

    private List<Cube> _cubes;
    private Cube _cube;
    private float _maxNumber = 0;
    private float _minNumber = 10;
    private float _currentChance;
    private float _randomNumber;
    private float _minCoordinateOfPosition = -1;
    private float _maxCoordinateOfPosition = 1;
    private int _minNumberOfObjects = 2;
    private int _maxNumberOfObjects = 7;
    private int _counterOfObjects;
    private float _delay = 0;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void OnMouseUpAsButton()
    {
        StartCoroutine(ClonObjects());
    }

    public List<Cube> GetStruckObjects()
    {
        return _cubes;
    }

    private int GetRandomNumberOfObjects()
    {
        return Random.Range(_minNumberOfObjects, _maxNumberOfObjects);
    }

    private float GetRandomNumber()
    {
        return Random.Range(_minNumber, _maxNumber);
    }

    private IEnumerator ClonObjects()
    {
        yield return new WaitForSeconds(_delay);

        _currentChance = _cube.GetChance();
        _randomNumber = GetRandomNumber();

        if (_randomNumber <= _currentChance)
        {
            CreateClones();
        }
    }

    private void CreateClones()
    {
        int numberOfObjects = GetRandomNumberOfObjects();

        _cubes = new List<Cube>();

        while (_counterOfObjects < numberOfObjects)
        {
            _cubes.Add(CreateClon());
            _counterOfObjects++;
        }
    }

    public float GetRandomPosition()
    {
        return Random.Range(_minCoordinateOfPosition, _maxCoordinateOfPosition);
    }

    public Cube CreateClon()
    {
        Cube clon = Instantiate(_obj, new Vector3(_obj.transform.position.x + GetRandomPosition(), 0.5f, _obj.transform.position.z + GetRandomPosition()), Quaternion.identity);
        clon.ChangeScale();
        clon.ChangeColor();
        clon.CangeChance();

        return clon;
    }
}