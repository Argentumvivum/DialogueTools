using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialoguesLayout
{
	public void DrawDialogue(List<Sentence> sentences)
    {
        GUILayout.Label("Sentences", EditorStyles.boldLabel);

        UIHelper.DrawUILine(Color.blue);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical();
        DrawTop(sentences);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();
        for (int i = 0; i < sentences.Count; i++)
        {
            if (i != 0)
                UIHelper.DrawUILine(Color.gray);

            GUILayout.Label("Person " + (i + 1), EditorStyles.boldLabel);
            sentences[i].Person.ID = EditorGUILayout.TextField("Person ID", sentences[i].Person.ID, GUILayout.MaxWidth(400));
            sentences[i].Words = EditorGUILayout.TextField("Sentence", sentences[i].Words, GUILayout.MaxWidth(400));
            sentences[i].Gesture = EditorGUILayout.TextField("Gesture", sentences[i].Gesture, GUILayout.MaxWidth(400));
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
        UIHelper.DrawUILine(Color.black);
    }

    private void DrawTop(List<Sentence> sentences)
    {
        if (GUILayout.Button("Add Sentence", GUILayout.MaxWidth(160)))
        {
            sentences.Add(new Sentence
            {
                Person = new Character() { ID = "PersonID" },
                Words = "What does he say.",
                Gesture = "What gesture he uses."
            });
        }

        if (GUILayout.Button("Remove Last Sentence", GUILayout.MaxWidth(160)))
        {
            if (sentences.Count > 0)
                sentences.RemoveAt(sentences.Count - 1);
        }
    }
}
