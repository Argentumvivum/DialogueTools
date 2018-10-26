using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScenesLayout
{
    private ConversationsLayout conversationsLayout = new ConversationsLayout();
    public void DrawScenes(List<Scene> scenes)
    {
        GUILayout.Label("Scenes", EditorStyles.boldLabel);

        UIHelper.DrawUILine(Color.blue);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical();
        DrawTop(scenes);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();
        for (int i = 0; i < scenes.Count; i++)
        {
            scenes[i].ID = EditorGUILayout.TextField("Scene " + (i + 1), scenes[i].ID, GUILayout.MaxWidth(400));
            conversationsLayout.DrawConversations(scenes[i].Conversations);
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
        UIHelper.DrawUILine(Color.black);
    }

    public void DrawTop(List<Scene> scenes)
    {
        if (GUILayout.Button("Add Scene", GUILayout.MaxWidth(160)))
        {
            scenes.Add(new Scene
            {
                ID = "SceneID",
                Conversations = new List<Conversation>()
            });
        }

        if (GUILayout.Button("Remove Last Scene", GUILayout.MaxWidth(160)))
        {
            if (scenes.Count > 0)
                scenes.RemoveAt(scenes.Count - 1);
        }
    }
}
