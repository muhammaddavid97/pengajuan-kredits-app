using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyWorkTask.Body;
using SkyWorkTask.dto;
using SkyWorkTask.Model;
using SkyWorkTask.Model.Context;
using SkyWorkTask.Service.Interface;

namespace SkyWorkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PengajuanKreditsController : ControllerBase
    {
        private readonly IPengajuanKreditService _pengajuanKreditService;

        public PengajuanKreditsController(IPengajuanKreditService pengajuanKreditService)
        {
            _pengajuanKreditService = pengajuanKreditService;
        }

        // GET: api/PengajuanKredits
        [HttpGet("GetPengajuanKredits")]
        public async Task<ActionResult<IEnumerable<GetPengajuanKreditResponse>>> GetPengajuanKredits([FromQuery]int page, int pageSize)
        {
            GetPengajuanKreditResponse responses = new GetPengajuanKreditResponse();

            try
            {
                var getData = await _pengajuanKreditService.GetAllDataAsync(page, pageSize);
                responses.Page = page;
                responses.PageSize = pageSize;
                responses.Items = getData;

                return Ok(responses);
            }
            catch (KeyNotFoundException ex) 
            {
               return NotFound($"KeyNotFound {ex.Message}");   
            }
        }

        // GET: api/PengajuanKredits/5
        [HttpGet("GetPengajuanKreditById/{id}")]
        public async Task<ActionResult<GetPengajuanKreditByIdResponse>> GetPengajuanKreditById(int id)
        {

            GetPengajuanKreditByIdResponse response = new GetPengajuanKreditByIdResponse();

            try
            {
                var getData = await _pengajuanKreditService.GetDataByIdAsync(id);
                response.PengajuanKredit = getData;

                return Ok(response);
            }
            catch (KeyNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/PengajuanKredits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdatePengajuanKredit")]
        public async Task<IActionResult> UpdatePengajuanKredit([FromBody]UpdatePengajuanKreditRequest request)
        {
            try
            {
                await _pengajuanKreditService.UpdateDataAsync(request.PengajuanKredit);
                return Ok("Update Sucessful");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
        }

        // POST: api/PengajuanKredits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SavePengajuanKredit")]
        public async Task<ActionResult<PengajuanKredit>> Post([FromBody]PengajuanKreditDTO pengajuanKredit)
        {
            await _pengajuanKreditService.AddNewDataAsync(pengajuanKredit); // Calls service to add a new product
            return Ok();
        }

        // DELETE: api/PengajuanKredits/5
        [HttpDelete("DeletePengajuanKreditById/{id}")]
        public async Task<IActionResult> DeletePengajuanKredit(int id)
        {
            try
            {
                await _pengajuanKreditService.DeleteDataAsync(id);
                return Ok("Delete Sucessful");
            }
            catch (KeyNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        private bool PengajuanKreditExists(int id)
        {
            return false;
        }
    }
}
