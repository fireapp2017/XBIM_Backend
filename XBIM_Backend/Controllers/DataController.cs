using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBIM_Backend.Application.Services;

namespace XBIM_Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {

        [HttpGet]
        [Route("TestConnectivity")]
        public async Task<ActionResult<Object>> TestConnectivity()
        {

            return "Azure Test Passed";
        }

        [HttpGet]
        [Route("GetSpecificElementOccurances")]
        public async Task<ActionResult<Object>> GetSpecificElementOccurances()
        {
            //To do - modofy endpoint to return adequate http codes
            try
            {
                var operation = new IFSServices();
                var ElementOccurancesList = operation.GetSpecificElementOccurances();
            
                if (ElementOccurancesList == null)
                {
                    return NotFound();
                }

                return ElementOccurancesList;
                }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        [HttpGet]
        [Route("GetAllElementOccurences")]
        public async Task<ActionResult<Object>> GetAllElementOccurences()          
        {
            try
            {
                //To do - modofy endpoint to return adequate http codes
                var operation = new IFSServices();
                var AllElementOccurencesList = operation.GetAllElementOccurences();

                if (AllElementOccurencesList == null)
                {
                    return NotFound();
                }
                return AllElementOccurencesList;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }

        [HttpGet]
        [Route("GetAllBuildingElementOccurences")]
        public async Task<ActionResult<Object>> GetAllBuildingElementOccurences()
        {
            try
            {
                //To do - modofy endpoint to return adequate http codes
                var operation = new IFSServices();
                var BuildingElementOccurencesList = operation.GetAllBuildingElementOccurences();

                if (BuildingElementOccurencesList == null)
                {
                    return NotFound();
                }

                return BuildingElementOccurencesList;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
}


        [HttpGet]
        [Route("GetRoomElementDetails")]
        public async Task<ActionResult<Object>> GetRoomElementDetails()
        {
            try
            {
                //To do - modofy endpoint to return adequate http codes
                var operation = new IFSServices();
                var RoomElementDetailsList = operation.GetRoomElementDetails();

                if (RoomElementDetailsList == null)
                {
                    return NotFound();
                }

                return RoomElementDetailsList;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

    }
}


