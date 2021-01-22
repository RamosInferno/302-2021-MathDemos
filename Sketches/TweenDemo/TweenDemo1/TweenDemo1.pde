
float valStart = 0;
float valEnd = 500;

float animLength = 5;
float animPlayheadTime = 0;
boolean isTweenPlaying = false;

float previousTimestamp = 0;

void setup () {
  size(500, 500);
}
void draw(){
  
   background(128); // fill screen with 50% gray 
   
   float currentTimestamp = millis()/1000.0;
   float dt = currentTimestamp - previousTimestamp;
   previousTimestamp = currentTimestamp;
   
   //move playhead foward in time
   if(isTweenPlaying){animPlayheadTime += dt;
   if(animPlayheadTime > animLength) isTweenPlaying = false;
   animPlayheadTime = animLength;
   }
   
  //percent
  float  p = animPlayheadTime / animLength;
  
  //p = p * p; 
  //p = 1- p; 
  //p = 1 -(1- p) * (1 - p);
  p = p * p * (3 - 2 * p);
  
  float x = lerp(valStart, valEnd, p);
  
  ellipse(x, height/2.0, 20, 20);
 
}
void mousePressed(){
  animPlayheadTime = 0; // restarts animation
  isTweenPlaying = true;
}
