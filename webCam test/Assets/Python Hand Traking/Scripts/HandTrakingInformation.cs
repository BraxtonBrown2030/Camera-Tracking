using UnityEngine;

public class HandTrakingInformation : MonoBehaviour{
    
[Tooltip("This is the component need the UDPReceive Script (just put the UDPReceive script here).")]
public UDPReceive udpReceive;

public GameObject[] handPoints;
public GameObject[] otherHandPoints;

void Update()
{
    string data = udpReceive.data;

    data = data.Remove(0, 1);
    data = data.Remove(data.Length - 1, 1);
    print(data);
    string[] points = data.Split(',');
    print(points[0]);

    // Ensure there are enough points
    if (points.Length < 126)
    {
        Debug.LogError("Not enough points received.");
        return;
    }

    // Process the first hand points
    for (int i = 0; i < 21; i++)
    {
        float x = 7 - float.Parse(points[i * 3]) / 100;
        float y = float.Parse(points[i * 3 + 1]) / 100;
        float z = float.Parse(points[i * 3 + 2]) / 100;

        handPoints[i].transform.localPosition = new Vector3(x, y, z);
    }

    // Process the other hand points
    for (int i = 21; i < 42; i++)
    {
        float x = 7 - float.Parse(points[i * 3]) / 100;
        float y = float.Parse(points[i * 3 + 1]) / 100;
        float z = float.Parse(points[i * 3 + 2]) / 100;

        otherHandPoints[i - 21].transform.localPosition = new Vector3(x, y, z);
    }
}
}