using UnityEditor;

[CustomEditor(typeof(AUIAlpine))]
public class AUIButtonEditor : UnityEditor.UI.ButtonEditor
{
    AUIAlpine uiButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        uiButton = (AUIAlpine)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        serializedObject.Update();

        uiButton.KnifeHalf = EditorGUILayout.Toggle("ScaleAnim", uiButton.KnifeHalf);
        uiButton.Enjoy = EditorGUILayout.Toggle("Sound", uiButton.Enjoy);
        uiButton.SoRich = EditorGUILayout.Toggle("IsGray", uiButton.SoRich);
        
        serializedObject.ApplyModifiedProperties();
    }
}