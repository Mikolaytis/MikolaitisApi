using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikolaitis.Api.Authorization.Models;

namespace Mikolaitis.Api.Authorization.Tests
{
    [TestClass]
    public class RegisterBindingModelTests
    {
        private static bool ValidateRegisterBindingModel<T>(T model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var typo = typeof(T);
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typo, typo), typo);
            return Validator.TryValidateObject(model, context, results, true);
        }

        private static RegisterBindingModel GetValidBindingModel() => new RegisterBindingModel
        {
            Email = "tim@apple.com",
            Password = "aA123456",
            ConfirmPassword = "aA123456",
            Name = "Сергей"
        };

        [TestMethod]
        public void IsValid_AllFieldsValid_True()
        {
            var model = GetValidBindingModel();

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_Empty_False()
        {
            var model = new RegisterBindingModel();

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_ShortPassword_False()
        {
            var model = GetValidBindingModel();
            model.Password = model.ConfirmPassword = "aA1";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_ShortName_False()
        {
            var model = GetValidBindingModel();
            model.Name = "Ян";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_InvalidEmail_False()
        {
            var model = GetValidBindingModel();
            model.Email = "tim@@apple.com";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_NameInvalidChars_False()
        {
            var model = GetValidBindingModel();
            model.Name = "авы№аВ1";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_NameSpace_True()
        {
            var model = GetValidBindingModel();
            model.Name = "Сергей Андреевич";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_DifferentPasswords_False()
        {
            var model = GetValidBindingModel();
            model.ConfirmPassword = "aAs1123sd";

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_EmptyEmail_False()
        {
            var model = GetValidBindingModel();
            model.Email = null;

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_EmptyPassword_False()
        {
            var model = GetValidBindingModel();
            model.Password = null;

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_EmptyName_False()
        {
            var model = GetValidBindingModel();
            model.Name = null;

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_EmptyConfirmPassword_False()
        {
            var model = GetValidBindingModel();
            model.ConfirmPassword = null;

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_TooLongName_False()
        {
            var longName = "СергейСергейСергейСергейСергейСергейСергейСергейСергейСергейСергейСергей" +
                           "СергейСергейСергейСергейСергейСергейСергейСергейСергейСергейСергейСергей";
            var model = new RegisterBindingModel
            {
                Email = "tim@apple.com",
                Password = "aA123456",
                Name = longName
            };

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_TooLongPassword_False()
        {
            var longPassword = "aA123456mtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                               "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                               "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                               "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim";
            var model = new RegisterBindingModel
            {
                Email = "tim@apple.com",
                Password = longPassword,
                Name = "Сергей"
            };

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public void IsValid_TooLongEmail_False()
        {
            var longName = "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                           "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                           "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim" +
                           "timtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtimtim";
            var model = new RegisterBindingModel
            {
                Email = longName + "@apple.com",
                Password = "aA123456",
                Name = "Сергей"
            };

            var isModelStateValid = ValidateRegisterBindingModel(model);

            Assert.IsFalse(isModelStateValid);
        }
    }
}
