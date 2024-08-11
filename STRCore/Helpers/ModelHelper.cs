using System;
using STRCore.STRElements;

namespace STRCore.Helpers
{
    public static class ModelHelper
    {
        public static void ClearStructuralModel()
        {
            if (STRController.CurrentController?.Structure != null)
            {
                STRController.CurrentController.Structure.FEMNodes.Clear();
                STRController.CurrentController.Structure.FEMBars.Clear();
                STRController.CurrentController.Structure.LastFEMNodeId = 0;
                STRController.CurrentController.Structure.LastFEMBarId = 0;
                foreach(STRLine line in STRController.CurrentController.Structure.STRLines)
                {
                    line.FEMBars.Clear();
                }

                List<STRNode> autoNodes = [];
                foreach(STRNode node in STRController.CurrentController.Structure.STRNodes)
                {
                    if (node.IsAutoGenerated)
                        autoNodes.Add(node);
                }
                foreach (STRNode autoNode in autoNodes)
                {
                    STRController.CurrentController.Structure.STRNodes.Remove(autoNode);
                }   
            }               
        }
    }
}
