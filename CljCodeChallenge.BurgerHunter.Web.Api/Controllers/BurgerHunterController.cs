using CljCodeChallenge.BurgerHunter.Core;
using CljCodeChallenge.BurgerHunter.Core.Model;
using CljCodeChallenge.BurgerHunter.Web.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace CljCodeChallenge.BurgerHunter.Web.Api.Controllers
{
	[ApiController]
	[Route("burger-hunter-api")]
	public class BurgerHunterController : ControllerBase
	{
		private BurgerHunterProcessor BurgerHunterProcessor { get; }

		public BurgerHunterController(BurgerHunterProcessor burgerHunterProcessor)
		{
			BurgerHunterProcessor = burgerHunterProcessor;
		}

		[HttpPost]
		[Route("user-login")]
		public AccessToken UserLogin([FromBody] LoginRequest request)
		{
			return BurgerHunterProcessor.UserLogin(request.Email, request.SecurityToken);
		}

		[HttpPost]
		[Route("submit-review")]
		public SubmitReviewResult SubmitReview([FromBody] BurgerReviewSubmission review, [FromHeader] string accessToken)
		{
			return BurgerHunterProcessor.SubmitReview(review, new AccessToken(accessToken));
		}
	}
}
