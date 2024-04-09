int reading; 
bool command; 

void setup() {
  Serial.begin(19200); // Start serial communication with the computer
}

void loop() {
    reading = 1023 - analogRead(A0); 
  Serial.print("value received: ");
  Serial.println(reading);
  if (reading < 600) {
    command = true; 
    Serial.println("TRUE");
  


  
  } else {
    command = false;
    Serial.println("FALSE");
  }

 delay(500);
}
