using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DeleteSave))]
public class DeleteSaveEditor : Editor {

    // Use this for initialization
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DeleteSave myScript = (DeleteSave)target;
        if (GUILayout.Button("DeleteSaves"))
        {
            myScript.DeleteAll();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
