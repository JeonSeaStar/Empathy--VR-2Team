using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugGuide : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material material;

    Color alpha = new Color(97.0f, 185.0f, 173.0f, 105.0f);
    bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.materials[0];

        Debug.Log(material.name);
    }

    // Update is called once per frame
    void Update()
    {
        //if (alpha.a <= 0.0f) up = true;
        //else if (alpha.a >= 105.0f) up = false;

        //if (up) alpha.a += 0.1f;
        //else alpha.a -= 0.1f;

        //material.SetColor("_BaseColor", alpha);
    }
}
