# 2StrokeEngineSimulator
2 Stroke Engine Simulator Console Application in C#


# 2StrokeEngineSimulator

Following is a rundown spec of the program functionality that will emulate a 2 stroke engine. 

1)	The engine model consists of the following parts 
a.	Piston
b.	Spark Plug
c.	Rod Controller
d.	CrankShaft 
2)	The engine is a 2 stroke engine and has 2 main functionalities , UP stroke and DOWN stroke
3)	The RodController connects the PISTON and the CrankShaft.
4)	The RodController moves the PISTON UP and DOWN
5)	The UP Stroke consists of 2 simultaneous ACTIONS that occur at the same time
a.	Intake Process – this action will open the Proppet Valve and fuel will enter into the Crank Case Chamber.
b.	Compression – this action will compress the fuel mixture that is inside the Main Cylinder
6)	The TOP of the UP Stroke will IGNITE the Fuel that is in the Main Cylinder using the SPARK Plug, this ACTION will cause the PISTON to move DOWN. The speed is at ZERO in this state.
7)	The DOWN Stroke consists of 2 simultaneous ACTIONS that occur at the same time
a.	Transfer/Exhaust – this action will transfer fuel mixture into the main cylinder and expel exhaust gases out the exhaust port
b.	CrankCase Compression – this action will CLOSE the Proppet Valve and compress the fuel mixture that is in the Crank Case Chamber
8)	The BOTTOM of the Down Stroke the speed will be ZERO.
9)	The length of the Stroke is 2 inches. 
10)	One Cycle will consist of 1 UP and 1 DOWN stroke. 
11)	One Cycle must finish all its ACTIONS (all UP actions and all DOWN actions) before beginning another Cycle.
12)	There are 4 Cycles in this program. 4UP,4DOWN,4IGNITIONS but many ACTIONS 
13)	Each ACTION will take 1 second to complete to help simulate movement.
14)	The program uses multi-threading to perform all the simultaneous ACTIONS in the engine.
15)	The program will ECHO out ALL the state of the engine including the PISTON and SPARK Plug


Description of Task
Develop a C# program representing a simple two-stroke engine model using separate classes for the engine, piston, spark plug, and controller.
Use threads to simulate the piston movement. A controller class should trigger the spark plug at the right time when the piston is at the top of the stroke, and the spark plug should interact with the piston to move it downward. Print out the piston state and spark plug activity.
http://www.animatedengines.com/twostroke.html 
Bonus:
Calculate live piston speed in 'miles per hour' assuming a stroke of 2 inches and a varying random engine speed between 0 and 1,000 rpm. Print the piston speed as the program runs.
https://www.cartechbooks.com/techtips/pistonspeed/


PSEUDO

Piston at Top  - SPEED is ZERO
Ignite
Power Process Starts
Burn Fuel causes Thermal Heat Energy
Move Up Piston Complete – 1 Stroke Complete
Move Down Piston Start – 2 Stroke Start
Crank Case Compression of Fuel 
Proppet Valve Closes	
Transfer/ Exhaust Process Start
Piston at Bottom
Exhaust Port Exposed
Compressed Fuel/Air from Crank Case enters Main Cylinder
Exhaust Gases Out Exhaust Port some Fresh Fuel/Air also Escapes
Move Down Piston Complete – 2 Stroke Complete
Intake Start
Move Up Piston Start – 1 Stroke Start
Proppet Valve Opens
Fresh fuel/air mixture enters Crank Case
Cylinder Compression of Fuel
REPEAT
