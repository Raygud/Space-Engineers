# Space-Engineers
Code snippets for space engineers

#Ray Casting 

```
public void Main(string argument, UpdateType updateType)
{
    IMyTerminalBlock block = GridTerminalSystem.GetBlockWithName("MyCamera");
    if (block != null && block is IMyCameraBlock)
    {
        IMyCameraBlock camera = block as IMyCameraBlock;

        block = GridTerminalSystem.GetBlockWithName("MyLCDPanel");
        if (block != null && block is IMyTextPanel)
        {
            IMyTextPanel textPanel = block as IMyTextPanel;

            double distance = 3500; // distance to raycast
            MyDetectedEntityInfo entity = camera.Raycast(distance);

            if (entity.Type != MyDetectedEntityType.None && entity.HitPosition.HasValue)
            {
                Vector3D hitPosition = entity.HitPosition.Value;
                Vector3D cameraPosition = camera.GetPosition();
                double groundDistance = hitPosition.Y - cameraPosition.Y;

                // Display information on LCD screen
                textPanel.WriteText("Ground Distance: " + groundDistance.ToString("#.##") + " m\n", false);
                textPanel.WriteText("Entity Name: " + entity.Name + "\n", true);
                textPanel.WriteText("Entity Type: " + entity.Type.ToString() + "\n", true);
            }
            else
            {
                // Handle case when entity.HitPosition does not have a value
            }
            Runtime.UpdateFrequency = UpdateFrequency.Update10;
        }
        else
        {
            
            Echo("No display found, please check that you have a LCD screen installed and that it has the right name");
        }
    }
    else
    {
         Echo("NO CAMERA DETECTED\n CANNOT DETECT DISTANCE");
    }
}
```

```
public void Main(string argument, UpdateType updateType)
{
    IMyTerminalBlock block = GridTerminalSystem.GetBlockWithName("MyCamera");
    if (block != null && block is IMyCameraBlock)
    {
        if (block != null && block is IMyTextPanel)
        {

            if (entity.Type != MyDetectedEntityType.None && entity.HitPosition.HasValue)
            {
            }
            else
            {
                // Handle case when entity.HitPosition does not have a value
            }
        }
        else
        {
                        // Handle case when LCD is missing 
        }
    }
    else
    {
                    // Handle case when Camera is missing 
    }
}
```

We start of by checking if all the things we need are installed, this will give you a better understanding of what is missing

```
    IMyTerminalBlock block = GridTerminalSystem.GetBlockWithName("MyCamera");
    block = GridTerminalSystem.GetBlockWithName("MyLCDPanel");
```
Change theses variables to what ever you want they need to match the name of the installed blocks

```
            double distance = 200; // distance to raycast
```

The distance you want to scan so 200 = 200meters 


           
