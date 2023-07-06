using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerTarget;
    public float moveDuration = 1.0f;

    private void OnEnable()
    {
        StartCoroutine(MoveToTarget());
    }

    void Update()
    {
        Vector3 newPos = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    private IEnumerator MoveToTarget()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = playerTarget.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            Vector3 newPos = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(startPosition, newPos, t);
            yield return null;
        }

        transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, transform.position.z); ;
    }
}
