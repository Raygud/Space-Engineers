IMyCameraBlock camera;
        IMyTextPanel lcd;
        public Program()
		{

            camera = GridTerminalSystem.GetBlockWithName("Camera") as IMyCameraBlock;
            if (camera == null)
            {
                throw new Exception("Couldn't find camera!");

            }

            camera.EnableRaycast = true;

            lcd = GridTerminalSystem.GetBlockWithName("LCD") as IMyTextPanel;
            if (lcd == null)
            {
                throw new Exception("Couldn't find LCD!");

            }

            Runtime.UpdateFrequency = UpdateFrequency.Update10;
		}

        public void Main(string argument, UpdateType updateType)
        {
          

            double distance = 200; // distance to raycast
            MyDetectedEntityInfo entity = camera.Raycast(distance);
            if (entity.Type != MyDetectedEntityType.None)
            {
                Vector3D hitPosition = entity.HitPosition.Value;
                Vector3D cameraPosition = camera.GetPosition();
                double groundDistance = Vector3D.Distance(hitPosition, cameraPosition);

                // Use groundDistance for whatever you need

                // Refresh LCD with live data
                lcd.WriteText($"Ground Distance: {groundDistance}m");
            }
            else
            {
                // Clear LCD if no entity detected
                lcd.WriteText("");
            }
        }
