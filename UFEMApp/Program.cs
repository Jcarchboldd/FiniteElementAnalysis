using STRCore;
using STRCore.STRElements;
using static Global.Enums;

STRController.Initialize();
if (STRController.CurrentController != null)
{
	STRMaterial Steel = STRController.CurrentController.DefineSTRMaterial("Steel", 210000);
    STRSection Sec1 = STRController.CurrentController.DefineSTRSection("Sec1", 0.15, 0.02, 0.05, 0.05);
    STRRelease release1 = STRController.CurrentController.DefineSTRRelease("Release1", 0, 0 , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

    STRNode node1 = STRController.CurrentController.DefineSTRNode(0, 0, 0);
    STRNode node2 = STRController.CurrentController.DefineSTRNode(5, 0, 0);

    STRLine line = STRController.CurrentController.DefineSTRLine(node1, node2);

    STRSupport roller = STRController.CurrentController.DefineSTRSupport("Roller",false, false, true, false, false, false);

    STRLoadCase dL1 = STRController.CurrentController.DefineSTRLoadCase("Dead Load", LoadCaseType.Dead);
    STRLoadCase wind = STRController.CurrentController.DefineSTRLoadCase("Live Load", LoadCaseType.Live); 

    STRLoadCombination ULS = STRController.CurrentController.DefineSTRLoadCombination("ULS", LoadCombinationType.ULS);  

	Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.ModifySTRLine(line, line.StartNode, line.EndNode, Steel, Sec1, release1);

    STRController.CurrentController.ModifySTRNode(node1, node1.X, node1.Y, node1.Z, roller);

    STRController.CurrentController.ModifySTRLoadCase(wind, "Wind Load", LoadCaseType.Wind);

    List<STRLoadCase> loadCases = [];
    List<double> loadFactors = [];
    loadCases.Add(dL1);
    loadFactors.Add(1.5);

    STRController.CurrentController.ModifySTRLoadCombination(ULS, "ULS_Mod", LoadCombinationType.ULS, loadCases, loadFactors);

    List<int> appliedOnIds = [];
    appliedOnIds.Add(-1);

    STRLoad load1 = STRController.CurrentController.DefineSTRLoad(dL1, appliedOnIds);
    STRLoad load2 = STRController.CurrentController.DefineSTRLoad(wind, appliedOnIds);

    Console.WriteLine(STRController.CurrentController);

    STRController.CurrentController.DeleteSTRLoad(load2);

    STRController.CurrentController.DeleteSTRNode(node2);

    Console.WriteLine(STRController.CurrentController);

}
Console.ReadKey();

// STRNode startNode = new(1, 0, 0, 0);
// STRNode endNode = new(2, 5, 5, 0);
// STRLine line = new(1, startNode, endNode);

// Console.WriteLine(startNode.ToString());
// Console.WriteLine(line.ToString());
