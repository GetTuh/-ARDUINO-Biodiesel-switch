#include <LiquidCrystal.h>
#include <EEPROM.h>
int switchtemp = EEPROM.read(1); //temperatura zmiany w stopniach C                                                 eeprom 1
int switchtime = EEPROM.read(2); //różnica pomiędzy otwarciem powrotu do zbiornika z ropą a otwarciem wlotu ropy    eeprom 2
int switchdelay = EEPROM.read(3); //opóźnienie między przełączaniem                                                 eeprom 3
int dispfreq = 15;
  int i;
int menuu=1;


int jednorazowy=-1;
int dwurazowy;
int choice;
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

void setup() {
  lcd.begin(16, 2);
  defaulty();
   pinMode(9, INPUT);
   charsy();
}
void charsy(){
  uint8_t fullb[8] = {0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff}; 
lcd.createChar(0, fullb);
}
void defaulty(){
// wczytanie defaultów jeżeli jakieś wartości nie były zapisane w pamięci EEPROM
  if (switchtemp==0)switchtemp=70;
  if(switchtime==0)switchtime=5;
  if(switchdelay==0)switchdelay=3;
  i = dispfreq;
}



void loop() {
  if(menuu==1){
    //menu();
    rysujinfo();
  }
else if(i==0){
 // rysujinfo();
  i=dispfreq;
}
else{i--;}
  
  delay(50);
 }
 
void menu(){
  if(pozycjagalki()!=jednorazowy||jednorazowy==-1){

  lcd.clear();
  lcd.setCursor(pozycjagalki(), 0);
 lcd.print((char)0);
  lcd.setCursor(0,1);
  if(pozycjagalki()>-1&&pozycjagalki()<4){lcd.print("  Temp. zmiany");choice=0;}
  else if(pozycjagalki()>3&&pozycjagalki()<8){lcd.print("Roznica otwarcia");choice=1;}
  else if(pozycjagalki()>7&&pozycjagalki()<12){lcd.print("Opoznienie otw.");choice=2;}
  else if(pozycjagalki()>11&&pozycjagalki()<16){lcd.print("Zaprezetuj ");choice=3;}
  }
  jednorazowy=pozycjagalki();
}
float pozycjagalki(){
  return (15+(-1*(((analogRead(0))/4)/16)));
}


void rysujinfo(){
  int temp = (int)fatemp();
  if(temp!=dwurazowy){
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(temp);
  
  }
  dwurazowy=(temp);

}
float fatemp(){
  int reading = analogRead(5);
float voltage = reading * 5.0;
voltage /= 1024.0; 
return ((voltage - 0.5) * 100) ; 
}

void czysceeprom(){
   for (int i = 0 ; i < EEPROM.length() ; i++) {
    EEPROM.write(i, 0);
   }
}
