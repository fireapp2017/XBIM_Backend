using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBIM_Backend.Application.Services.OuputModels
{
    public class ElementDetails
    {
        public string ElementName { get; set; }
        public decimal ElementGrossFloorArea { get; set; }
        public decimal ElementNetFloorArea { get; set; }
    }
}
