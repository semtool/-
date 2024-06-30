using UnityEngine;

public class Scaler : MonoBehaviour
{
    private float _scale;
    private float _reductor = 2f;

    public void ChangeScale(Cube obj)
    {
        obj.transform.localScale = Vector3.one * GetScale(obj);
    }

    private float GetScale(Cube obj)
    {
        _scale = obj.transform.localScale.y;
        return _scale / _reductor;
    }
}