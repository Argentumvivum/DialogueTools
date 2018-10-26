using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChaptersLayout
{
    private ScenesLayout scenesLayout = new ScenesLayout();

    public void DrawChapters(List<Chapter> chapters, List<bool> foldouts)
    {
        for (int i = 0; i < chapters.Count; i++)
        {
            foldouts[i] = EditorGUILayout.Foldout(foldouts[i], chapters[i].ID);

            if(foldouts[i])
            {
                EditorGUILayout.Space();
                chapters[i].ID = EditorGUILayout.TextField("ChapterID", chapters[i].ID, GUILayout.MaxWidth(400));
                scenesLayout.DrawScenes(chapters[i].Scenes);
            }
        }
    }
}
