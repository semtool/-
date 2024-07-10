using UnityEngine;

[RequireComponent(typeof(Multiplicator))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceToDivide = 10;
    [SerializeField] private float _selfForce;

    private Material _color;
    private Multiplicator _multiplicator;
    private Exploder _exploder;
    private float _reductorOfProbability = 2;
    private float _increasorOfForce = 1.5f;
    private float _scale;
    private float _reductor = 2f;

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

    public void ChangeScale()
    {
        transform.localScale = Vector3.one * GetScale();
    }

    public void ChangeColor()
    {
        _color.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    public void ReduceChance()
    {
        _chanceToDivide /= _reductorOfProbability;
    }

    public void IncreaseSelfForce()
    {
        _selfForce *= _increasorOfForce;
    }

    private float GetScale()
    {
        _scale = transform.localScale.y;
        return _scale / _reductor;
    }

    private float GetConponentOfColor()
    {
        return Random.Range(0, 1f);
    }
}