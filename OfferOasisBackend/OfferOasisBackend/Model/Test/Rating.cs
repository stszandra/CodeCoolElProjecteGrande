namespace OfferOasisBackend.Models;

public record Rating(int Id, RatingType RatingGrade, String Comment, int UserId,
    int ProductId);