﻿using KukoinServer.Model;
using KukoinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace KukoinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KucoinController : ControllerBase
    {
        private readonly KucoinProviderService kucoinProvider;

        public KucoinController(KucoinProviderService kucoinProvider)
        {
            this.kucoinProvider = kucoinProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StatusDTO>> GetKucoins()
        {
            return NotFound("Error: please need to specify pair name, use api/XXX");
        }

        [HttpGet("{pairId}")]
        public async Task<ActionResult<StatusDTO>> GetKucoin(string pairId)
        {
            var result = await kucoinProvider.GetInfo(pairId);

            if (result == null)
            {
                return NotFound($"Pair={pairId} can not be received!");
            }
            //var result = new StatusDTO { pair = pairId, maxBid = 100500d, minAsk = 123d };
            //await Task.Delay(10);
            return result;
        }
    }
}