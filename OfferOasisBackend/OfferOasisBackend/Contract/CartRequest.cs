using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Contract;

public record CartRequest(List<CartDetail> ListOfCartDetails);