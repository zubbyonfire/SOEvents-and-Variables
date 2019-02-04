Whats in this project:
- Scriptable Object Event System (SOEvents) + Event System Window
- Scriptable Object Variables (SOVariables)
- Sample project using the SOEvents and SOVariables
- Custom Icons for the Scriptable Objects

To access the SOVariable you'll need to add using ScriptableObjectVariable.
To access the SOEvent you'll need to add using ScriptableObjectEvent.

Steps for Creating an Event
- Create a new sGameEvent in the project folder (right click -> create -> soGameEvent
- Give it a name
- On the GameObject you want to use the event add a GameEventListener
- Drag the GameEvent object you created into the Event variable on the GameEventListener
- On the GameEventListener click the + and attach the response you want to happen
- Add a description about what the response to the event will do (optional)

Event Manager Window
- Go to Window -> EventManager
- This window will show you all events being used in the current scene + which objects are
registered to each event
- While the scene is playing you can raise any of the events to make sure they work

Scriptable Object Variables
- Use Scriptable Object Variables whenever you some data that multiple objects need to access
- For example PlayerHealth may need to be accessed by the player, UI and sound system
- Create a Scriptable Object Variable: create -> soVariable -> soFloat
- Give it a name and assign a starting value
- On scripts which need to access the variable, add a public SOFloat variable
- Drag the SOFloat into the scripts SOFloat field
- During play mode you can reset or modify the current value of the SOVariable in the inspector
for that object

Check out the ExampleProject to see how everything is setup.

For a detailed video on Scriptable Object Events, check out this video from Unite Austin 2017 by Ryan Hipple:
https://www.youtube.com/watch?v=raQ3iHhE_Kk

Or for a more TLDR article: https://unity3d.com/how-to/architect-with-scriptable-objects

GitHub of this project can be found at: https://github.com/zubbyonfire/SOEvents-and-Variables

