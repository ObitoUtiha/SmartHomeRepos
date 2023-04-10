using NUnit.Framework;
using SmartHomeApp.Model;
using SmartHomeApp;
using System.Threading.Tasks;
using System;

namespace TestsSmartHome
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task InCorrectUserLoginAuthorisation()
        {
            Users users = new Users { login = "432regf", password = "rQ8nCi-scL" };

            Assert.That(await ApiConnect.AuthorisationAsync(users), Is.Null);
        }

        [Test]
        public async Task InCorrectUserPasswordAuthorisation()
        {
            Users users = new Users { login = "importantrandom", password = "111" };

            Assert.That(await ApiConnect.AuthorisationAsync(users), Is.Null);
        }

        [Test]
        public async Task CorrectAuthorisation()
        {
            Users users = new Users { login = "importantrandom", password = "rQ8nCi-scL" };

            Assert.That(await ApiConnect.AuthorisationAsync(users), Is.Not.Null);
        }

        [Test]
        public async Task NullUerAuthorisation()
        {
            Users users = new Users { login = "", password = "" };

            Assert.That(await ApiConnect.AuthorisationAsync(users), Is.Null);
        }

        [Test]
        public async Task NullNamePostHome()
        {
            Homes newHome = new Homes
            {
                description = "Это дом",
                fullAddress = "ул. Неизвестная, д. 3",
                name = "",
                owner = 6
            };

            Assert.That(await ApiConnect.PostHomeAsync(newHome), Is.False);
        }


        [Test]
        public async Task NullDescriptionPostHome()
        {
            Homes newHome = new Homes
            {
                description = "",
                fullAddress = "ул. Неизвестная, д. 3",
                name = "Домешка",
                owner = 6
            };

            Assert.That(await ApiConnect.PostHomeAsync(newHome), Is.False);
        }

        [Test]
        public async Task NullAddressPostHome()
        {
            Homes newHome = new Homes
            {
                description = "Это дом",
                fullAddress = "",
                name = "Домешка",
                owner = 6
            };

            Assert.That(await ApiConnect.PostHomeAsync(newHome), Is.False);
        }

        [Test]
        public async Task CorrectPostHome()
        {
            Homes newHome = new Homes
            {
                description = "Это дом",
                fullAddress = "ул. Димитрово, д. 44",
                name = "Домешка",
                owner = 6
            };

            Assert.That(await ApiConnect.PostHomeAsync(newHome), Is.True);
        }

        [Test]
        public async Task NullLoginRegistration()
        {
            Users user = new Users()
            {
                login = "",
                password = "gdo32orp33",
                nickName = "Дедiнсsite32"
            };

            Assert.That(await ApiConnect.PostUser(user), Is.False);
        }

        [Test]
        public async Task NullPasswordRegistration()
        {
            Users user = new Users()
            {
                login = "loliho13@yandex.ru",
                password = "",
                nickName = "Дедiнсsite32"
            };

            Assert.That(await ApiConnect.PostUser(user), Is.False);
        }

        [Test]
        public async Task NullNicknameRegistration()
        {
            Users user = new Users()
            {
                login = "loliho13@yandex.ru",
                password = "u65hrg2323",
                nickName = ""
            };

            Assert.That(await ApiConnect.PostUser(user), Is.False);
        }

        [Test]
        public async Task InCorrectLoginRegistration()
        {
            Users user = new Users()
            {
                login = "loliho13",
                password = "u65hrgfdhfg3",
                nickName = "loligho"
            };

            Assert.That(await ApiConnect.PostUser(user), Is.False);
        }

        [Test]
        public async Task CorrectRegistration()
        {
            Random random = new Random();
            var chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            var str = "";
            for (int i = 0; i < random.Next(30); i++)
            {
                str += chars[random.Next(chars.Length)];
            }
            string emailGen = random.Next(1, 40000).ToString();

            Users user = new Users()
            {
                login = $"{str}{emailGen}@yandex.ru",
                password = "u65hrg3yt",
                nickName = "loligho"
            };

            Assert.That(await ApiConnect.PostUser(user), Is.True);
        }

        [Test]
        public async Task GetDevices()
        {
            Assert.That(await ApiConnect.GetDeviceAsync(), Is.Not.Empty);
        }

        [Test]
        public async Task InCorrectDelHome()
        {
            Assert.That(await ApiConnect.DeleteHomeAsync(5443), Is.False);
        }

        [Test]
        public async Task CorrectDelHome()
        {
            Assert.That(await ApiConnect.DeleteHomeAsync(12), Is.True);
        }

        [Test]
        public async Task GetHomes()
        {
            Assert.That(await ApiConnect.GetUserHomes(6), Is.Not.Empty);
        }

        [Test]
        public async Task InCorrectGetHomes()
        {
            Assert.That(await ApiConnect.GetUserHomes(124), Is.Empty);
        }
        [Test]
        public async Task NullDescriptionPutHome()
        {
            Homes home = new Homes { description = "", name = "DomikNaDereve", homeId = 18, fullAddress = "Ул. Жужж, д. 65, кв.34" };
            Assert.That(await ApiConnect.PutHomeAsync(18, home), Is.False);
        }
        [Test]
        public async Task NullNamePutHome()
        {
            Homes home = new Homes { description = "Тут дом на дереве", name = "", homeId = 18, fullAddress = "Ул. Жужж, д. 65, кв.34" };
            Assert.That(await ApiConnect.PutHomeAsync(18, home), Is.False);
        }
        [Test]
        public async Task NullFulladdressPutHome()
        {
            Homes home = new Homes { description = "Тут дом на дереве", name = "DomikNaDereve", homeId = 18, fullAddress = "" };
            Assert.That(await ApiConnect.PutHomeAsync(18, home), Is.False);
        }
        [Test]
        public async Task CorrectPutHome()
        {
            Homes home = new Homes { description = "Тут дом на дереве", homeId = 18, owner = 6, name = "DomikNaDereve", fullAddress = "Ул. Жужж, д. 65, кв.34" };
            Assert.That(await ApiConnect.PutHomeAsync(18, home), Is.True);
        }
    }
}