using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _chanceToDivide = 10;
    [SerializeField] private float _selfForce;

    private Multiplicator _multiplicator;
    private float _reductorOfProbability = 2;
    private float _increasorOfForce = 1.5f;
    private float _scale;
    private float _reductor = 2f;

    public void Awake()
    {
        _multiplicator = GetComponent<Multiplicator>();
    }

    public void OnMouseUpAsButton()
    {
        _multiplicator.ClonObjects();
        _multiplicator.ExplodeCube(_selfForce);
    }

    public void ChangeScale()
    {
        transform.localScale = Vector3.one * GetScale();
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    public void ReduceChance()
    {
        _chanceToDivide /= _reductorOfProbability;
    }
   
    public float GetChance()
    {
        return _chanceToDivide;
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