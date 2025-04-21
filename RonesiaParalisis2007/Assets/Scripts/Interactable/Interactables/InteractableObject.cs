using UnityEngine;

public enum InteractType
{
    Talk,
    Grab,
    ChangeScene,
    None
};

public abstract class InteractableObject : MonoBehaviour
{
    public InteractType interactType;

    public virtual void OnClickAction()
    {

    }
}
