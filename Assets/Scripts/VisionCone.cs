using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public Material VisionConeMaterial;
    public float VisionRange;
    public float VisionAngle;
    public LayerMask VisionObstructingLayer;
    public LayerMask PlayerLayer;
    public int VisionConeResolution = 120;
    public float DetectionRate = 1f; // Rate at which detection meter increases
    public float DetectionDecreaseRate = 0.5f; // Rate at which detection meter decreases
    public float MaxDetection = 100f; // Maximum detection meter value

    private float currentDetection = 0f;
    private Mesh VisionConeMesh;
    private MeshFilter MeshFilter_;
    private float detectionTimer = 0f;
    private float detectionInterval = 1f; // Debug output interval in seconds

    void Start()
    {
        transform.AddComponent<MeshRenderer>().material = VisionConeMaterial;
        MeshFilter_ = transform.AddComponent<MeshFilter>();
        VisionConeMesh = new Mesh();
        VisionAngle *= Mathf.Deg2Rad;
    }

    void Update()
    {
        AdjustDetection();
        DrawVisionCone();
        UpdateDetectionDebug();
    }

    void AdjustDetection()
    {
        // Decrease detection meter when colliding with player layer
        if (currentDetection > 0)
        {
            currentDetection -= DetectionDecreaseRate * Time.deltaTime;
            currentDetection = Mathf.Clamp(currentDetection, 0f, MaxDetection);
        }
    }

    void DrawVisionCone()
    {
        int[] triangles = new int[(VisionConeResolution - 1) * 3];
        Vector3[] Vertices = new Vector3[VisionConeResolution + 1];
        Vertices[0] = Vector3.zero;
        float Currentangle = -VisionAngle / 2;
        float angleIncrement = VisionAngle / (VisionConeResolution - 1);
        float Sine;
        float Cosine;

        for (int i = 0; i < VisionConeResolution; i++)
        {
            Sine = Mathf.Sin(Currentangle);
            Cosine = Mathf.Cos(Currentangle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, RaycastDirection, out hit, VisionRange))
            {
                Vertices[i + 1] = VertForward * hit.distance;

                // Check if the collider hit belongs to the obstructing layer
                if (((1 << hit.collider.gameObject.layer) & VisionObstructingLayer) != 0)
                {
                    // Increase detection meter if the collider hit belongs to the obstructing layer
                    currentDetection += DetectionRate * Time.deltaTime;
                    currentDetection = Mathf.Clamp(currentDetection, 0f, MaxDetection);
                }
                else if (hit.collider.gameObject.layer == PlayerLayer)
                {
                    // Decrease detection meter while colliding with player layer
                    AdjustDetection();
                }
            }
            else
            {
                Vertices[i + 1] = VertForward * VisionRange;
            }

            Currentangle += angleIncrement;
        }

        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }

        VisionConeMesh.Clear();
        VisionConeMesh.vertices = Vertices;
        VisionConeMesh.triangles = triangles;
        MeshFilter_.mesh = VisionConeMesh;

        // Here, you can use 'currentDetection' as needed for your detection logic.
    }

    void UpdateDetectionDebug()
    {
        detectionTimer += Time.deltaTime;
        if (detectionTimer >= detectionInterval)
        {
            //Debug.Log("Detection: " + currentDetection);
            detectionTimer = 0f;
        }
    }
}
