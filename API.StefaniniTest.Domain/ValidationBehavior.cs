using API.StefaniniTest.Domain.Notifications;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.StefaniniTest.Domain
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>? _validator;
        private readonly INotificationService _notifications;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, INotificationService notifications)
        {
            _validator = validators.FirstOrDefault();
            _notifications = notifications;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        _notifications.AddNotification(error.PropertyName, error.ErrorMessage);
                    }
                    return default;
                }
            }

            return await next();
        }
    }
}
