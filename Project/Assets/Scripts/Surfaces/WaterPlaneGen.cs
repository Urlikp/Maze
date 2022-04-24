using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGen : MonoBehaviour
{
    public float size = 1f;
    public int gridSize = 16;

    MeshFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    //Generates a plane with specified dimensions
    private Mesh GenerateMesh()
    {
        Mesh m = new Mesh();

        var vertecies = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        var vertCount = gridSize + 1;

        for (int x = 0; x < vertCount; x++)
        {
            for (int y = 0; y < vertCount; y++)
            {
                vertecies.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        
        for (int i = 0; i < vertCount * (vertCount - 1); i++)
        {
            if((i + 1) % vertCount == 0) continue;
            triangles.AddRange(new List<int>()
            {
                i + 1 + vertCount, i + vertCount, i,
                i, i + 1, i + vertCount + 1
            });
        }

        m.SetVertices(vertecies);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);

        return m;
    }
}
