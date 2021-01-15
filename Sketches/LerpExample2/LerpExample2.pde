
void setup(){
  size(500, 500);
}

void draw(){
  background(128);
  
 
  float size = mappy(mouseX, 0, width, 50, 300);
  
  ellipse(width/2, height/2, size ,size);
}

float mappy(float inVal, float inMin, float inMax, float outMin, float outMax){

  float p = 0;
  
  (inVal - inMin) / (inMax - inMin);
  
  return lerpy(outMin, outMax, p);
}
float lerpy(float min, float max, float p){
  return lerpy(min, max, p, true);
}

float lerpy(float min, float max, float p, boolean allowExtrapolation){
  if(allowExtrapolation == false){
  if(p < 0) p= 0;
  if(p > 1) p = 1;

  float range = max - min;
  float offset = range * p;
  return min + offset;
  }
}
