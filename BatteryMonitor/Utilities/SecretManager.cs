using System;

namespace BatteryMonitor.Utilities
{
    /// <summary>
    /// Minimal, in-memory secret helper that reads the runtime environment variable
    /// ENCRYPTION_CODE. The value is never written to disk by this helper.
    /// </summary>
    public static class SecretManager
    {
        private static string _encryptionCode;

        /// <summary>
        /// Initialize the secret manager by reading environment variables.
        /// Call early in application startup (keeps value only in memory).
        /// </summary>
        public static void Initialize()
        {
            // Read the repository/Actions secret exposed to the process as an env var.
            // GitHub Actions: set env: ENCRYPTION_CODE: ${{ secrets.ENCRYPTION_CODE }} in the workflow.
            _encryptionCode = Environment.GetEnvironmentVariable("ENCRYPTION_CODE");
        }

        /// <summary>
        /// The plaintext encryption code when provided via env var, or null.
        /// Avoid writing this value anywhere persistent.
        /// </summary>
        public static string EncryptionCode => _encryptionCode;

        /// <summary>
        /// Returns true when an encryption code is present in the environment.
        /// </summary>
        public static bool HasEncryptionCode => !string.IsNullOrEmpty(_encryptionCode);
    }
}
