using SmartHomeApp.Model;
using SmartHomeApp.Classes;
using SmartHomeApp;
using NUnit.Framework;

namespace SmartHomeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task InCorrectUserEmail()
        {
            Users users = new Users { login = "432regf", password = "111" };

            Assert.That(await ApiConnect.AuthorisationAsync(users).ConfigureAwait(true), Is.Null);
        }

        [Test]
        public async Task CorrectUserEmail()
        {
            Users users = new Users { login = "importantrandom", password = "rQ8nCi-scL" };

            Assert.That(await ApiConnect.AuthorisationAsync(users).ConfigureAwait(true), Is.Not.Null);
        }
    }
}