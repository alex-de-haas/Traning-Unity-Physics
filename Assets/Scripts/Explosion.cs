using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Vector3 Offset = Vector3.zero;
    public float ExplosionForce = 10000;
    public float ExplosionRadius = 10;
    public int Size = 10;

    public GameObject Cube;

    public Material[] Materials;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (float x = 0; x < Size; x++)
            {
                for (float y = 0; y < Size; y++)
                {
                    for (float z = 0; z < Size; z++)
                    {
                        var cube = Instantiate(Cube, new Vector3(x, y + 0.5f, z) + Offset, Quaternion.identity);
                        cube.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length - 1)];
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            var position = new Vector3(Size / 2, Size / 2 + 0.5f, Size / 2) + Offset;
            var colliders = Physics.OverlapSphere(position, ExplosionRadius);
            foreach (var collider in colliders)
            {
                var rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(ExplosionForce * (1 / Time.timeScale), position, ExplosionRadius);
                }
            }
        }
    }
}
