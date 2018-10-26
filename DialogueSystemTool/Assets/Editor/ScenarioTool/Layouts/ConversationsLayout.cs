using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConversationsLayout
{
    private DialoguesLayout dialoguesLayout = new DialoguesLayout();
    public void DrawConversations(List<Conversation> conversations)
    {
        GUILayout.Label("Dialogues", EditorStyles.boldLabel);

        UIHelper.DrawUILine(Color.blue);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical();
        DrawTop(conversations);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();
        for (int i = 0; i < conversations.Count; i++)
        {
            conversations[i].ID = EditorGUILayout.TextField("Dialogue " + (i + 1), conversations[i].ID, GUILayout.MaxWidth(400));
            conversations[i].Initiator.ID = EditorGUILayout.TextField("Starter " + (i + 1), conversations[i].Initiator.ID, GUILayout.MaxWidth(400));
            
            dialoguesLayout.DrawDialogue(conversations[i].Sentences);
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
        UIHelper.DrawUILine(Color.black);
    }

    public void DrawTop(List<Conversation> conversations)
    {
        if (GUILayout.Button("Add Dialogue", GUILayout.MaxWidth(160)))
        {
            conversations.Add(new Conversation
            {
                ID = "DialogueID",
                Initiator = new Character() { ID = "InitiatorID" },
                Sentences = new List<Sentence>()
            });
        }

        if (GUILayout.Button("Remove Last Dialogue", GUILayout.MaxWidth(160)))
        {
            if (conversations.Count > 0)
                conversations.RemoveAt(conversations.Count - 1);
        }
    }
}
