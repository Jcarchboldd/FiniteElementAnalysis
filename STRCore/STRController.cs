using STRCore.STRElements;
using static Global.Enums;

namespace STRCore
{
    public class STRController
    {
        public static STRController? CurrentController;

        public STRStructure Structure { get; set; }

        public static void Initialize()
        {
            CurrentController = new STRController();
        }

        internal STRController()
        {
            Structure = new STRStructure();
        }

        public override string ToString()
        {
            return "Hello World, I am the Controller, and my current structure is: " + Structure.ToString();
        }

        public STRMaterial DefineSTRMaterial(string name, double elasticModulus)
        {
            int id = GetNextMaterialId();
            STRMaterial definedMaterial = new STRMaterial(id, elasticModulus, name);
            Structure.STRMaterials.Add(definedMaterial);
            return definedMaterial;
        }

        public void ModifySTRMaterial(STRMaterial material, string name, double elasticModulus)
        {
            if (Structure.STRMaterials.Exists(x => x.Id == material.Id))
            {
                material.ElasticModulus = elasticModulus;
                material.Name = name;               
            }
            
        }

        public void DeleteSTRMaterial(STRMaterial material)
        {
            if (Structure.STRSupports.Exists(x => x.Id == material.Id))
            {
                Structure.STRMaterials.Remove(material);
                foreach (var line in Structure.STRLines)
                {
                    if (line.Material?.Id == material.Id)
                    {
                        line.Material = null;
                    }
                }
            }
        }

        public STRRelease DefineSTRRelease(string name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            int id = GetNextReleaseId();
            STRRelease definedRelease = new(id, name, kUxStart, kUyStart, kUzStart, kRxStart, kRyStart, kRzStart, kUxEnd, kUyEnd, kUzEnd, kRxEnd, kRyEnd, kRzEnd);
            Structure.STRReleases.Add(definedRelease);
            return definedRelease;
        }

        public void ModifySTRRelease(STRRelease release, string name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            if (Structure.STRReleases.Exists(x => x.Id == release.Id))
            {
                release.Name = name;
                release.KUxStart = kUxStart;
                release.KUyStart = kUyStart;
                release.KUzStart = kUzStart;
                release.KRxStart = kRxStart;
                release.KRyStart = kRyStart;
                release.KRzStart = kRzStart;
                release.KUxEnd = kUxEnd;
                release.KUyEnd = kUyEnd;
                release.KUzEnd = kUzEnd;
                release.KRxEnd = kRxEnd;
                release.KRyEnd = kRyEnd;
                release.KRzEnd = kRzEnd;
            }
        }

        public void DeleteSTRRelease(STRRelease release)
        {
            if (Structure.STRSupports.Exists(x => x.Id == release.Id))
            {
                Structure.STRReleases.Remove(release);
                foreach (var line in Structure.STRLines)
                {
                    if (line.Release?.Id == release.Id)
                    {
                        line.Release = null;
                    }
                }
            }
        }

        public STRSupport DefineSTRSupport(string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            int id = GetNextSupportId();
            STRSupport definedSupport = new(id, name, isUxActive, isUyActive, isUzActive, isRxActive, isRyActive, isRzActive);
            Structure.STRSupports.Add(definedSupport);
            return definedSupport;
        }

        public void ModifySTRSupport(STRSupport support, string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            if (Structure.STRSupports.Exists(x => x.Id == support.Id))
            {
                support.Name = name;
                support.IsUxActive = isUxActive;
                support.IsUyActive = isUyActive;
                support.IsUzActive = isUzActive;
                support.IsRxActive = isRxActive;
                support.IsRyActive = isRyActive;
                support.IsRzActive = isRzActive;

                support.Refresh();
            }
        }

        public void DeleteSTRSupport(STRSupport support)
        {
            if (Structure.STRSections.Exists(x => x.Id == support.Id))
            {
                Structure.STRSupports.Remove(support);
                foreach (var node in Structure.STRNodes)
                {
                    if (node.Support?.Id == support.Id)
                    {
                        node.Support = null;
                    }
                }
            }
        }

        public STRSection DefineSTRSection(string name, double area, double inertiaX, double inertiaY, double inertiaZ)
        {
            int id = GetNextSectionId();
            STRSection definedSection = new(id, name, area, inertiaX, inertiaY, inertiaZ);
            Structure.STRSections.Add(definedSection);
            return definedSection;
        }

        public void ModifySTRSection(STRSection section, string name, double area, double inertiaX, double inertiaY, double inertiaZ)
        {
            if (Structure.STRSections.Exists(x => x.Id == section.Id))
            {
                section.Name = name;
                section.Area = area;
                section.InertiaX = inertiaX;
                section.InertiaY = inertiaY;
                section.InertiaZ = inertiaZ;
            }
        }

        public void DeleteSTRSection(STRSection section)
        {
            if (Structure.STRSections.Exists(x => x.Id == section.Id))
            {
                Structure.STRSections.Remove(section);
                foreach (var line in Structure.STRLines)
                {
                    if (line.Section?.Id == section.Id)
                    {
                        line.Section = null;
                    }
                }
            }
        }

        public STRNode DefineSTRNode(double x, double y, double z)
        {
            int id = GetNextNodeId();
            STRNode definedNode = new(id, x, y, z);
            Structure.STRNodes.Add(definedNode);
            return definedNode;
        }

        public void ModifySTRNode(STRNode node, double x, double y, double z, STRSupport? support)
        {
            if (Structure.STRNodes.Exists(x => x.Id == node.Id))
            {
                node.X = x;
                node.Y = y;
                node.Z = z;
                node.Support = support;
                foreach (var line in Structure.STRLines)
                {
                    if (line.StartNode.Id == node.Id || line.EndNode.Id == node.Id)
                    {
                        line.Refresh();
                    }
                }
            }
        }

        public void DeleteSTRNode(STRNode node, bool forceDelete = false)
        {
            bool isNodePartOfLine = false;
            foreach (var line in Structure.STRLines)
            {
                if (line.StartNode.Id == node.Id || line.EndNode.Id == node.Id)
                {
                    isNodePartOfLine = true;
                    break;
                }
            }

            if (isNodePartOfLine && !forceDelete)
            {
                return;
            }
            else
            {
                if (Structure.STRNodes.Exists(x => x.Id == node.Id))
                {
                    Structure.STRNodes.Remove(node);
                }
                
                List<STRLine> affectedLines = Structure.STRLines.FindAll(x => x.StartNode.Id == node.Id || x.EndNode.Id == node.Id);

                foreach (var line in affectedLines)
                {
                    DeleteSTRLine(line);
                }
            }
        }

        public STRLine DefineSTRLine(STRNode startNode, STRNode endNode)
        {
            int id = GetNextLineId();
            STRLine definedLine = new(id, startNode, endNode);
            Structure.STRLines.Add(definedLine);
            return definedLine;
        }

        public void ModifySTRLine(STRLine line, STRNode startNode, STRNode endNode, STRMaterial? material, STRSection? section, STRRelease? release)
        {
            if (Structure.STRLines.Exists(x => x.Id == line.Id))
            {
                line.StartNode = startNode;
                line.EndNode = endNode;
                line.Material = material;
                line.Section = section;
                line.Release = release;
                line.Refresh();
            }
        }

        public void DeleteSTRLine(STRLine line)
        {
            if (Structure.STRLines.Exists(x => x.Id == line.Id))
            {
                Structure.STRLines.Remove(line);
            }
        }

        public STRLoadCase DefineSTRLoadCase(string name, LoadCaseType loadCaseType)
        {
            int id = GetNextLoadCaseId();
            STRLoadCase definedLoadCase = new(id, name, loadCaseType);
            Structure.STRLoadCases.Add(definedLoadCase);
            return definedLoadCase;
        }

        public void ModifySTRLoadCase(STRLoadCase loadCase, string name, LoadCaseType loadCaseType)
        {
            if (Structure.STRLoadCases.Exists(x => x.Id == loadCase.Id))
            {
                loadCase.Name = name;
                loadCase.Type = loadCaseType;
            }
        }

        public void DeleteSTRLoadCase(STRLoadCase loadCase)
        {
            if (Structure.STRLoadCases.Exists(x => x.Id == loadCase.Id))
            {
                Structure.STRLoadCases.Remove(loadCase);

                for (int i = 0; i < Structure.STRLoadCases.Count; i++)
                {
                    STRLoadCase possibleCombination = Structure.STRLoadCases[i];
                    if (possibleCombination is STRLoadCombination combination)
                    {
                        STRLoadCombination comb = (STRLoadCombination)possibleCombination;
                        if (comb.LoadCases.Exists(x => x.Id == loadCase.Id))
                        {
                            int index = comb.LoadCases.FindIndex(x => x.Id == loadCase.Id);
                            comb.LoadCases.RemoveAt(index);
                            comb.LoadCaseFactors.RemoveAt(index);
                        }
                    }
                }
            }
        }

        public STRLoadCombination DefineSTRLoadCombination(string name, LoadCombinationType loadCombinationType)
        {
            int id = GetNextLoadCaseId();
            STRLoadCombination definedLoadCombination = new(id, name, loadCombinationType);
            Structure.STRLoadCombinations.Add(definedLoadCombination);
            return definedLoadCombination;
        }

        public void ModifySTRLoadCombination(STRLoadCombination loadCombination, string name, LoadCombinationType loadCombinationType, List<STRLoadCase> loadCases, List<double> loadCaseFactors)
        {
            if (Structure.STRLoadCombinations.Exists(x => x.Id == loadCombination.Id))
            {
                loadCombination.Name = name;
                loadCombination.LoadCombinationType = loadCombinationType;
                loadCombination.LoadCases.Clear();
                for (int i = 0; i < loadCases.Count; i++)
                {
                    loadCombination.LoadCases.Add(loadCases[i]);
                    loadCombination.LoadCaseFactors.Add(loadCaseFactors[i]);
                } 
            }
        }

        public void DeleteSTRLoadCombination(STRLoadCombination loadCombination)
        {
            if (Structure.STRLoadCombinations.Exists(x => x.Id == loadCombination.Id))
            {
                Structure.STRLoadCombinations.Remove(loadCombination);
            }
        }

        public STRLoad DefineSTRLoad(STRLoadCase loadCase, List<int> appliedOnIds)
        {
            int id = GetNextLoadId();
            STRLoad definedLoad = new(id, loadCase, appliedOnIds);
            Structure.STRLoads.Add(definedLoad);
            return definedLoad;
        }

        public void DeleteSTRLoad(STRLoad load)
        {
            if (Structure.STRLoads.Exists(x => x.Id == load.Id))
            {
                Structure.STRLoads.Remove(load);
            }
        }

        private int GetNextNodeId()
        {
            return Structure.LastNodeId++;
        }

        private int GetNextLineId()
        {
            return Structure.LastLineId++;
        }

        private int GetNextMaterialId()
        {
            return Structure.LastMaterialId++;
        }

        private int GetNextReleaseId()
        {
            return Structure.LastRelesaeId++;
        }

        private int GetNextSupportId()
        {
            return Structure.LastSupportId++;
        }

        private int GetNextSectionId()
        {
            return Structure.LastSectionId++;
        }

        private int GetNextLoadCaseId()
        {
            return Structure.LastLoadCaseId++;
        }

        private int GetNextLoadCombinationId()
        {
            return Structure.LastLoadCombinationId++;
        }

        private int GetNextLoadId()
        {
            return Structure.LastLoadId++;
        }

    }

    
}
