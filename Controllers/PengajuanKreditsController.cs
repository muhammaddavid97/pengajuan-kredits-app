using JWT_Basic.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyWorkTask.Body;
using SkyWorkTask.dto;
using SkyWorkTask.Model;
using SkyWorkTask.Model.Context;
using SkyWorkTask.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyWorkTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PengajuanKreditsController : ControllerBase
    {
        private readonly IPengajuanKreditService _pengajuanKreditService;
        private readonly ILogger<PengajuanKreditsController> _logger;

        public PengajuanKreditsController(IPengajuanKreditService pengajuanKreditService, ILogger<PengajuanKreditsController> logger)
        {
            _pengajuanKreditService = pengajuanKreditService;
            _logger = logger;
        }

        // GET: api/PengajuanKredits
        [HttpGet("GetPengajuanKredits")]
        public async Task<ActionResult<IEnumerable<GetPengajuanKreditResponse>>> GetPengajuanKredits([FromQuery]int page, int pageSize)
        {

            _logger.LogInformation("Get All Data PrngajuanKredit");

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
                _logger.LogError(ex, ex.Message);
               return NotFound($"KeyNotFound {ex.Message}");   
            }
        }

        // GET: api/PengajuanKredits/5
        [HttpGet("GetPengajuanKreditById/{id}")]
        public async Task<ActionResult<GetPengajuanKreditByIdResponse>> GetPengajuanKreditById(int id)
        {

            _logger.LogInformation($"Get data Pengajuan Kredit by Id {id}");

            GetPengajuanKreditByIdResponse response = new GetPengajuanKreditByIdResponse();

            try
            {
                var getData = await _pengajuanKreditService.GetDataByIdAsync(id);
                response.PengajuanKredit = getData;

                return Ok(response);
            }
            catch (KeyNotFoundException ex) 
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        // PUT: api/PengajuanKredits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdatePengajuanKredit")]
        public async Task<IActionResult> UpdatePengajuanKredit([FromBody]UpdatePengajuanKreditRequest request)
        {

            _logger.LogInformation("Update data pengajuan kredit");

            try
            {
                await _pengajuanKreditService.UpdateDataAsync(request.PengajuanKredit);
                return Ok(new Responses { Status = "Success", Message = "Data update successfully!" });

            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
            
        }

        // POST: api/PengajuanKredits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SavePengajuanKredit")]
        public async Task<IActionResult> Post([FromBody]SavePengajuanKreditRequest request)
        {

            _logger.LogInformation("Save data pengajuan kredit");

            try
            {
                if (request.PengajuanKreditDTO == null)
                    throw new KeyNotFoundException();

                await _pengajuanKreditService.AddNewDataAsync(request.PengajuanKreditDTO); // Calls service to add a new product
                return Ok(new Responses { Status = "Success", Message = "Data created successfully!" });

            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"KeyNotFoundException: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Failed", Message = "Oh my god!" });
            }
        }

        // DELETE: api/PengajuanKredits/5
        [HttpDelete("DeletePengajuanKreditById/{id}")]
        public async Task<IActionResult> DeletePengajuanKredit(int id)
        {
            _logger.LogInformation("Delete data pengajuan kredit");

            try
            {
                await _pengajuanKreditService.DeleteDataAsync(id);
                return Ok("Delete Sucessful");
            }
            catch (KeyNotFoundException ex) 
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost("PerhitunganAngsuran")]
        public async Task<ActionResult<PerhitunganAngsuranResponse>> PerhitunganAngsuran([FromBody] PerhitunganAngsuranRequest request)
        {
            try
            {
                _logger.LogInformation("Delete data pengajuan kredit");

                var response = new PerhitunganAngsuranResponse();
                var dataPengajuan = new PengajuanKreditDTO();

                dataPengajuan.Plafon = request.Plafon;
                dataPengajuan.Bunga = request.Bunga;
                dataPengajuan.Tenor = request.Tenor;

                var getData = await _pengajuanKreditService.AngsuranPerbulan(dataPengajuan);

                response.Plafon = getData.Plafon;
                response.Bunga = (double)getData.Bunga;
                response.Tenor = getData.Tenor;
                response.AngsuranPerbulan = getData.HitungAngsuran;

                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Failed", Message = "Oh my god!" });
            }
        }
    }
}
