using STRCore;
using STRCore.STRElements;

STRController.Initialize();
if (STRController.CurrentController != null)
{
	
    STRNode node1 = STRController.CurrentController.DefineSTRNode(0, 0, 0);
    STRNode node2 = STRController.CurrentController.DefineSTRNode(5, 0, 0);

    STRSupport roller = STRController.CurrentController.DefineSTRSupport("Roller",false, false, true, false, false, false);    

	Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.ModifySTRNode(node1, node1.X, node1.Y, node1.Z, roller);

    Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.DeleteSTRNode(node2);

    Console.WriteLine(STRController.CurrentController);

}
Console.ReadKey();

// STRNode startNode = new(1, 0, 0, 0);
// STRNode endNode = new(2, 5, 5, 0);
// STRLine line = new(1, startNode, endNode);

// Console.WriteLine(startNode.ToString());
// Console.WriteLine(line.ToString());
