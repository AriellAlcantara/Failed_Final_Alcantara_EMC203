using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 moveDirection;
    private GameObject player;

    void Start()
    {
        CreateEnemyMesh();
        gameObject.AddComponent<MeshCollider>().convex = true;
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        moveDirection = (Vector3.zero - transform.position).normalized;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EnhancedMeshGenerator>().DamagePlayer(1);
        }
    }

    void CreateEnemyMesh()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3( 0.5f, -0.5f, -0.5f),
            new Vector3( 0.5f,  0.5f, -0.5f),
            new Vector3(-0.5f,  0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f,  0.5f),
            new Vector3( 0.5f, -0.5f,  0.5f),
            new Vector3( 0.5f,  0.5f,  0.5f),
            new Vector3(-0.5f,  0.5f,  0.5f)
        };

        mesh.triangles = new int[] {
            0, 2, 1, 0, 3, 2,
            1, 2, 6, 6, 5, 1,
            4, 5, 6, 6, 7, 4,
            2, 3, 7, 7, 6, 2,
            0, 7, 3, 0, 4, 7,
            0, 1, 5, 0, 5, 4
        };

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;

        meshRenderer.material = new Material(Shader.Find("Standard")) { color = Color.red };
    }
}
