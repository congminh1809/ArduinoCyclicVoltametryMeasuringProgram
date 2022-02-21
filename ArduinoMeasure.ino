#include <Wire.h>
#include <LMP91000.h>

LMP91000 lmp = LMP91000();

const double v_tolerance = 33;

int state = 1;
int S_Vol=0;
int E_Vol=0;
static int Step=3;
static int Freq=3;
String str = "9,9,9,9",strS, strE, strStep, strF;
int moc1;
int moc2;
int moc3;
void setup() 
{  
  Wire.begin();
  Serial.begin(9600);
  analogReference(EXTERNAL);

  //enable the potentiostat
  delay(500);
  lmp.standby();
  delay(500);
  initLMP();
  delay(2000); //warm-up time for the sensor 


}


void loop() 
{

  // Đọc và xử lí chuỗi từ app gửi về
    if (Serial.available()) {
        str = Serial.readString(); //Serial đọc chuỗi
        //Serial.println(str);
        for (int i = 0; i < str.length(); i++) {
        if (str.charAt(i) == '|') {
            moc1 = i; //Tìm vị trí của dấu "|"
            }
        if (str.charAt(i) == '_' && i>moc1) {
            moc2 = i; //Tìm vị trí của dấu "_"
            }
        if (str.charAt(i) == '?' && i>moc2) {
            moc3 = i; //Tìm vị trí của dấu "?"
            }  
        }
        strS = str;
        strE = str;
        strStep = str;
        strF = str;
        strS.remove(moc1); //Tách giá trị V start ra
        strE.remove(0, moc1 + 1); //Tách giá trị V end ra
        strE.remove(moc2);        //Tách giá trị V end ra
        strStep.remove(0, moc2 + 1);   //Tách giá trị Step ra
        strStep.remove(moc3);          //Tách giá trị Step ra
        strF.remove(0, moc3 + 1); //Tách giá trị Frequency ra 
        S_Vol = strS.toInt(); //Chuyển strS thành số
        E_Vol = strE.toInt(); //Chuyển strE thành số
        Step = strStep.toInt(); //Chuyển strS thành số
        Freq = strF.toInt(); //Chuyển strS thành số

        if(S_Vol>0){
          S_Vol=-S_Vol;
          }

        //Serial.print(Step*3);
        //Serial.print("|");
        //Serial.println(Freq*2);
    }
    
  
    //startV(mV), endV(mV), stepV(mV), freq(Hz)
   if(Serial.available()) 
    {
        char temp = Serial.read();
        if(temp == '0')
            state = 0;
        if(temp == '1')
            state = 1;
        if(temp == '2')
            state = 2; 
    }
   // Thực thi các trường hợp với các giá trị của biến state
   switch(state)
    {
        // state = 0: dừng Arduino
        case 0:
          break;
        // state = 1: thực thi hàm tạo Random, xuất dữ liệu và thời gian thực qua Serial, phân tách nhau bởi ký tự gạch đứng “|”
        case 1:
       
          //Serial.println("Forward scan");
          //Serial.print(Step);
          //Serial.print("|");
          //Serial.println(E_Vol);
          runCV(S_Vol, E_Vol, Step, Freq);
          //Serial.println("Backward scan");
          runCV(E_Vol, S_Vol, Step, Freq);
          //Serial.print(S_Vol);
          //Serial.print("|");
          //Serial.println(E_Vol);
     }
     
 
}


void initLMP()
{
  lmp.disableFET(); 
  lmp.setGain(2); // 3.5kOhm
  lmp.setRLoad(0); //10Ohm
  lmp.setIntRefSource(); //Sets the voltage reference source to supply voltage (Vdd).
  lmp.setIntZ(0); //V(Iz) = 0.2*Vdd
  lmp.setThreeLead(); //3-lead amperometric cell mode                  
}

//Thí nghiệm 1: đổi biến freq từ double sang int: fail
//Thí nghiệm 2: đặt stepV và freq thành biến cục bộ sau đó gán bằng Step và Freq: fail
void runCV(int16_t startV, int16_t endV, int16_t stepV, double freq)

{
  stepV = abs(stepV);
  freq = (uint16_t)(1000.0 / (2*freq));


  if(startV < endV) runCVForward(startV, endV, stepV, freq);
  else runCVBackward(startV, endV, stepV, freq);

}

void setBiasVoltage(int16_t voltage)
{
  //define bias sign
  if(voltage < 0) lmp.setNegBias();
  else if (voltage > 0) lmp.setPosBias();
  else {} //do nothing

  //define bias voltage
  uint16_t Vdd = 3300;
  uint8_t set_bias = 0; 

  int16_t setV = Vdd*TIA_BIAS[set_bias];
  voltage = abs(voltage);

  while(setV > voltage+v_tolerance || setV < voltage-v_tolerance)
  {
    set_bias++;
    if(set_bias > NUM_TIA_BIAS) return;  //if voltage > 0.792 V

    setV = Vdd*TIA_BIAS[set_bias];    
  }

  lmp.setBias(set_bias); 
}

void biasAndSample(int16_t voltage, double rate)
{
  //Serial.print("Time(ms): "); Serial.print(millis()); 
  //Serial.print(", Voltage(mV): "); 
  delay(100);
  Serial.print(voltage);

  setBiasVoltage(voltage);

  double tensao = lmp.getVoltage(analogRead(A0), 3.3, 10);
  double amperage = (tensao - 0.66) / 3500;
  //Serial.print(", Vout(V): ");
  //Serial.print(tensao,5);
  //Serial.print(", Current(uA): ");
  //Serial.print(",");
  Serial.print("|");
  Serial.println(amperage/pow(10,-6),5);


  delay(rate);
}

void runCVForward(int16_t startV, int16_t endV, int16_t stepV, double freq)

{
  for (int16_t j = startV; j <= endV; j += stepV)
  {
    biasAndSample(j,freq);
    //Serial.println();
  }
}


void runCVBackward(int16_t startV, int16_t endV, int16_t stepV, double freq)

{
  for (int16_t j = startV; j >= endV; j -= stepV)
  {
    biasAndSample(j,freq);
    //Serial.println();
  }
}


/*void biasAndSample(int16_t voltage, double rate)
{
  //Serial.print("Time(ms): "); Serial.print(millis()); 
  //Serial.print(", Voltage(mV): "); 
  delay(100);
  Serial.print(voltage);

  setBiasVoltage(voltage);

  double tensao = lmp.getVoltage(analogRead(A0), 3.3, 10);
  double amperage = (tensao - 0.66) / 3500;
  //Serial.print(", Vout(V): ");
  //Serial.print(tensao,5);
  //Serial.print(", Current(uA): ");
  //Serial.print(",");
  Serial.print("|");
  Serial.println(amperage/pow(10,-6),5);


  delay(rate);
}*/


/*void setBiasVoltage(int16_t voltage)
{
  //define bias sign
  if(voltage < 0) lmp.setNegBias();
  else if (voltage > 0) lmp.setPosBias();
  else {} //do nothing

  //define bias voltage
  uint16_t Vdd = 3300;
  uint8_t set_bias = 0; 

  int16_t setV = Vdd*TIA_BIAS[set_bias];
  voltage = abs(voltage);

  while(setV > voltage+v_tolerance || setV < voltage-v_tolerance)
  {
    set_bias++;
    if(set_bias > NUM_TIA_BIAS) return;  //if voltage > 0.792 V

    setV = Vdd*TIA_BIAS[set_bias];    
  }

  lmp.setBias(set_bias); 
}*/
