using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSavePrefab : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            GameObject treePrefab = PrefabUtility.SaveAsPrefabAsset(go, Application.dataPath+"/"+ go.name + ".prefab");
        }
    }
}
