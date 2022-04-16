using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KimdirKimController : ControllerBase
    {
        private readonly IKimdirKimService kimdirkimService;
        public KimdirKimController(IKimdirKimService kimdirkimService)
        {
            this.kimdirkimService = kimdirkimService;
        }

        [HttpGet]
        public IActionResult AddFamousesInformations()
        {
            kimdirkimService.GetFamousInformations();
            return Ok();
        }
    }
}
