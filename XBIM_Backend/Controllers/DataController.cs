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
            try
            {
                var operation = new IFSServices();
                var ElementsList = operation.GetSpecificElementOccurances();
            
                if (ElementsList == null)
                {
                    return NotFound();
                }

                return ElementsList;
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
                var operation = new IFSServices();
                var ElementsList = operation.GetAllElementOccurences();

                if (ElementsList == null)
                {
                    return NotFound();
                }
                return ElementsList;
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

                var operation = new IFSServices();
                var ElementsList = operation.GetAllBuildingElementOccurences();

                if (ElementsList == null)
                {
                    return NotFound();
                }

                return ElementsList;
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
                var operation = new IFSServices();
                var ElementsList = operation.GetRoomElementDetails();

                if (ElementsList == null)
                {
                    return NotFound();
                }

                return ElementsList;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

    }
}


