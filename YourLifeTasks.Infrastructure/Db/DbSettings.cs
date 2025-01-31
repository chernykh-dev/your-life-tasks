namespace YourLifeTasks.Infrastructure.Db;

/// <summary>
/// Конфигурация подключения к БД.
/// </summary>
public class DbSettings
{
    /// <summary>
    /// Хост.
    /// </summary>
    public string Server { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Имя БД.
    /// </summary>
    public string Database { get; set; }

    /// <summary>
    /// Привести конфигурацию к виду строки подключения (ConnectionString).
    /// </summary>
    /// <returns></returns>
    public string ToConnectionString() =>
        $"Server={Server};Database={Database};Username={Username};Password={Password}";
}