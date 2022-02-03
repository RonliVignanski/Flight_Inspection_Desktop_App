# Flight Gear Application:

Our application is a flight simulator. This application gets two CSV files with data about flight and data about anomalies. In addition, the application gets XML file with the names of data that we have in the first CSV.
After loading the files, the simulation will start. The user can control the flight speed, analyze data and find anomalies using another CSV file that indicates this.


### App features:
  - **Connect FlightGear application and use it as a simulator to screen user flight data 
  input.**
  - **Control the time of the screening flight with a interactive Time-Controller slider.**
  - **Representation of values of relevant (e.g speed and direction) data with a Joystick and Clocks.**
  - **Graphs - the user can choose any item of data from input items and show 3 graphs:** 
  1) An updated graph of selected item values along the flight.
  2) An updated graph of most correlative item of the selected item.
  3) Regression line between the selected item and its most correlative item
     with updated points of items values.
  

  - **Upload dynamicly an Anomaly detector algorithm (dll) to investigate
    the flight with the following abilities:**
  1) Select an item from input items and investigate the anomalies graph of 
     item's values and most correlative values.
  2) Display a list of anomalies of item and its most correlative item.
     By choosing one of the anomalies reports, the user can jump over to the   
     specific moment of the anomaly.
     	
  - **Plugins - the application is comming with 2 anomaly detection algorithms -
    linear regression algorithm and min circle algorithm. 
    Note: the user can found more details and specifically API
    about writing a new anomaly algorithm.**
  

### App content:
 Our application begins with the MainWindow. There we see the first page of instruction for the user and the settings button. This leads the user to another window where he has to give three paths: xml path and two csv paths, one for learning and the other for anomalies.
 This is shown in the settingsWindow. After that the app window is poped up and the user can use our application.
 We organized our code in these folders:
* controls
* exceptions
* interfaces
* src
* window

**contolrs** 
    contains folders and files which connects to MVVM. They are user controls to AppWindow.xaml. In each folder      we have the model and the view mode of part of the code. The folders are:
	filesLoaderMVVM- contains FilesLoaderModel.cs and FilesLoaderViewModel.cs
	flightInfo - contains FlightInfoModel.cs and FlightInfoViewModel.cs 
	graphMVVM - contains GraphModel.cs and GraphViewModel.cs
	timeControllerMVVM- contains TimeControllerModel.cs and TimeControllerViewModel.cs
	wheelMVVM - contains WheelControllerModel.cs and WheelControllerViewModel.cs
	dllAlgorithmHandlerMVVM - contains DllAlgorithmGraphModel.cs and DllAlgorithmGraphViewModel
	dllAlgorithmGraphMVVM - contains DllAlgorithmHandlerModel and DllAlgorithmHandlerViewModel
        we also have the views of these classes: FlightInfo.xaml and FlightInfo.xaml.cs
	GraphController.xaml and GraphController.xaml.cs
	TimeController.xaml and TimeController.xaml.cs
	WheelController.xaml and  WheelController.xaml.cs

**exceptions** 
contains one class we created - InputException in order to throw exception when the user writes invalid paths for the xml ans csv paths.

**interfaces** 
IFgClient.cs, IFilesParser.cs, IFindCorrelation.cs

**src**
    contains logic that connects to the whole project, including:
    FilesParser.cs - which is responbile for parsing the xml pile and taking the names of the columns in the csv pile, putting neccesary informaion in maps in order to use it in the other parts of the project.
    FindCorrelation.cs.
    Line.cs.
    AnomalyReports.cs
    MyFgClient.cs - to connect to the simulator.

**window**
    All the things we see, which means all the app windows in which we show everything.
    We have there: AppWindaow.xaml which is the main window of our app.
    SettingWindow.xaml as explained before about the paths the user writes.
    LoadDllAlgorithm which is opened when the user is clicking on the button of loading anomaly detection algorithm.
    DllAlgorithmGraph.xaml which responsible for working with the loaded dll algorithm.
    WriteYoureOwnAlgorithmWindow which represent the required API of writing and loading user's anomaly detection algorithm (dll).

		        



**Instructions for using the application:**
- Prepare two CSV files : first of them is the flight data, and the second one learning about correlative data.
- Download IDE visual studio 2019 in order to run the application in a comfortable place (.Net Framework version 4.7.2 and above).
- Clone the project.
- For writing your own dll anomaly algorithm, write a class library with a .Net 4.8 version (more details at the app).
- Install OxyPlot.dll, OxyPlot.Wpf.dll, OxyPlot.Wpf.xml, OxyPlot.xml. 
- Download 'FlightGear' 2020.3.6 application. You can use it: https://www.flightgear.org/
- Open this application.
- Go to settings in the FlightGear application you opened and write under Additional Settings these lines:
  --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
  --fdm=null
- Press the button Fly in FlightGear.
- By pressing the button a new window will pop up and you have to write the xml and csv paths. If you write wrong paths you will get an error, and will have to fill again those boxes with the correct ones.
- Now, you can see the application window. In order to see the flight in the simulator in the FlightGear you download, press the play button. if you want to pause it, press pause button and for stoppng the app and start from the beginning, press stop button.

**FlightGear App - Explenation Video**

[Watch here](https://www.youtube.com/watch?v=NEGrobgzevc)

#### Authors:
* Hadas Babayov
* Liav Trabelsy
* Ronli vignanski
* Eyal Hazi




