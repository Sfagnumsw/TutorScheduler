using Auth.Core.Repository.Providers;
using Auth.DTO;
using Auth.Infrastructure.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Validators
{
    public class UserValidator : IUserValidator
    {
        private readonly IRepositoryProvider repositoryProvider;
        protected readonly IStringLocalizer<DefaultResource> localizer;

        public UserValidator(IRepositoryProvider repositoryProvider, IStringLocalizer<DefaultResource> localizer) 
        { 
            this.repositoryProvider = repositoryProvider;
            this.localizer = localizer;
        }

        public virtual async Task ValidateUserDto(UserRegistrationDataDTO dto)
        {
            if (!await repositoryProvider.AccountRepository.IsUniqueEmail(dto.Email))
                throw new ValidationException(localizer[DefaultResource.NonUniqueEmailErrorMessage]);
        }
    }
}
