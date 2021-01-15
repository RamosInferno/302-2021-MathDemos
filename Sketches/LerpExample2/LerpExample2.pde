
void setup(){
  size(500, 500);
}

void draw(){
  background(128);
  
  float p = mouseX / (float) width; // makes the circle change size based on mouse movement.
  float size = lerp(50, 300, p); // allows to change the cirles size.
  
  fill(p * 255); // changes color of the cirle.
  ellipse(width/2, height/2, size ,size);
  
}

float lerpy(float min, float max, float p){
  float range = man -mi;
  float offset = range * p;
  return min + offset;
}
