using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int trust = 0;
    public int knowledge = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
