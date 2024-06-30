using UnityEngine;

public class Colorer : MonoBehaviour
{
    public void ChangeColor(Cube _obj)
    {
        _obj.GetComponent<Renderer>().material.color = new Color(GetConponentOfColor(), GetConponentOfColor(), GetConponentOfColor());
    }

    private float GetConponentOfColor()
    {
        return Random.Range(0, 1f);
    }
}
