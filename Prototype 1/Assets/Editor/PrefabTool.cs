using UnityEngine;
using UnityEditor;

public class PrefabTool : EditorWindow
{
    public static Color newColor;
    public string prefabName;
    public int R;
    public int G;
    public int B;
    public int A;
    
    [MenuItem("Prefab Tool/Create Prefab!")]
    static void CreatePrefab()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;
        
        foreach (GameObject gameObject in selectedGameObjects)
        {
            string objectsPath = "Assets/" + gameObject.name + ".prefab";
            
            //if (!AssetDatabase.LoadAssetAtPath(objectsPath, typeof(GameObject)))
            //{
                if (EditorUtility.DisplayDialog("Pick a Color", "What Color Do You Want?",
                    "Custom Color", "Preset Colors"))
                {
                    Debug.Log("Custom Color Chosen");
                    PrefabTool window = ScriptableObject.CreateInstance<PrefabTool>();
                    window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 300);
                    window.ShowPopup();
                }
                else
                {
                    int chosenOption = EditorUtility.DisplayDialogComplex("Pick a Color", "What Color Do You Want?",
                        "Red", "Blue", "Green");
                    {
                        switch (chosenOption)
                        {
                            case 0:

                                gameObject.GetComponent<Renderer>().material.color = Color.red;
                                MakePrefab(gameObject, objectsPath);
                                break;

                            case 1:

                                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                                MakePrefab(gameObject, objectsPath);
                                break;

                            case 2:

                                gameObject.GetComponent<Renderer>().material.color = Color.green;
                                MakePrefab(gameObject, objectsPath);
                                break;
                        }
                    }
                }
            //}
        }
    }
    
    [MenuItem("Prefab Tool/Create Prefab", true)]
    static bool DisableMenu()
    {
        return Selection.activeGameObject != null;
    }

    static void MakePrefab(GameObject obj, string objectsPath)
    {
        Object prefab = PrefabUtility.CreatePrefab(objectsPath, obj);
        Material material = new Material(Shader.Find("Specular"));
        material = obj.GetComponent<Renderer>().material;
        AssetDatabase.CreateAsset(material, "Assets/MyMaterial.mat");
        PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Pick the RGBA Values of your color:", EditorStyles.wordWrappedLabel);
        GUILayout.Space(100);

        string customPrefabName = EditorGUILayout.TextField("Name your Prefab: ", prefabName);
        newColor.r = EditorGUILayout.IntField("R Value: ", R);
        newColor.g = EditorGUILayout.IntField("G Value: ", G);
        newColor.b = EditorGUILayout.IntField("B Value: ", B);
        newColor.a = EditorGUILayout.IntField("A Value: ", A);

        if (GUILayout.Button("Make the Prefab!!"))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (GameObject gameObject in selectedGameObjects)
            {
                //if (!AssetDatabase.LoadAssetAtPath(objectsPath, typeof(GameObject)))
                //{
                    gameObject.GetComponent<Renderer>().material.color = newColor;
                    gameObject.name = customPrefabName;
                string objectsPath = "Assets/" + gameObject.name + ".prefab";
                    MakePrefab(gameObject, objectsPath);
                //}
            }
            this.Close();
        }
        
    }
}