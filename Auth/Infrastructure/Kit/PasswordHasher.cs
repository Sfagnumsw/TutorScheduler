
namespace Auth.Infrastructure.Kit
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Получить захэшированный пароль
        /// </summary>
        /// <param name="password">Исходный пароль</param>
        /// <returns>Захэшированный пароль</returns>
        public static string GetPasswordHash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        /// <summary>
        /// Проверить пароль и захэшированный пароль на совпадение
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="passwordHash">Захэшированный пароль</param>
        /// <returns>Результат верификации</returns>
        public static bool VerifyPassword(string password, string passwordHash) => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);

    }
}
