using UnityEngine;

public class PersonellManager : MonoBehaviour
{
    [SerializeField] private bool unCrewed;
    public bool IsCrewed { get { return unCrewed; } }
}
