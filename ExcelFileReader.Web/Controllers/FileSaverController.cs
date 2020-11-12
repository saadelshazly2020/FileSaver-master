using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;

using ExcelFileReader.Models;
using ExcelFileReader.Core.Services.Interfaces;
using ExcelFileReader.Core.DTO;
using Microsoft.AspNetCore.Authorization;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExcelFileReader.Controllers
{

    /* The [ApiController] attribute makes model validation errors
     * automatically trigger an HTTP 400 response
     * The [ApiController] attribute makes attribute routing required
     * The [ApiController]: attribute applies inference rules for the default data sources of 
     * action parameters such as [FromBody],[FromForm], [FromRoute] and [FromQuery]
         */
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FileSaverController : Controller
    {
        // inject file service
        private readonly IFileSaverService _fileSaverService;
        public FileSaverController(IFileSaverService fileSaverService)
        {
            _fileSaverService = fileSaverService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<FileModelDTO> Get(int page)
        {
            var data = _fileSaverService.GetFileData(page);
            return data;
        }


        // POST api/<controller>
        [HttpPost, DisableRequestSizeLimit]
        public JsonResult Post()
        {
            CustomResponse customResponse = new CustomResponse();
            try
            {

                var fileStream = Request.Form.Files[0].OpenReadStream();
                // For .net core, the next line requires the NuGet package, 
                // System.Text.Encoding.CodePages
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream))
                {
                    //DataSet - The result of each spreadsheet will be created in the result.Tables
                    DataSet result = reader.AsDataSet();
                    //iterate on sheets
                    foreach (DataTable table in result.Tables)
                    {
                        List<FileModelDTO> lst = new List<FileModelDTO>();
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            FileModelDTO item = new FileModelDTO();
                            // read new row
                            item.Key = table.Rows[i].ItemArray[0].ToString();
                            item.ItemCode = table.Rows[i].ItemArray[1].ToString();
                            item.ColorCode = table.Rows[i].ItemArray[2].ToString();
                            item.Description = table.Rows[i].ItemArray[3].ToString();
                            item.Price = table.Rows[i].ItemArray[4].ToString();
                            item.DiscountPrice = table.Rows[i].ItemArray[5].ToString();
                            item.DeliveredIn = table.Rows[i].ItemArray[6].ToString();
                            item.Q1 = table.Rows[i].ItemArray[7].ToString();
                            item.Size = table.Rows[i].ItemArray[8].ToString();
                            item.Color = table.Rows[i].ItemArray[9].ToString();
                            lst.Add(item);
                            //this to not add all rows at one time but 100 row foreach database insert(if very big data)
                            if (lst.Count() == 100)
                            {
                                _fileSaverService.AddNewFileData(lst);
                                lst = new List<FileModelDTO>();
                            }

                        }
                        if (lst.Count() != 0)
                        {
                            _fileSaverService.AddNewFileData(lst);
                        }

                    }
                }
                customResponse.Message = "Success";
                customResponse.StatusCode = 200;
            }
            catch (Exception ex)
            {

                customResponse.Message = ex.Message;
                customResponse.StatusCode = 500;
            }

            return Json(customResponse);
        }

    }
}
