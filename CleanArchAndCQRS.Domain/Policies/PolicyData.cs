using CleanArchAndCQRS.Domain.Consts;
using CleanArchAndCQRS.Domain.ValueObjects;

namespace CleanArchAndCQRS.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);
    
}
