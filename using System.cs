using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class SerialReader : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM11", 9600); // bluetooth port
    public Text displayText; // Assign this in the Unity Editor what we want to edit when button pressed

    void Start()
    {
        if (!serialPort.IsOpen)
        {
            serialPort.Open(); // Open the serial port
            serialPort.ReadTimeout = 50; // Set read timeout to 50ms
        }
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine(); // Read data from serial port
                if (data.Trim() == "TRUE") // Check if the received command is "TRUE"
                {
                    displayText.text = "Button Pressed updated info"; // Update the display text
                }
            }
            catch (System.TimeoutException) 
            {
                // Handle timeout exceptions or ignore if not necessary
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen) serialPort.Close(); // Close the serial port when the application closes
    }
}
