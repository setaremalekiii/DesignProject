using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using TMPro; // Make sure to include the TMPro namespace

public class NewBehaviourScript3 : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM11", 19200); // Bluetooth port
    public TextMeshProUGUI displayText; // Assign this in the Unity Editor
       private int currentIndex = 0;
        private List<string> messages = new List<string>
    {
        "In order for us to trigger the service mode, there is a huge black button behind the pump. Press it while you press the start button to trigger it into maintenance mode. You will hear two beeps when it has entered service mode.",
         "so now it says maintenance mode. So once you're here, you want to you want to press the proceed button",
         "there's a standalone/maintenance button. Press the blue button with the white triangle next to it. ",
         "Press the Hardware Tests button ",
         "There are three tests that we can do. The first one is the battery. The second one is the keypad test. And third one is the display test. Move on to the keypad test and the display test. Press the keypad test to start.",
         " When you press a button in the keypad mode, an alarm will sound (a beep) as well as an associated button number that appears right next to it on the screen. The first button is the S1 button, press that button.",
         "When you press the lower buttons, such as the silence button, its name should appear on the screen too, with a beep. If you press the numbers below, they should also appear on the keypad maintenance screen.",
         "Now that you have pressed all buttons going down, press the cancel button twice to return to the test screen",
         "GOOD JOB!"
        // Add more messages as needed
    };

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
                    if (currentIndex < messages.Count)
                    {
                        // Call the coroutine to update text with a delay and pass the current message
                        StartCoroutine(UpdateTextWithDelay(messages[currentIndex], 1.0f));
                        currentIndex++; // Move to the next message
                    }
                }
            }
            catch (System.TimeoutException) 
            {
                // Handle timeout exceptions or ignore if not necessary
            }
        }
    }

    IEnumerator UpdateTextWithDelay(string text, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        displayText.text = text; // Update the display text after the delay
    }

    void OnDestroy()
    {
        if (serialPort.IsOpen) serialPort.Close(); // Close the serial port when the application closes
    }
}
