using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnkhController : MonoBehaviour
{
    [SerializeField] private GameObject gemGFX;
    [ColorUsage(true, true)][SerializeField] private Color currentColor;
    private Material gemMaterial;

    void Start()
    {
        gemMaterial = gemGFX.GetComponent<MeshRenderer>().material;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnkhColor(Color color)
    {
        gemMaterial.SetColor("",color);
    }

    public void isGlowing(bool enable)
    {
        int input = enable ? 1:0;
        gemMaterial.SetInt("EnableGlow", input);
    }
}
