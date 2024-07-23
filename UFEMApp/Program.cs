using STRCore;
using STRCore.STRElements;

STRController.Initialize();
if (STRController.CurrentController != null)
{
	
    STRSection section1 = STRController.CurrentController.DefineSTRSection("Sec1", 0.15, 0.05, 0.05, 0.05);
    STRSection section2 = STRController.CurrentController.DefineSTRSection("Sec2", 0.30, 0.10, 0.10, 0.10);

    STRSupport roller = STRController.CurrentController.DefineSTRSupport("Roller",false, false, true, false, false, false);    

	Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.ModifySTRSection(section1, "Sec1_mod", 0.25, 0.05, 0.05, 0.05);

    Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.DeleteSTRSection(section1);

    Console.WriteLine(STRController.CurrentController);

}
Console.ReadKey();

// STRNode startNode = new(1, 0, 0, 0);
// STRNode endNode = new(2, 5, 5, 0);
// STRLine line = new(1, startNode, endNode);

// Console.WriteLine(startNode.ToString());
// Console.WriteLine(line.ToString());
