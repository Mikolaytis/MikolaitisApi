using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikolaitis.Api.Authorization.Identity;
using Mikolaitis.Api.Authorization.Tests.Stubs;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Authorization.Tests
{
    [TestClass]
    public class CustomUserManagerTests
    {
        private static ApplicationUser GetUser() => new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "tim@apple.com",
            Password = "aA123456",
            UserName = "Сергей"
        };

        [TestMethod]
        public async Task CreateAsync_ValidPassword_Succeeded()
        {
            var manager = new CustomUserManager(new StubUserStore());
            var user = GetUser();

            var result = await manager.CreateAsync(user, user.Password);

            Assert.IsTrue(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateAsync_NoLowerCase_Fail()
        {
            var manager = new CustomUserManager(new StubUserStore());
            var user = GetUser();

            var result = await manager.CreateAsync(user, "AA123456");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateAsync_NoUpperCase_Fail()
        {
            var manager = new CustomUserManager(new StubUserStore());
            var user = GetUser();

            var result = await manager.CreateAsync(user, "aa123456");

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateAsync_NoDigits_Fail()
        {
            var manager = new CustomUserManager(new StubUserStore());
            var user = GetUser();

            var result = await manager.CreateAsync(user, "AAaaAAaa");

            Assert.IsFalse(result.Succeeded);
        }
        
        [TestMethod]
        public async Task CreateAsync_EmailExists_Fail()
        {
            var store = new StubUserStore();
            store.Users.Add(GetUser());
            var manager = new CustomUserManager(store);
            var user = GetUser();

            var result = await manager.CreateAsync(user, user.Password);

            Assert.IsFalse(result.Succeeded);
        }

        [TestMethod]
        public async Task CreateAsync_UserNameExists_Succeeded()
        {
            var store = new StubUserStore();
            store.Users.Add(GetUser());
            var manager = new CustomUserManager(store);
            var user = GetUser();
            user.Email = "miko@laitis.ru";

            var result = await manager.CreateAsync(user, user.Password);

            Assert.IsTrue(result.Succeeded);
        }
    }
}
