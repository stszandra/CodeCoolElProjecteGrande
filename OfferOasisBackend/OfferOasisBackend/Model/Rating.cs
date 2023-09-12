namespace OfferOasisBackend.Models;

public record Rating(RatingType RatingGrade, String Comment, int UserId,
    int ProductId);