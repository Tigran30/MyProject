﻿using MediatR;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Models;

namespace ServicesAPI.Queries
{
    public class GetAllServiceListQuery :IRequest<List<ServiceDTO>>
    {
        //public GetAllServiceListQuery()//int id, string serviceName, int serviceCost)
        //{
        //    //Id = id;
        //    //ServiceName = serviceName;
        //    //ServiceCost = serviceCost;
        //}

        //public int Id { get; set; }
        //public string ServiceName { get; set; } = null!;
        //public int ServiceCost { get; set; }
    }
}
