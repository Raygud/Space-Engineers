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

            double distance = 200; // distance to raycast
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
        Echo("No camera found, cannot detect distance");
    }
}
