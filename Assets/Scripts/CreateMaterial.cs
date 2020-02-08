using System;
using UnityEditor;
using UnityEngine;

public class CreateMaterial : MonoBehaviour
{
    [MenuItem("Assets/Create Material with Texture")]
    static void CMT()
    {
        string SelectedTexturePath = AssetDatabase.GetAssetPath(Selection.activeObject);
        int i = SelectedTexturePath.LastIndexOf("/");
        string FolderPath = i != -1 ? SelectedTexturePath.Substring(0, i + 1) : throw new Exception("Alien path!");
        Material material = new Material(Shader.Find("Standard (Specular setup)"))
        {
            name = Selection.activeObject.name,
            mainTexture = Selection.activeObject as Texture
        };
        material.SetFloat("_Glossiness", 0f);
        material.SetColor("_SpecColor", Color.black);
        AssetDatabase.CreateAsset(material, FolderPath + Selection.activeObject.name + ".mat");
    }

    [MenuItem("Assets/Create Material with Texture", true)]
    static bool ValidateContextMenuItem()
    {
        return Selection.activeObject is Texture;
    }
}
