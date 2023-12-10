using System;
using System.Text;

namespace ASC_TEST
{
    public class Configs
    {
        public static string SecretTokenHash { get; } = Environment.GetEnvironmentVariable("TOKEN_HASH");
        public static int SecretPasswordHash { get; } = Int16.Parse(Environment.GetEnvironmentVariable("PWD_HASH"));
    }
}
