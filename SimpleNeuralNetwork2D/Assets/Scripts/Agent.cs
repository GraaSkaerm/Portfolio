using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour, IComparable<Agent>
{

    private Rigidbody2D _rb;

    private float _movementSpeed = 5f;
    private float _rotationSpeed = 500f;

    public bool IsActive { get; set; }
    public Transform Target { get; set; }
    public NeuralNetwork Brain { get; set; }


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private float GetWantedAngle(Vector2 direction)
    {
        float radian = Mathf.Atan2(direction.y, direction.x);
        return radian * Mathf.Rad2Deg;
    }



    private void FixedUpdate()
    {
        if (IsActive == false) return;

        float currentAngle = transform.eulerAngles.z % 360f;

        if (currentAngle < 0f) currentAngle += 360f;


        Vector2 direction = Target.position - transform.position;
        direction.Normalize();

        float wantedAngle = GetWantedAngle(direction);

        // Keep angle between 0 and 360
        wantedAngle = wantedAngle % 360;
        if (wantedAngle < 0) wantedAngle += 360f;


        wantedAngle = 90f - wantedAngle;
        if (wantedAngle < 0f) wantedAngle += 360f;


        wantedAngle = 360 - wantedAngle;
        wantedAngle -= currentAngle;


        if (wantedAngle < 0) wantedAngle = 360 + wantedAngle;

        if (wantedAngle >= 180f)
        {
            wantedAngle = 360 - wantedAngle;
            wantedAngle *= -1f;
        }

        wantedAngle = wantedAngle * Mathf.Deg2Rad;


        float input = wantedAngle / Mathf.PI;



        float[] output = Brain.FeedForward(new float[] { input });

        _rb.velocity = _movementSpeed * transform.up;
        _rb.angularVelocity = _rotationSpeed * output[0];

        Brain.Fitness += 1f - Mathf.Abs(input);
    }

    public int CompareTo(Agent other)
    {
        if (other == null) return 1;

        if (Brain.Fitness > other.Brain.Fitness) return 1;
        if (Brain.Fitness < other.Brain.Fitness) return -1;
        return 0;
    }
}
