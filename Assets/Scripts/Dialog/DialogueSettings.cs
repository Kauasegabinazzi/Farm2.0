using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]

public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speaker;
    public string sentence;

    public List<sentences> dialogues = new List<sentences>();

}

[System.Serializable]
public class sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;

}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages ls = new Languages();

        ls.portuguese = ds.sentence;

        sentences sent = new sentences();
        sent.profile = ds.speaker;
        sent.sentence = ls;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogues.Add(sent);

                ds.speaker = null;
                ds.sentence = "";
            }
        }
    }
}

#endif

