# ARDUINO-Biodiesel-switch


<!-------------------------------------------------------------------------
See demo live on https://www.tinkercad.com/things/ilW7WSjFK7X-olej-old  
-------------------------------------------------------------------------->

Diesel engines in cars were made in mind to use with vegetable oil. In fact, the very first diesel engine still runs on peanut oil! But cars are made to run on petroleum oil, which has few key differences in viscosity and thickness.
These differences are almost negligible when vegetable oil is around 70°C. 

So, how to heat up fluid in a car?
Since diesel efficiency usually floats around 35%, in a car that has 80hp which equals to roughly 60 KW, even when we'll have 50% efficiency (just to be safe) we have 30KW heater sitting under our hood. Even when we take in consideration that we don't ask the engine for full load all the time, at slow driving, using just 10KW of power gives us 5KW of heating power which will rise the temperature of 1L of oil from 0°C to 70°C in under a minute.


This code is used for arduino to turn on and off solenoid valves according to the values from the thermometer. It's configurable in car with 2 switches and a potentiometer.The data is displayed on 16x2 screen, and all the values can be saved to a arduino's non-volatile eeprom memory.
