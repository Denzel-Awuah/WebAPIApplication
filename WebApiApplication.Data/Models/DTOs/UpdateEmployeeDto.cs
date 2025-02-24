﻿namespace WebApiApplication.Models.DTOs
{
    public class UpdateEmployeeDto
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
