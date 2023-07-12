﻿using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace CRUDExample.Controllers
{
    [Route("[controller]")]    
    public class CountriesController : Controller
    {
        // Fields
        private readonly ICountriesUploadFromExcelService _countriesUploadFromExcelService;

        // Constructors
        public CountriesController(ICountriesUploadFromExcelService countriesUploadFromExcelService)
        {
            _countriesUploadFromExcelService = countriesUploadFromExcelService;
        }

        // Methods

        [Route("[action]")]     //Url: /Countries/UploadFromExcel
        [HttpGet]
        public IActionResult UploadFromExcel()
        {
            return View();
        }

        [Route("[action]")]     //Url: /Countries/UploadFromExcel
        [HttpPost]
        public async Task<IActionResult> UploadFromExcel(IFormFile excelFile)
        {
            // Validation
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.ErrorMessage = "Please select an xlsx file";
                return View();
            }

            if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.ErrorMessage = "Unsupported file. 'xlsx' file is expected";
                return View();
            }

            int countriesCountInserted = await _countriesUploadFromExcelService.UploadCountriesFromExcelFile(excelFile);
            ViewBag.Message = $"{countriesCountInserted} Countries Uploaded";
            return View();

        }
    }
}
