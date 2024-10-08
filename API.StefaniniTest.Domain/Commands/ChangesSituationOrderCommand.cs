﻿using API.StefaniniTest.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain.Commands
{
    public class ChangesSituationOrderCommand : IRequest<ChangesSituationOrderResponseModel>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool Pago { get; set; }

        public ChangesSituationOrderCommand(int id) 
        {
            Id = id;
        }
    }
}
