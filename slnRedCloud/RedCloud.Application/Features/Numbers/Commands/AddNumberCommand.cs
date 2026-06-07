using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public  class AddNumberCommand:IRequest<Response<int>>
    {

        public int NumberId { get; set; }
        public string PhoneNumber { get; set; }
      
        public int TypesId { get; set; }
     
        public int StateId { get; set; }
     
        
        public int CarrierId { get; set; }
     

        public int CountryId { get; set; }
        public string LATA { get; set; }
        public string RateCenter { get; set; }

        
    }
}
