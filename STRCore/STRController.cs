using STRCore.STRElements;

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


    }

    
}
