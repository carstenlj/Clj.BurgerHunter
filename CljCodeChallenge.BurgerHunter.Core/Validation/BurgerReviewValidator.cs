using CljCodeChallenge.BurgerHunter.Core.Model;
using System;

namespace CljCodeChallenge.BurgerHunter.Core.Validation
{
	public class BurgerReviewValidator
	{
		public const int MinContentLength = 8;
		public const int MaxContentLength = 8192;
		public const int MinSummaryLength = 4;
		public const int MaxSummaryLength = 48;
		public const int MaxBurgerNameLength = 64;
		public const int MaxReviewHoursOfAge = 24;

		public ValidationResult Validate(BurgerReviewSubmission review)
		{
			return new ValidationResult()
				.WithConditionalError(
					error: $"Review must be made within the past {MaxReviewHoursOfAge} hours",
					condition: DateTimeOffset.UtcNow - review.Timestamp > TimeSpan.FromHours(MaxReviewHoursOfAge))

				.WithConditionalError(
					error: $"Review must at least be {MinContentLength} characters long",
					condition: review.Content?.Length < MinContentLength)

				.WithConditionalError(
					error: $"Review cannot exceed {MaxContentLength} characters", 
					condition: review.Content?.Length > MaxContentLength)

				.WithConditionalError(
					error: $"Summary must at least be {MinSummaryLength} characters long", 
					condition: review.Summary?.Length < MinSummaryLength)

				.WithConditionalError(
					error: $"Summary cannot exceed {MaxSummaryLength} characters", 
					condition: review.Summary?.Length > MaxSummaryLength)

				.WithConditionalError(
					error: $"Review must specify the email of the reviewer", 
					condition: string.IsNullOrWhiteSpace(review.ReviewerEmail))

				.WithConditionalError(
					error: $"Burger name cannot exceed {MaxBurgerNameLength} characters", 
					condition: review.BurgerName?.Length > MaxSummaryLength)

				.WithConditionalError(
					error: $"Store must be specified", 
					condition: review.VendorId.Equals(Guid.Empty))

				.WithConditionalError(
					error: $"Rating must be specified", 
					condition: review.Rating == null);
		}
	}
}
