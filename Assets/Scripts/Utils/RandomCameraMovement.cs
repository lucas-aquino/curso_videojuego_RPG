using System.Collections;
using UnityEngine;

public class RandomCameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _min;
    [SerializeField] private Vector2 _max;
    [SerializeField] private float _minDistance = 5f;
    [Range(0.1f, 1f)]
    [SerializeField] private float _lerpSpeed = 0.75f;

    private Vector3 _targetPosition;

    private void Start()
    {
        StartRandomPan();
    }

    private void StartRandomPan()
    {
        transform.position = GetNewPosition(minDistance: 1f);
        _targetPosition = GetNewPosition(minDistance: _minDistance);
        StartCoroutine(LerpPosition());
    }

    private IEnumerator LerpPosition()
    {
        float time = 0;
        float duration = Vector3.Distance(transform.position, _targetPosition) / _lerpSpeed;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, _targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = _targetPosition;
        StartRandomPan();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private Vector3 GetNewPosition(float minDistance)
    {
        var xPos = Random.Range(_min.x, _max.x);
        var yPos = Random.Range(_min.y, _max.y);
        var newPosition = new Vector3(xPos, yPos, transform.position.z);

        if (Vector3.Distance(transform.position, newPosition) >= minDistance)
        {
            return newPosition;
        }
        
        return GetNewPosition(minDistance);
    }
}
