using UnityEngine;

public class PersonellManager : MonoBehaviour
{
    [SerializeField] protected bool unCrewed;
    public bool IsCrewed { get { return unCrewed; } }
    protected PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return playerManager; } }
}
