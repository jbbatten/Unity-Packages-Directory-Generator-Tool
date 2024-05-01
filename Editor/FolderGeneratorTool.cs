using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Screen;

public class FolderGeneratorTool : EditorWindow
{
    private static string projectName = "PROJECT_NAME";

    [MenuItem("Assets/Create Default Folders")]
    private static void SetUpFolders()

    {
        FolderGeneratorTool window = CreateInstance<FolderGeneratorTool>();
        window.position = new Rect(width/2, height / 2, 400, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Insert the Project name used as the root folder");
        projectName = EditorGUILayout.TextField("Project Name:", projectName);

        Repaint();
        GUILayout.Space(70);

        if (GUILayout.Button("Generate"))
        {
            GenerateFolderStructure();
            Close();
        }
        
        // Add a close button:
        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }


    public void GenerateFolderStructure()
    {
        List<string> topLevelFolders = new()
        {
            "Animations",
            "Audio",
            "Editor",
            "Materials",
            "Meshes",
            "Particles",
            "Prefabs",
            "Scripts",
            "Settings",
            "Shaders",
            "Scenes",
            "Textures",
            "ThirdParty"
        };

        List<string> uiFolders = new List<string>()
        {
            "Assets",
            "Fonts",
            "Icon"
        };

        // Delete base folders.
        AssetDatabase.DeleteAsset("Assets/Scenes/");
        AssetDatabase.DeleteAsset("Assets/Resources/");

        foreach (string folder in topLevelFolders)

        {
            if (!Directory.Exists("Assets/" + projectName + "/" + folder))
            {
                Directory.CreateDirectory("Assets/" + projectName + "/" + folder);
            }
        }

        foreach (string subfolder in uiFolders)
        {
            if (!Directory.Exists("Assets/" + projectName + "/UI/" + subfolder))
            {
                Directory.CreateDirectory("Assets/" + projectName + "/UI/" + subfolder);
            }
        }

        AssetDatabase.Refresh();
    }
}