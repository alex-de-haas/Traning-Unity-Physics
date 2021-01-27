using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Vector3 Offset = Vector3.zero;

    public GameObject Cube;

    public Material[] Materials;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (float x = 0; x < 10; x++)
            {
                for (float y = 0; y < 10; y++)
                {
                    for (float z = 0; z < 10; z++)
                    {
                        var cube = Instantiate(Cube, new Vector3(x, y + 0.5f, z) + Offset, Quaternion.identity);
                        cube.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length - 1)];
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            var position = new Vector3(5f, 5.5f, 5f) + Offset;
            var colliders = Physics.OverlapSphere(position, 10);
            foreach (var collider in colliders)
            {
                var rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(10000 * (1 / Time.timeScale), position, 10);
                }
            }
        }
    }
}
