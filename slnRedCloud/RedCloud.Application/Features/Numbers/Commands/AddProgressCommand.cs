using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public  class AddProgressCommand:IRequest<Response<Unit>>
    {
         public int NumberId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

    }
}
