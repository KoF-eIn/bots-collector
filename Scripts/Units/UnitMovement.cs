using UnityEngine;
using System.Collections;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    public IEnumerator MoveTo(Vector3 target)
    {
        while ((transform.position - target).sqrMagnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                _speed * Time.deltaTime);

            yield return null;
        }
    }
}