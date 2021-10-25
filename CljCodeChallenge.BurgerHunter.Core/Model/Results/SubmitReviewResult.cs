using CljCodeChallenge.BurgerHunter.Core.Validation;
using System;
using System.Collections.Generic;

namespace CljCodeChallenge.BurgerHunter.Core.Model
{
	public class SubmitReviewResult
	{
		public Guid ReviewId { get; }
		public bool Success { get; }
		public int ErrorCode { get; }
		public string ErrorMessage { get; }
		public IList<string> ErrorDetails { get; }

		private SubmitReviewResult(int errorCode, string errorMessage, IList<string> errorDetails = null) : this(false, Guid.Empty)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
			ErrorDetails = errorDetails;
		}
		private SubmitReviewResult(bool success, Guid reviewId)
		{
			Success = success;
			ReviewId = reviewId;
		}

		public static SubmitReviewResult Successful(Guid reviewId) => new SubmitReviewResult(true, reviewId);
		public static SubmitReviewResult AuthenticationFailed() => new SubmitReviewResult(1, $"User authentication failed");
		public static SubmitReviewResult UnknownInternalError() => new SubmitReviewResult(1, $"Unknown internal error occurred");
		public static SubmitReviewResult FailureInvalidReview(ValidationResult result) => new SubmitReviewResult(2, $"Review has { result.Errors.Count} validation error(s)", result.Errors);
	}
}
