#include <SoftwareSerial.h>

SoftwareSerial BTSerial(10, 11); // RX, TX
int reading; 
bool command; 

void setup() {
  Serial.begin(9600); // Start serial communication with the computer
  BTSerial.begin(9600); // Start serial communication with the Bluetooth module
}

void loop() {
  reading = 1023 - analogRead(A0); // Assuming you're using a pressure sensor or similar
  Serial.print("value received: ");
  Serial.println(reading);

  if (reading < 500) {
    command = true; 
    Serial.println("button pressed");
    BTSerial.println("TRUE"); // Send "TRUE" over Bluetooth
  } else {
    command = false;
    BTSerial.println("FALSE"); // Optionally, send "FALSE" over Bluetooth
  }

  delay(1000);
}
