// INTENTIONALLY INSECURE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp1.Pages
{
    public class VulnerableModel : PageModel
    {
        private readonly ILogger<VulnerableModel> _logger;
        private readonly IConfiguration _configuration;

        public VulnerableModel(ILogger<VulnerableModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string Message { get; private set; } = string.Empty;

        public string FileContents { get; private set; } = "No file requested.";

        public string SqlResult { get; private set; } = "No SQL query executed.";

        public string WeakHash { get; private set; } = "No hash input provided.";

        public void OnGet()
        {
            var name = Request.Query["name"].ToString();
            var filePath = Request.Query["file"].ToString();
            var msg = Request.Query["msg"].ToString();
            var hashInput = Request.Query["hash"].ToString();
            var secret = Request.Query["secret"].ToString();

            // INTENTIONALLY VULNERABLE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
            Message = msg;

            // INTENTIONALLY VULNERABLE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
            if (!string.IsNullOrEmpty(hashInput))
            {
                WeakHash = Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(hashInput)));
            }

            // INTENTIONALLY VULNERABLE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    FileContents = System.IO.File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    FileContents = $"File demo error: {ex.Message}";
                }
            }

            // INTENTIONALLY VULNERABLE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
            if (!string.IsNullOrEmpty(secret))
            {
                _logger.LogInformation("GHAS demo secret value received: {Secret}", secret);
            }

            // INTENTIONALLY VULNERABLE - for GHAS CodeQL demo. DO NOT USE IN PRODUCTION.
            if (!string.IsNullOrEmpty(name))
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
                var sql = "SELECT name FROM sys.databases WHERE name = @name";

                try
                {
                    using var connection = new SqlConnection(connectionString);
                    connection.Open();

                    using var command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@name", name);
                    using var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        SqlResult = reader.GetString(0);
                    }
                    else
                    {
                        SqlResult = "No matching rows returned.";
                    }
                }
                catch (Exception ex)
                {
                    SqlResult = $"SQL demo error: {ex.Message}";
                }
            }
        }
    }
}
