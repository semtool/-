using UnityEngine;

[RequireComponent(typeof(Multiplicator))]

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _chanceToDivide = 10;
    [SerializeField] private float _selfForce;

    public float ChanceToDivide => _chanceToDivide;

    private Multiplicator _multiplicator;
    private Material _color;
    private float _reductorOfProbability = 2;
    private float _increasorOfForce = 1.5f;
    private float _scale;
    private float _reductor = 2f;


    public void Awake()
    {
        _color = GetComponent<Renderer>().material;
        _multiplicator = GetComponent<Multiplicator>();
    }

    public void OnMouseUpAsButton()
    {
        _multiplicator.ClonObjects(_cube);
        _multiplicator.ExplodeCube(_selfForce);
    }

    public Cube CreateClon(float offset)
    {
        Cube clon = Instantiate(_cube, new Vector3(_cube.transform.position.x + offset, 0.5f, _cube.transform.position.z + offset), Quaternion.identity);
        clon.ChangeScale();
        clon.ChangeColor();
        clon.ReduceChance();
        clon.IncreaseSelfForce();

        return clon;
    }

    private void ChangeScale()
    {
        transform.localScale = Vector3.one * GetScale();
    }

    private void ChangeColor()
    {
        _color.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    private void ReduceChance()
    {
        _chanceToDivide /= _reductorOfProbability;
    }

    private void IncreaseSelfForce()
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