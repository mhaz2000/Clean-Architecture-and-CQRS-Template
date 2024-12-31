using CleanArchAndCQRS.Domain.Consts;
using CleanArchAndCQRS.Shared.Abstractions.Commands;

namespace CleanArchAndCQRS.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, uint Days, Gender Gender,
        LocalizationWriteModel Localization): ICommand;
    public record LocalizationWriteModel(string city, string country);
}
