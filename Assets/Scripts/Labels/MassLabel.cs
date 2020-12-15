using UnityEngine;

public class MassLabel : BaseLabel
{
    public Rigidbody Rigidbody;

    protected override string GetLabelText()
    {
        return $"{Rigidbody.mass}";
    }
}
