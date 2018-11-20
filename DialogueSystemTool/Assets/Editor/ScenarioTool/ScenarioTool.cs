using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScenarioTool : EditorWindow{

    private DialogueSystemContainer dsContainer;
    private ChaptersLayout chapterLayout = new ChaptersLayout();
    private List<bool> foldouts = new List<bool>();
    private Vector2 scrollPos;

    [MenuItem("Custom Tools/Scenario Tool")]
    public static void DisplayWindow()
    {
        GetWindow<ScenarioTool>("Scenario Tool");
    }

    private void OnGUI()
    {
        DrawTop();
        DrawBody();
        DrawBottom();
    }

    private void DrawTop()
    {
        GUILayout.Label("Chapters", EditorStyles.boldLabel);

        UIHelper.DrawUILine(Color.black);
    }

    private void DrawBody()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        
        if (dsContainer == null)
        {
            dsContainer = new DialogueSystemContainer {
                Chapters = new List<Chapter>()
            };
        }
        
        if (GUILayout.Button("Add Chapter", GUILayout.MaxWidth(160)))
        {
            dsContainer.Chapters.Add(new Chapter
            {
                ID = "ChapterID",
                Scenes = new List<Scene>()
            });

            foldouts.Add(false);
        }

        if (GUILayout.Button("Remove Last Chapter", GUILayout.MaxWidth(160)))
        {
            if (dsContainer.Chapters.Count > 0)
            {
                var lastChapter = dsContainer.Chapters.Count - 1;

                dsContainer.Chapters.RemoveAt(lastChapter);
                foldouts.RemoveAt(lastChapter);
            }
        }

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.MaxWidth(1920));

        chapterLayout.DrawChapters(dsContainer.Chapters, foldouts);

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }

    private void DrawBottom()
    {
        UIHelper.DrawUILine(Color.black);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Export"))
        {
            SavePrompt();
        }

        if (GUILayout.Button("Import"))
        {
            LoadPrompt();
        }
        GUILayout.EndHorizontal();
    }

    private void SavePrompt()
    {
        var path = EditorUtility.SaveFilePanel(
                    "Save File",
                    Application.streamingAssetsPath,
                    ".xml",
                    "xml"
                    );

        if(path.Length != 0)
            SavingSystem.SaveDialogue(path, dsContainer);
    }

    private void LoadPrompt()
    {
        var path = EditorUtility.OpenFilePanel(
                    "Select File",
                    Application.streamingAssetsPath,
                    "xml"
                    );

        if (path.Length != 0)
        {
            dsContainer = SavingSystem.LoadDialogue(path);

            foldouts = new List<bool>();

            foreach(var chapter in dsContainer.Chapters)
            {
                foldouts.Add(false);
            }
        }
    }
}