using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       textMesh.text = "Hello World";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
