using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplierCubeAttribute : MonoBehaviour
{
     private TextMeshProUGUI cubeText;
     private Material material;
    void Start()
    {
        cubeText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
       
        cubeText.text = name + "X";
        ChangeColor();
        Material myNewMaterial = new Material(Shader.Find("Standard"));

        myNewMaterial.color = ChangeColor();
        gameObject.GetComponent<MeshRenderer>().material = myNewMaterial;

    }

    // Update is called once per frame
    Color ChangeColor()
    {
        var r = Random.Range(0f, 1f);
        var g = Random.Range(0f, 1f);
        var b = Random.Range(0f, 1f);

        
       Color color = new Color(r, g, b, 255);
       return color;
    }
}
