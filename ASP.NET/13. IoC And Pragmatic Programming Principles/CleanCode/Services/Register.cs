using CleanCode.Application.Repository;
using CleanCode.Application.Validation;
using CleanCode.Domain.Models;
using CleanCode.Infrastructure.Validation;
using CleanCode.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.Repository
{
    public class Register
    {
        private readonly IRepository _repository;
        private readonly ISpeakerValidator _speakerValidator;

        public Register(IRepository repository, ISpeakerValidator speakerValidator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _speakerValidator = speakerValidator ?? throw new ArgumentNullException(nameof(speakerValidator));
        }

        public int? RegisterSpeaker(Speaker speaker)
        {
            if (!_speakerValidator.Validate(speaker))
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet requirements.");

            speaker.RegistrationFee = CleanCode.Utilities.RegistrationFeeCalculator.CalculateRegistrationFee(speaker.Exp);

            try
            {
                return _repository.SaveSpeaker(speaker);
            }
            catch (Exception)
            {
                // Log exception
                throw; // Rethrow the exception
            }
        }
    }
}