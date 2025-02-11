using DinnerHelper.Application.Authentication.Commands.Register;
using DinnerHelper.Application.Services.Authentication;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace DinnerHelper.Application.Common.Behaviors;

public class ValidateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidateBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null) { return await next(); }
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid) { return await next(); }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        // This cast is safe because TResponse is guaranteed to be IErrorOr
        // But using dynamic is dangerous and should be avoided
        return (dynamic)errors;
    }
}