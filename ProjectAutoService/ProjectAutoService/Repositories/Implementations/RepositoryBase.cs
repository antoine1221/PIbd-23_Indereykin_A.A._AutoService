using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using System.Runtime.CompilerServices;

namespace ProjectAutoService.Repositories.Implementations;

internal abstract class RepositoryBase(Func<DataContext> createContext, ILogger logger)
{
    // Данные для формы нужно загрузить до закрытия контекста.
    protected TResult Run<TResult>(object? input, Func<DataContext, TResult> action,
        Func<TResult, object?> summarize, [CallerMemberName] string operation = "")
    {
        logger.LogInformation("{Operation}: входные данные {@Input}", operation, input);
        try
        {
            using var db = createContext();
            var result = action(db);
            logger.LogInformation("{Operation}: результат {@Result}", operation, summarize(result));
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{Operation}: ошибка, входные данные {@Input}", operation, input);
            throw;
        }
    }
}
