
#include <LiquidCrystal.h>

byte stopni[8] = {
    0b00110,
    0b01001,
    0b01001,
    0b00110,
    0b00000,
    0b00000,
    0b00000,
    0b00000
};

byte ch1[8] = {
  B00111,
  B01000,
  B10010,
  B10000,
  B10100,
  B10010,
  B01000,
  B00111
};


byte ch2[8] = {
  B00000,
  B11111,
  B00000,
  B00100,
  B00001,
  B01000,
  B11111,
  B00000
};
byte ch3[8] = {
  B00000,
  B11111,
  B00000,
  B01000,
  B00000,
  B00001,
  B11111,
  B00000
};

byte ch4[8] = {
  B00000,
  B10000,
  B01100,
  B01010,
  B01001,
  B01010,
  B11100,
  B00000
};

byte c[8] = {
  B00010,
  B00100,
  B00000,
  B01111,
  B10000,
  B10000,
  B01111,
  B00000
};

byte ch5[8] = {
B01100,  
B10010,  
B01001,  
B00101,  
B00001,  
B01001,  
B10010,  
B01100 

};
byte ch6[8] = {
B00000,  
B00111,  
B01010,  
B10010,  
B01010,  
B00100,  
B00011,  
B00000
};



LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
int temp;
int ontemp=70;
int err;
bool sw1;
bool sw2;
bool ros;
bool ch=true;
bool res=false;
void setup() {
  lcd.createChar(0, stopni);
  lcd.createChar(1, ch1);
    lcd.createChar(2, ch2);
  lcd.createChar(3, ch3);
     lcd.createChar(4, ch4);
  lcd.createChar(5, c);
  lcd.createChar(6, ch5);
  lcd.createChar(7, ch6);
  lcd.begin(16, 2);
  pinMode(6, INPUT);
  pinMode(7,INPUT);
  pinMode(8,OUTPUT);
  
}


void drawch(){
    
  lcd.write(byte(1));
    lcd.write(byte(2));
    lcd.write(byte(3));
    lcd.write(byte(4));
  
  lcd.print("    ");
  
  lcd.print("JKP   ");
  
  lcd.print("     ");
    lcd.write(byte(7));
    lcd.write(byte(3));
    lcd.write(byte(2));
    lcd.write(byte(6));

}

void loop() {


    err=0;
lcd.setCursor(0, 0);
sw1=digitalRead(6);
sw2=digitalRead(7);



int reading = analogRead(5);
float voltage = reading * 5.0;
voltage /= 1024.0; 
float temp = (voltage - 0.5) * 100 ; 

 lcd.print("TRYB:");
  if(sw1==true){
    lcd.print("AUTO");
    if(temp>ontemp||res==true){
        ros=true;
        res=true;
        err=0;
    }
    else{
        ros=false;
        err=1;
    }
  }
  if(sw1==false){
    lcd.print("Wymusz.");
    err=2;
   if(sw2==true){
    ros=false;
   }
   if(sw2==false){
    ros=true;
   }
  }



  lcd.setCursor(14,0);
if(ros==true){ 
    lcd.print("OR");
    //elektrozawory przełączają się na olej roślinny
  digitalWrite(8,HIGH);
}
if(ros==false) {
    lcd.print("ON");
    //elektrozawory przełączają sie na olej napędowy
  digitalWrite(8,LOW);
}
lcd.setCursor(0,1);
  switch(err){
    case 1:lcd.print("Nisk. Temp"); break;
    case 2:lcd.print("Tryb recz.");break;
    case 0:lcd.print("Praca");break;
}
  



  if(temp>100){
     lcd.setCursor(11,2);
lcd.print((int)temp);
lcd.write(byte(0));
lcd.print("C");
  }
  else if(temp>9){
    lcd.setCursor(12,2);
lcd.print((int)temp);
lcd.write(byte(0));
lcd.print("C");
  }  else if(temp>-1){
    lcd.setCursor(13,2);
lcd.print((int)temp);
lcd.write(byte(0));
lcd.print("C");
  }
  else if(temp>-10){
        lcd.setCursor(12,2);
lcd.print((int)temp);
lcd.write(byte(0));
lcd.print("C");
  }else{
       lcd.setCursor(11,2);
lcd.print((int)temp);
lcd.write(byte(0));
lcd.print("C");
  }
  delay(750);
  lcd.clear();


if(ch==true){
      lcd.clear();
    int w=0;
  bool x=false;
    while(w>-1){
        lcd.setCursor(w,0);
    drawch();
      lcd.setCursor(w,1);
      lcd.print("Kurczy");
      lcd.write(byte(5));
      lcd.print(" Koncerny Paliwowe");
    delay(250);
      if(x==false){delay(750);x=true;}

    w--;
      if(w>-1){
        lcd.clear();
      }
    }
  w=7;
  while(w>0){
    lcd.scrollDisplayLeft();
    delay(250);
    w--;
  }
  delay(750);
    ch=false;
  lcd.clear();
}



}

