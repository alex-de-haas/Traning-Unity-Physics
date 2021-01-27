using UnityEngine;

public class ColliderEvents : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"ENTER: {collision}");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"EXIT: {collision}");
    }

    void OnCollisionStay(Collision collision)
    {
        //Debug.Log($"STAY: {collision}");
    }
}
