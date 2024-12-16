﻿namespace Wajba.Dtos.CompanyContact;

public class CreateComanyDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string WebsiteURL { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string CountryCode { get; set; }
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public IFormFile? LogoUrl { get; set; }
    public CreateComanyDto()
    {
        
    }
}
