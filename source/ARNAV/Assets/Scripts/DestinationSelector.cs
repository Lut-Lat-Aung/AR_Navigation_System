using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationSelector : MonoBehaviour
{
    public Dropdown destinationDropdown; // Dropdown UI element
    public Transform startPoint; // Starting point of the path
    public Transform truelabPoint; // Truelab destination point
    public Transform toiletPoint1; // Toilet destination point
    public Transform toiletPoint2; // Toilet destination point
    public Transform tutorRoomPoint; // TutorRoom destination point
    public Transform dcodelabPoint; // dcodelab destination point
    public Transform ISLPoint;
    public Transform MechatronicPoint;
    public Transform AuditoriumPoint;
    public Transform Elevator_1st;
    public Transform Exit_1;
    public Transform Meeting_1;
    public Transform Toilet_1;
    public Transform EngineeringDrawing_1;
    public Transform vmesproject;
    public Transform threedprinter;
    public Transform researchroom;
    public Transform circuit;


    public ARPathVisualizer pathVisualizer; // Reference to ARPathVisualizer1 script

    private Dictionary<string, Transform> destinations;

    void Start()
    {
        // Initialize the destinations dictionary
        destinations = new Dictionary<string, Transform>()
        {
            { "Truelab", truelabPoint },
            { "Toilet1", toiletPoint1 },{ "Toilet2", toiletPoint2 },
            { "TutorRoom-(VMES608)", tutorRoomPoint },
            { "ISL-(VMES607)", ISLPoint },
            { "Dcodelab/Robotics-(VMES609)", dcodelabPoint },             
            { "Auditorium", AuditoriumPoint},
            { "Elevator_1st", Elevator_1st },
            { "MechatronicsLab-(VMES601)", MechatronicPoint },
            { "Exit_1", Exit_1 },
            { "Meeting_1", Meeting_1 },
            { "Toilet_1", Toilet_1 },
            { "EngineeringDrawing_Lab", EngineeringDrawing_1 },
            { "vmes_project_room", vmesproject },
            { "3d_printer_room", threedprinter },
            { "research_room", researchroom },
            { "circuit_room", circuit },


        };

        // Debug logs to verify dictionary setup
        foreach (var entry in destinations)
        {
            Debug.Log($"Destination Key: {entry.Key}, Transform: {entry.Value.position}");
        }

        // Add a listener to the dropdown
        destinationDropdown.onValueChanged.AddListener(OnDestinationSelected);
    }

    private void OnDestinationSelected(int index)
    {

        string selectedDestination = destinationDropdown.options[index].text;
        Debug.Log("Selected Destination: " + selectedDestination);


        if (destinations.TryGetValue(selectedDestination, out Transform selectedPoint))
        {

            pathVisualizer.startPoint = startPoint; // Set startPoint
            pathVisualizer.endPoint = selectedPoint; // Update endPoint
            Debug.Log("Navigating to: " + selectedDestination);
        }
        else
        {
            Debug.LogError("Selected destination is not valid: " + selectedDestination);
        }
    }
}
