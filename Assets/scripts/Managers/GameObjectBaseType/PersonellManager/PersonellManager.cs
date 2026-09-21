using UnityEngine;

public class PersonellManager : MonoBehaviour
{
    [SerializeField] private bool unCrewed;
    private VehicleControlManager vehicleControlManager;
    public VehicleControlManager VehicleControlManager { get { return vehicleControlManager; } }
    public bool IsCrewed { get { return unCrewed; } }
}
