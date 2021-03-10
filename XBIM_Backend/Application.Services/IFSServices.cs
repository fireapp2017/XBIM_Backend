using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using XBIM_Backend.Application.Services.OuputModels;

namespace XBIM_Backend.Application.Services
{
    public class IFSServices
    {
        private XbimEditorCredentials InitializeUser()
        {
            return new XbimEditorCredentials
            {
                ApplicationDevelopersName = "Eric Aquilina",
                ApplicationFullName = "XBIM Backend",
                ApplicationIdentifier = "452312121901XBIM918",
                ApplicationVersion = "4.0",
                //your user
                EditorsFamilyName = "Aquilina",
                EditorsGivenName = "Eric",
                EditorsOrganisationName = "Independent Architecture"
            };

        }

        public List<ElementOccurences> GetAllElementOccurences()
        {
            try
            {
                List<ElementOccurences> listElementOccurences = new List<ElementOccurences>();
                using (var model = IfcStore.Open("DataFiles\\SampleHouse4.ifc", InitializeUser()))
                {
                    //get all elements
                    var allElements = model.Instances.OfType<IIfcElement>().ToList();
                    List<ElementOccurences> AllElements = new List<ElementOccurences>();
                    List<ElementOccurences> AllBuildingElementsGrouped = new List<ElementOccurences>();
                    foreach (var a in allElements)
                    {
                        var element = a.Name.ToString();
                        var elementType = element.Remove(element.IndexOf(":"));

                        AllElements.Add(new ElementOccurences { ElementName = elementType });
                    }

                    var elementsGrouped = AllElements.GroupBy(i => i.ElementName);
                    foreach (var grp in elementsGrouped)
                    {
                        AllBuildingElementsGrouped.Add(new ElementOccurences { ElementName = grp.Key, ElementOccurance = grp.Count() });
                    }

                    return AllBuildingElementsGrouped;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ElementOccurences> GetAllBuildingElementOccurences()
        {
            try
            {
                List<ElementOccurences> listElementOccurences = new List<ElementOccurences>();
                List<ElementOccurences> AllElementsGrouped = new List<ElementOccurences>();
                using (var model = IfcStore.Open("DataFiles\\SampleHouse4.ifc", InitializeUser()))
                {
                    //get all elements
                    var allElements = model.Instances.OfType<IIfcBuildingElement>().ToList();
                    List<ElementOccurences> AllElements = new List<ElementOccurences>();
                    foreach (var a in allElements)
                    {
                        var element = a.Name.ToString();
                        var elementType = element.Remove(element.IndexOf(":"));

                        AllElements.Add(new ElementOccurences { ElementName = elementType });
                    }

                    var elementsGrouped = AllElements.GroupBy(i => i.ElementName);
                    foreach (var grp in elementsGrouped)
                    {
                        AllElementsGrouped.Add(new ElementOccurences { ElementName = grp.Key, ElementOccurance = grp.Count() });
                    }
                }
                return AllElementsGrouped;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        public List<ElementOccurences> GetSpecificElementOccurances()
        {
            try
            {
                using (var model = IfcStore.Open("DataFiles\\SampleHouse4.ifc", InitializeUser()))
                {

                    List<ElementOccurences> listElementOccurences = new List<ElementOccurences>();
                    var walls = model.Instances.OfType<IIfcWall>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Walls", ElementOccurance = walls.Count() });
                    var doors = model.Instances.OfType<IIfcDoor>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Doors", ElementOccurance = doors.Count() });
                    var windows = model.Instances.OfType<IIfcWindow>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Windows", ElementOccurance = windows.Count() });
                    var tables = model.Instances.OfType<IIfcTable>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Tables", ElementOccurance = tables.Count() });
                    var stairs = model.Instances.OfType<IIfcStair>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Stairs", ElementOccurance = stairs.Count() });
                    var rooms = model.Instances.OfType<IIfcSpace>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Rooms", ElementOccurance = rooms.Count() });
                    var roof = model.Instances.OfType<IIfcRoof>();
                    listElementOccurences.Add(new ElementOccurences { ElementName = "Roof", ElementOccurance = roof.Count() });

                    return listElementOccurences;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ElementDetails> GetRoomElementDetails()
        {
            try
            {
                using (var model = IfcStore.Open("DataFiles\\SampleHouse4.ifc", InitializeUser()))
                {
                    List<ElementDetails> listElementDetails = new List<ElementDetails>();

                    var rooms = model.Instances.OfType<IIfcSpace>();

                    foreach (var room in rooms)
                    {
                        var roomGrossArea = Convert.ToDecimal(((Xbim.Ifc4.ProductExtension.IfcSpace)room).GrossFloorArea.Value);
                        var roomNetArea = Convert.ToDecimal(((Xbim.Ifc4.ProductExtension.IfcSpace)room).NetFloorArea.Value);
                        var roomName = ((Xbim.Ifc4.ProductExtension.IfcSpace)room).LongName;
                        listElementDetails.Add(new ElementDetails { ElementName = roomName, ElementGrossFloorArea = roomGrossArea, ElementNetFloorArea = roomNetArea });
                    }


                    return listElementDetails;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private class ElementOccurenceOutput
        {
            public string elemtName { get; set; }
            public int cnt { get; set; }
        }
    }
}
