using Microsoft.Extensions.Configuration;

namespace CleanArchAndCQRS.Shared.Options
{
    public static class Extensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuartion, string sectionName)
            where TOptions : new()
        {
            var options = new TOptions();
            configuartion.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
