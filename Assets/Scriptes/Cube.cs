using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Multiplicator))]
[RequireComponent(typeof(Exploder))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _selfForce;

    private Material _color;
    private Multiplicator _multiplicator;
    private Exploder _exploder;
    private float _chanceToDivide = 10;
    private float _reductorOfProbability = 2;
    private float _increasorOfForce = 1.5f;
    private float _scale;
    private float _reductor = 2f;
    private float _minCoordinateOfPosition = -1;
    private float _maxCoordinateOfPosition = 1;

    public float ChanceToDivide => _chanceToDivide;

    public void Awake()
    {
        _color = GetComponent<Renderer>().material;
        _multiplicator = GetComponent<Multiplicator>();
        _exploder = GetComponent<Exploder>();
    }

    public void OnMouseUpAsButton()
    {
        _multiplicator.ClonObjects();
        _exploder.DeleteCube(_multiplicator.Cubes, _selfForce);
    }

    public Cube Initialize()
    {
        Cube clon = Instantiate(this, new Vector3(gameObject.transform.position.x + GetRandomPosition(), 0.5f, gameObject.transform.position.z + GetRandomPosition()), Quaternion.identity);

        ChangeClonParameters(clon);

        return clon;
    }

    private void ChangeClonParameters(Cube clon)
    {
        clon.ChangeScale();
        clon.ChangeColor();
        clon.ReduceChance();
        clon.IncreaseSelfForce();
    }

    private void ChangeScale()
    {
        transform.localScale = Vector3.one * GetScale();
    }

    private float GetScale()
    {
        _scale = transform.localScale.y;
        return _scale / _reductor;
    }

    private void ChangeColor()
    {
        _color.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    private float GetConponentOfColor()
    {
        return Random.Range(0, 1f);
    }

    private void ReduceChance()
    {
        _chanceToDivide /= _reductorOfProbability;
    }

    private void IncreaseSelfForce()
    {
        _selfForce *= _increasorOfForce;
    }

    private float GetRandomPosition()
    {
        return Random.Range(_minCoordinateOfPosition, _maxCoordinateOfPosition);
    }
}