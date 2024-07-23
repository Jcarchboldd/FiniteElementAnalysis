using STRCore;
using STRCore.STRElements;

STRController.Initialize();
if (STRController.CurrentController != null)
{
	
    STRSupport pin = STRController.CurrentController.DefineSTRSupport("Pin",true, true, true, false, false, false);

    STRSupport roller = STRController.CurrentController.DefineSTRSupport("Roller",false, false, true, false, false, false);    

	Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.ModifySTRSupport(roller, "Fixed", true, true, true, true, true, true);

    Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.DeleteSTRSupport(pin);

    Console.WriteLine(STRController.CurrentController);

}
Console.ReadKey();

// STRNode startNode = new(1, 0, 0, 0);
// STRNode endNode = new(2, 5, 5, 0);
// STRLine line = new(1, startNode, endNode);

// Console.WriteLine(startNode.ToString());
// Console.WriteLine(line.ToString());
