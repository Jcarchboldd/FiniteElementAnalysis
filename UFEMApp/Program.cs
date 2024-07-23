using STRCore;
using STRCore.STRElements;

STRController.Initialize();
if (STRController.CurrentController != null)
{
	STRMaterial conc = STRController.CurrentController.DefineSTRMaterial("Concrete", 20e9);
    STRMaterial steel = STRController.CurrentController.DefineSTRMaterial("Steel", 200e9);

    STRRelease release1 = STRController.CurrentController.DefineSTRRelease("r1", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);    

	Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.ModifySTRRelease(release1, "r1_modified", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

    Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.DeleteSTRRelease(release1);

    Console.WriteLine(STRController.CurrentController);

}
Console.ReadKey();

// STRNode startNode = new(1, 0, 0, 0);
// STRNode endNode = new(2, 5, 5, 0);
// STRLine line = new(1, startNode, endNode);

// Console.WriteLine(startNode.ToString());
// Console.WriteLine(line.ToString());
