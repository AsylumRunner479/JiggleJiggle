using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellifer : MonoBehaviour
{
    public float bounceSpeed;
    public float stiffness;
    public float fallForce;
    private MeshFilter meshFilter;
    private Mesh mesh;
    Jelly[] jelly;
    Vector3[] currentMeshVertices;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        GetVertices();
    }
    private void GetVertices()
    {
        jelly = new Jelly[mesh.vertices.Length];
        currentMeshVertices = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            jelly[i] = new Jelly(i, mesh.vertices[i], mesh.vertices[i], Vector3.zero);
            currentMeshVertices[i] = mesh.vertices[i];
        }
    }
    private void UpdateVertices()
    {
        for (int i = 0; i < jelly.Length; i++)
        {
            jelly[i].UpdateVelocity(bounceSpeed);
            jelly[i].Settle(stiffness);
            jelly[i].currentVertexPosition += jelly[i].currentVelocity * Time.deltaTime;
            currentMeshVertices[i] = jelly[i].currentVertexPosition;
        }
        mesh.vertices = currentMeshVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

    }
    // Update is called once per frame
    void Update()
    {
        UpdateVertices();
    }
}
