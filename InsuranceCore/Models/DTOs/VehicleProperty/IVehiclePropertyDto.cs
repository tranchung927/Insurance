using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCore.Models.DTOs.VehicleProperty
{
	public interface IVehiclePropertyDto
    {

        public string Property { get; set; }


        public int Value { get; set; }


        public int Status { get; set; }

        public int VehicleTypeId { get; set; }

    }
}

