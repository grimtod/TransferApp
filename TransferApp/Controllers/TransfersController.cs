using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TransferApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TransfersController : ControllerBase
	{
		[HttpPost]
		public Task<IActionResult> Transfer(TransferRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
