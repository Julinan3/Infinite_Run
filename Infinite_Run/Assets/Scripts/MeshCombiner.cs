using System;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    //ana platformun altındaki meshleri birlestiren kod
    private void Start()
    {
        CombineMeshes();
    }
    private void CombineMeshes()
    {
        Quaternion oldRotation = transform.rotation;
        Vector3 oldPosition = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        for (int i = 0; i < meshFilters.Length - 1; i++)
        {
            meshFilters[i] = meshFilters[i + 1];
        }
        Array.Resize(ref meshFilters, meshFilters.Length - 1);

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].transform == transform)
            {
                continue;
            }
            combine[i].subMeshIndex = 0;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        Mesh lastMesh = new Mesh();
        lastMesh.CombineMeshes(combine);

        GetComponent<MeshFilter>().sharedMesh = lastMesh;
        GetComponent<MeshCollider>().sharedMesh = lastMesh;

        lastMesh.name = meshFilters.Length.ToString() + " Combined Meshes";

        transform.rotation = oldRotation;
        transform.position = oldPosition;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
