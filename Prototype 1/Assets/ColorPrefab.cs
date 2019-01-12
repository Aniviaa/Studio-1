using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPrefab : MonoBehaviour
{

    public Color newColor;
    public Renderer rend;
    public Material newMaterial;
    public Material referenceMaterial;

    public InputField ChooseR;
    public InputField ChooseG;
    public InputField ChooseB;
    public InputField ChooseA;

    void Start()
    {
        newColor = Color.white;
        rend = GetComponent<Renderer>();
        referenceMaterial = rend.material;
        ChooseR = GameObject.Find("ChooseR").GetComponentInChildren<InputField>();
        ChooseG = GameObject.Find("ChooseG").GetComponentInChildren<InputField>();
        ChooseB = GameObject.Find("ChooseB").GetComponentInChildren<InputField>();
        ChooseA = GameObject.Find("ChooseA").GetComponentInChildren<InputField>();
    }

    void Update()
    {

    }

    public void ChangeColor()
    {
        newColor.r = int.Parse(ChooseR.text);
        newColor.g = int.Parse(ChooseG.text);
        newColor.b = int.Parse(ChooseB.text);
        newColor.a = int.Parse(ChooseA.text);

        CreateNewMaterial();
    }

    public void CreateNewMaterial()
    {
        referenceMaterial.color = newColor;
        rend.material = referenceMaterial;
    }

    //--------------------------------------------------------------------------PRESET COLORS -----------------------------------------------------//

    public void Red()
    {
        newColor.r = 255f;
        newColor.g = 0;
        newColor.b = 0;
        newColor.a = 255f;
        CreateNewMaterial();
    }

    public void Green()
    {
        newColor.r = 0;
        newColor.g = 255f;
        newColor.b = 0;
        newColor.a = 255f;
        CreateNewMaterial();
    }

    public void Blue()
    {
        newColor.r = 0;
        newColor.g = 0;
        newColor.b = 255f;
        newColor.a = 255f;
        CreateNewMaterial();
    }

    public void Black()
    {
        newColor.r = 0;
        newColor.g = 0;
        newColor.b = 0;
        newColor.a = 255f;
        CreateNewMaterial();
    }

    public void White()
    {
        newColor.r = 255f;
        newColor.g = 255f;
        newColor.b = 255f;
        newColor.a = 255f;
        CreateNewMaterial();
    }
}

