using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private static GameManager instance = null;

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            SaveSystem.Save(1);
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            SaveSystem.Save(2);
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            SaveSystem.Save(3);
        }
    }
}
