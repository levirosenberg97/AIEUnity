using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = .2f;
    public float screenEdgeBuffer = 4f;
    public float minSize = 6.5f;
    public Transform[] targets;

    private Camera mainCamera;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;

    // Use this for initialization
    private void Awake()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime);
        Move();
        //transform.LookAt(player.transform);
        Zoom();

    }

    private void Move()
    {
        findAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }

    private void findAveragePosition()
    {
        Vector3 averagePos = new Vector3();

        int numTargets = 0;

        for(int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeSelf)
                continue;

            averagePos += targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        desiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredsize = findRequiredSize();
        mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, requiredsize, ref zoomSpeed, dampTime);
    }

    private float findRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);

        float size = 0f;

        for(int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / mainCamera.aspect);
        }

        size += screenEdgeBuffer;

        size = Mathf.Max(size, minSize);

        return size;
    }

    public void setStartPositionAndSize()
    {
        findAveragePosition();

        transform.position = desiredPosition;

        mainCamera.orthographicSize = findRequiredSize();
    }

}
