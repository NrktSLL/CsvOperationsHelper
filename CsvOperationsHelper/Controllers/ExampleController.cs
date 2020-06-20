using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CsvOperationsHelper.Business.Helper.CsvHelper;
using CsvOperationsHelper.Business.Helper.Mapping.CsvMap;
using CsvOperationsHelper.Data.Dto;
using CsvOperationsHelper.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CsvOperationsHelper.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        #region Properties

        private readonly ILogger<ExampleController> _logger;
        private readonly IMapper _mapper;
        private readonly ICsvHelper<Product> _csvHelper;

        #endregion

        #region Constructor

        public ExampleController(ILogger<ExampleController> logger, ICsvHelper<Product> csvHelper, IMapper mapper)
        {
            _logger = logger;
            _csvHelper = csvHelper;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates new .csv file
        /// </summary>
        /// <param name="product"></param>
        /// <returns>filename.csv File</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="500">Indicates that an error occurred in process</response>
        /// <response code="400">model not valid</response>
        [HttpPost("CreateCsv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCsv(IEnumerable<ProductDto> product)
        {
            if (!ModelState.IsValid) return BadRequest();

            var filePath = $"{Environment.CurrentDirectory}/CSVFile"; // the directory I want to create

            var newProduct = _mapper.Map<IEnumerable<ProductDto>, IEnumerable<Product>>(product);

            var result = _csvHelper.CreateCsv(newProduct, filePath, "report", true, true, false, new ProductCsvMap());

            if (result) return Ok("Csv Created");

            _logger.LogWarning("An error occurred while creating CSV");
            return StatusCode(500, "An error occurred while creating CSV");
        }

        /// <summary>
        /// Reading the csv file created by program
        /// </summary>
        /// <returns>filename.csv File</returns>
        /// <response code="200">Returns values in csv file</response>
        /// <response code="500">Indicates that an error occurred in process</response>
        [HttpGet("ReadCsv")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ReadCsv()
        {
            var filePath = $"{Environment.CurrentDirectory}/CSVFile"; // Created directory

            const string file = "report.csv";

            var productList = _csvHelper.ReadCsv($"{filePath}/{file}", new ProductCsvMap())?.ToList();

            if (productList == null || productList.Count == 0)
            {
                _logger.LogWarning("CSV empty");
                return StatusCode(500, "CSV empty");
            }

            var product = _mapper.Map<List<Product>, List<ProductDto>>(productList);
            return Ok(product);
        }

        #endregion
    }
}
