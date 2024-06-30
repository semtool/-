using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private float _chanceToDivide = 10;
    private float _reductorOfProbability = 2;
    private float _scale;
    private float _reductor = 2f;

    public void ChangeScale()
    {
        _cube.transform.localScale = Vector3.one * GetScale();
    }
    public void ChangeColor()
    {
        _cube.GetComponent<Renderer>().material.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    public void CangeChance()
    {
        _chanceToDivide /= _reductorOfProbability;
    }

    public float GetChance()
    {
        return _chanceToDivide;
    }

    private float GetScale()
    {
        _scale = _cube.transform.localScale.y;
        return _scale / _reductor;
    }

    private float GetConponentOfColor()
    {
        return Random.Range(0, 1f);
    }
}