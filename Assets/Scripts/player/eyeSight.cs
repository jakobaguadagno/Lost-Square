using UnityEngine;
using UnityEngine.InputSystem;

public class eyeSight : MonoBehaviour
{
    
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    public float fov = 90f;
    public float viewDistance = 2f;
    private float startingAngle;
    private int glassCount = 0;

    void Start() 
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate() 
    {
        Vector3 mPos = Mouse.current.position.ReadValue();
        mPos = Camera.main.ScreenToWorldPoint(mPos);
        float mAngleR = Mathf.Atan2(mPos.y - this.transform.position.y, mPos.x - this.transform.position.x);
        float mAngleD = (180 / Mathf.PI) * mAngleR + fov / 2f;
        this.transform.rotation = Quaternion.Euler(0, 0, mAngleD);

        int rayCount = 60;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = Vector3.zero;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) 
        {
            Vector3 vertex;
            vertex = Vector3.zero + AngToVec(angle) * viewDistance;
            vertices[vertexIndex] = vertex;

            if (i > 0) 
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 1000f);
        
    }
    
    private static Vector3 AngToVec(float angle)
    {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void GlassPickUp()
    {
        glassCount++;
        if(glassCount == 1)
        {
            fov = 60f;
            viewDistance = 3f;
        }
        if(glassCount == 2)
        {
            fov = 50f;
            viewDistance = 5f;
        }
        if(glassCount == 3)
        {
            fov = 60f;
            viewDistance = 10f;
        }
    }
}