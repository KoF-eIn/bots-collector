using UnityEngine;

public class UnitInstaller : MonoBehaviour
{
    private void Awake()
    {
        Unit unit = GetComponent<Unit>();
        UnitMovement movement = GetComponent<UnitMovement>();

        unit.Construct(movement);
    }
}