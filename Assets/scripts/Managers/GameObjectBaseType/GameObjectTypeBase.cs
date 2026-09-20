using UnityEngine;

public abstract class GameObjectTypeBase : MonoBehaviour
{
    protected PersonellManager personellManager;
    public PersonellManager PersonellManager { get { return personellManager; } }
}
