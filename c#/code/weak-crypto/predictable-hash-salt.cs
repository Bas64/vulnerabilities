public void Hash(string password)
{
    var salt = Encoding.UTF8.GetBytes("Hardcoded salt");
    var fromHardcoded = new Rfc2898DeriveBytes(password, salt);     // Noncompliant, salt is hardcoded

    salt = Encoding.UTF8.GetBytes(password);
    var fromPassword = new Rfc2898DeriveBytes(password, salt);     // Noncompliant, password should not be used as a salt as it makes it predictable

    var shortSalt = new byte[8];
    RandomNumberGenerator.Create().GetBytes(shortSalt);
    var fromShort = new Rfc2898DeriveBytes(password, shortSalt);   // Noncompliant, salt is too short (should be at least 32 bytes, not 8)
}