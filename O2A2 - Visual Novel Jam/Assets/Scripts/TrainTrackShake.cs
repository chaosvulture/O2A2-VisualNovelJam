using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrackShake : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public Transform GameObject;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    private bool _up;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        if (_up == false)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            GameObject.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            if (GameObject.position == endMarker.position) { 
                _up = true;
                startTime = Time.time;
            } else { return; }
        } else {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            GameObject.position = Vector3.Lerp(endMarker.position, startMarker.position, fractionOfJourney);

            if (GameObject.position == startMarker.position) { 
                _up = false;
                startTime = Time.time;
            } else { return; }
        }
    }
}